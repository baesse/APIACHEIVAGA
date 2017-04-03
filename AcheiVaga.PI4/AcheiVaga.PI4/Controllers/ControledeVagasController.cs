using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace AcheiVaga.PI4.Controllers
{
    public class ControledeVagasController : ApiController
    {
        


        [HttpGet]
        public string GetJsonVgasOcupadas()
        {
            Models.Vaga vaga = new Models.Vaga();
            return vaga.ListadeVagas();

        }


        [HttpPost]
        public string PostNovaVaga()
        {
            Models.Vaga vaga = new Models.Vaga();
            vaga.CadastrodeVaga();
            return "Vaga cadastrada";
        }

        

    }
}
