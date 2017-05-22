using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static AcheiVaga.PI4.Models.Rotas.Rota;

namespace AcheiVaga.PI4.Controllers
{
    public class CalculodeRotaController : ApiController
    {
        [HttpGet]
        public string BuscaDistancia(string destino)
        {
            return CalcularDistanciaEDuracao(destino);



        }

        private string CalcularDistanciaEDuracao(string destino)
        {

            List<Models.Vaga> Vagas = Models.Vaga.RetornoListaVagaDesocupadas();
            List<Models.Vaga> VAGAMAISPERTO = new List<Models.Vaga>();
            double menordistancia = 10000;




            foreach (Models.Vaga vagasbusca in Vagas)
            {

                double distancia, duracao;

                bool sucesso = false;
                distancia = duracao = 0;

                try
                {
                    string url = string.Format(
                        "http://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&sensor=false",
                        vagasbusca.Endereco, destino);
                    System.Net.WebRequest request = System.Net.HttpWebRequest.Create(url);
                    System.Net.WebResponse response = request.GetResponse();
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                        string responseString = reader.ReadToEnd();
                        RootObject responseData = parser.Deserialize<RootObject>(responseString);
                        if (responseData != null)
                        {
                            double distanciaRetornada = responseData.routes.Sum(r => r.legs.Sum(l => l.distance.value));
                            double duracaoRetornada = responseData.routes.Sum(r => r.legs.Sum(l => l.duration.value));
                            if (distanciaRetornada != 0)
                            {
                                sucesso = true;
                                distancia = distanciaRetornada;
                                duracao = duracaoRetornada;
                            }
                        }
                    }

                    if (distancia < menordistancia)
                    {
                       
                            VAGAMAISPERTO.Clear();
                            VAGAMAISPERTO.Add(vagasbusca);                          
                            menordistancia = distancia;
                        

                    }

                }
                catch { }


            }
            return Models.Vaga.ConvertListForJson(VAGAMAISPERTO);


        }

    }
}
