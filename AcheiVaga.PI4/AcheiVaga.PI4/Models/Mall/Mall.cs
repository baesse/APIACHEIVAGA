using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models.Mall
{
    public class Mall
    {
       
        public String NomeShoping { get; set; }
        public Estacionamento.Estacionamento EstacionamentoShooping { get; set; }
        public List<Loja> LOJAS { get; set; }
       
        


        public Mall(Estacionamento.Estacionamento ESTACIONAMENTO,List<Loja>lojasnovas)
        {
            this.EstacionamentoShooping = ESTACIONAMENTO;
            this.NomeShoping = "Minas Shoping";

            this.LOJAS = new List<Loja>();

            foreach(Loja lojanova in lojasnovas)
            {
                this.LOJAS.Add(lojanova);
            }


          
           
        }


        public void InseriShooping(Mall SHOP)
        {
            IMongoCollection<Mall> Novoshoping = Banco.Conexao.DataBase.GetCollection<Mall>("Mall");
            Novoshoping.InsertOne(SHOP);
        }
    }
}