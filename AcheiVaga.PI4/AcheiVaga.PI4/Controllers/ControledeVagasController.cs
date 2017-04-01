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
        public List<Models.Vaga> GetVagas()
        {
            Models.Vaga vagas = new Models.Vaga();
            return vagas.GetTodasasVagasOcupadas();
        }


        [HttpPut]
        public string PutOcuparVaga(int id)
        {
            Models.Vaga vagas = new Models.Vaga();

            vagas.PutRegistrarVaga(id);

            return "Vaga";
            
        }

    }
}
