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

namespace AcheiVaga.PI4.Models.Mall
{
    public class Mall
    {
        public ObjectId _id { get; set; }
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
                foreach(Loja loja in SHOP.LOJAS)
                {
                    if(loja.nomedaloja.Equals(nomeloja))
                    listlojas.Add(loja);


                }

                foreach(Piso Andar in SHOP.EstacionamentoShooping.Andares)
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
                                listvagas.Add(vagas);

                            }
                    }
              }

            }


            int i = 10;



            foreach (Vaga melhorvaga in listvagas)
            {
                if (melhorvaga.Codigovaga < i && melhorvaga.VerOcupacao == false)
                {
                    return melhorvaga;

                }else
                {
                    i++;
                }
               
            }
            return null;
        }
                






        



        //public static string ConvertListForJson(List<Mall> list)
        //{
        //    try
        //    {
        //        List<Mall> MALL = new List<Mall>();

        //        foreach (Mall vaga in list)
        //        {
        //            MALL.Add(vaga);

        //        }

        //        //var JsonSerializado = JsonConvert.(MALL);
        //        return JsonSerializado;

        //    }
        //    catch (Exception e)
        //    {
        //        e.ToString();
        //        return "";

        //    }
        }
    }
