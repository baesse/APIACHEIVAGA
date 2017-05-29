using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;



namespace AcheiVaga.PI4.Models.Estacionamento
{
    public class Estacionamento
    {
       
       
        public string NomeEstacionamento { get; set; }      
        public List<Piso> Andares{get;set;}


        public Estacionamento(string Nome,List<Piso> Andares)
        {
            this.NomeEstacionamento = Nome;
            this.Andares = new List<Piso>();

            foreach(Piso piso in Andares)
            {
                this.Andares.Add(piso);
            }

                         
            
            
        }
        


       


    }
}