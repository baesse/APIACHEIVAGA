using AcheiVaga.PI4.Models.Estacionamento;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using AcheiVaga.PI4.Models;
teste
namespace AcheiVaga.PI4.Models.Mall
{
    public class Mall
    {
        public ObjectId _id { get; set; }
        public String NomeShoping { get; set; }
        public List<Piso> AndaresEstacionamento { get; set; }
        public List<Loja> LOJAS { get; set; }




        public Mall(List<Loja> lojasnovas, List<Piso> Andares)
        {
            this.AndaresEstacionamento = Andares;
            this.NomeShoping = "Minas Shoping";
            this.LOJAS = new List<Loja>();
            foreach (Loja lojanova in lojasnovas)
            {
                this.LOJAS.Add(lojanova);
            }

        }

        public Mall()
        {

        }

        public void InseriShooping(Mall SHOP)
        {
            IMongoCollection<Mall> Novoshoping = Banco.Conexao.DataBase.GetCollection<Mall>("Mall");
            Novoshoping.InsertOne(SHOP);
        }




        public Vaga MelhorVaga(String nomeloja)
        {
            IMongoCollection<Mall> Mall = Banco.Conexao.DataBase.GetCollection<Mall>("Mall");
            var filtro = Builders<Mall>.Filter.Empty;
            var MALL = Mall.Find<Mall>(filtro).ToList();
            List<Loja> listlojas = new List<Loja>();
            List<Piso> listAndares = new List<Piso>();



            foreach (Mall SHOP in MALL)
            {
                foreach (Loja loja in SHOP.LOJAS)
                {
                    if (loja.nomedaloja.Equals(nomeloja))
                        listlojas.Add(loja);


                }

                foreach (Piso Andar in SHOP.AndaresEstacionamento)
                {

                    listAndares.Add(Andar);



                }

            }


            return Magica(listlojas, listAndares);


        }

        public Vaga Magica(List<Loja> Lojas, List<Piso> Pisos)
        {
            List<Vaga> listvagas = new List<Vaga>();



            foreach (Piso Andares in Pisos)
            {
                foreach (Loja loja in Lojas)
                {
                    if (loja.Codigodopiso == Andares.Codigodopiso)
                    {
                        foreach (Vaga vagas in Andares.vagasdopiso)
                        {
                            if (vagas.VerOcupacao == false)
                            {

                                listvagas.Add(vagas);
                            }

                        }
                    }
                }

            }






            foreach (Vaga melhorvaga in listvagas)
            {
                if (melhorvaga.VerOcupacao == false)
                {
                    melhorvaga.melhorvaga = true;
                    return melhorvaga;

                }

            }
            return null;
        }

        public String OcuparVaga(int iddavaga, int codigopiso)
        {
            IMongoCollection<Mall> MALL = Banco.Conexao.DataBase.GetCollection<Mall>("Mall");
            var filtro = Builders<Mall>.Filter.Empty;
            var mall = MALL.Find(filtro).ToList();
            var filtrodelete = Builders<Mall>.Filter.Where(p => p.NomeShoping == "Minas Shoping");
            foreach (Mall SHOOP in mall)
            {
                foreach (Piso piso in SHOOP.AndaresEstacionamento)
                {
                    if (piso.Codigodopiso == codigopiso)
                    {
                        foreach (Vaga vaga in piso.vagasdopiso)
                        {
                            if (vaga.Codigovaga == iddavaga)
                            {
                                vaga.VerOcupacao = true;

                                MALL.DeleteOne(filtro);
                                MALL.InsertOne(SHOOP);
                                return "Vaga atualizada no piso " + piso.Codigodopiso + " com codigo de vaga numero " + iddavaga;
                            }
                        }
                    }

                }


            }

            return "Vaga não atualizada";




        }

        public string GetTodasAsVagas()
        {
            IMongoCollection<Mall> MALL = Banco.Conexao.DataBase.GetCollection<Mall>("Mall");
            var filtro = Builders<Mall>.Filter.Empty;
            var mall = MALL.Find(filtro).ToList();
            List<Vaga> vagas = new List<Vaga>();


            foreach (Mall shopp in mall)
            {
                foreach (Piso andares in shopp.AndaresEstacionamento)
                {
                    foreach (Vaga vaga in andares.vagasdopiso)
                    {
                        vagas.Add(vaga);


                    }
                }
            }
            return ConvertListForJson(vagas);


        }

        public string GetTodasAsVagasPorAndar(int codigoandar)
        {
            IMongoCollection<Mall> MALL = Banco.Conexao.DataBase.GetCollection<Mall>("Mall");
            var filtro = Builders<Mall>.Filter.Empty;
            var mall = MALL.Find(filtro).ToList();
            List<Piso> Andares = new List<Piso>();
            List<Vaga> Vagasdopiso = new List<Vaga>();


            foreach (Mall shopp in mall)
            {
                foreach (Piso andares in shopp.AndaresEstacionamento)
                {
                    if (andares.Codigodopiso == codigoandar)
                    {
                        Andares.Add(andares);
                        break;

                    }
                }
            }


            foreach(Piso andar in Andares)
            {
               foreach(Vaga vagas in andar.vagasdopiso)
                {
                    Vagasdopiso.Add(vagas);

                }
            }
            return ConvertListForJson(Vagasdopiso);


        }












        public static string ConvertListForJson(List<Vaga> list)
        {
            try
            {
                List<Vaga> VAGAS = new List<Vaga>();

                foreach (Vaga vaga in list)
                {
                    VAGAS.Add(vaga);

                }

                var JsonSerializado = Newtonsoft.Json.JsonConvert.SerializeObject(VAGAS);
                return JsonSerializado;

            }
            catch (Exception e)
            {
                e.ToString();
                return "";

            }
        }

    }
}
