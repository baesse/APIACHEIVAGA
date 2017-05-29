using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models.Estacionamento
{
    public class Piso
    {

        public int Codigodopiso { get; set; }
        public int andarpiso { get; set; }
        public List<Vaga> vagasdopiso { get; set; }



        public Piso(int codigopiso,List<Vaga> vagas)
        {
            this.andarpiso = codigopiso;
            this.Codigodopiso = codigopiso;
            this.vagasdopiso = new List<Vaga>();


            foreach (Vaga novavaga in vagas)
            {
                vagasdopiso.Add(novavaga);

            }


        }
    }
}