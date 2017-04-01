using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models
{
    public  class Vaga
    {
        public int IdVaga { get; set; }
        public bool VerOcupacao { get; set; }
        public int IdEstacionamento { get; set; }
        public static   List<Vaga> VagasOcupadas = new List<Vaga>();

        public Vaga()
        {
           
        }

        public Vaga(int IdVaga,bool VerOcupacao,int IdEstacionamento)
        {
            this.IdVaga = IdVaga;
            this.VerOcupacao = VerOcupacao;
            this.IdEstacionamento = IdEstacionamento;
        }


        public List<Vaga> GetTodasasVagasOcupadas()
        {
            List<Vaga> ListadasOupadas = new List<Vaga>();
            
            
            foreach(Vaga VagasDesocupadas in VagasOcupadas)
            {
                if (VagasDesocupadas.VerOcupacao != false)
                {
                    ListadasOupadas.Add(VagasDesocupadas);
                }
            }       

           

            return ListadasOupadas;
            
        }

        public string PutRegistrarVaga(int id)
        {


            VagasOcupadas[1].VerOcupacao = true;
            return "vaga ocupada";

        }


    }
}