﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace AcheiVaga.PI4.Models
{
    public class Vaga
    {

        public ObjectId _id { get; set; }
        public int Codigovaga { get; set; }
        public bool VerOcupacao { get; set; }
        public int AndarVaga { get; set; }
        public string TipoVaga { get; set; }
        public int CodigoSensor { get; set; }


        public static List<Vaga> VagasOcupadas = new List<Vaga>();


        public Vaga(int codigovaga, Boolean Verop, int AndarVaga, string TipoVaga, int CodigoSensor)
        {

            this.VerOcupacao = Verop;
            this.TipoVaga = TipoVaga;
            this.Codigovaga = codigovaga;
            this.CodigoSensor = CodigoSensor;
            this.AndarVaga = AndarVaga;


        }

        public Vaga()
        {




        }



        public string RetornoVagasJson()
        {

            List<Vaga> VAGAS = new List<Vaga>();
            IMongoCollection<Vaga> Vagas = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var filtro = Builders<Vaga>.Filter.Empty;
            var VagasLista = Vagas.Find<Vaga>(filtro).ToList();
            return ConvertListForJson(VagasLista);



        }


        public string RetornoVagaJsonByid(int id)
        {

            List<Vaga> VAGAS = new List<Vaga>();
            IMongoCollection<Vaga> Vagas = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var filtro = Builders<Vaga>.Filter.Where(p => p.Codigovaga == id);
            var VagasLista = Vagas.Find<Vaga>(filtro).ToList();
            return ConvertListForJson(VagasLista);


        }


        public string RetornoVagaJsonByOcupadas()
        {
            List<Vaga> VAGAS = new List<Vaga>();
            IMongoCollection<Vaga> Vagas = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var filtro = Builders<Vaga>.Filter.Where(p => p.VerOcupacao == true);
            var VagasLista = Vagas.Find<Vaga>(filtro).ToList();
            return ConvertListForJson(VagasLista);


        }


        public string RetornoVagaJsonByDesocupadas()
        {


            IMongoCollection<Vaga> Vagas = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var filtro = Builders<Vaga>.Filter.Where(p => p.VerOcupacao == false);
            var VagasLista = Vagas.Find<Vaga>(filtro).ToList();
            return ConvertListForJson(VagasLista);


        }





        public bool CadastrodeVaga(int QuantidadeDeVagasExistentes, int Andar)
        {
            try
            {

                IMongoCollection<Vaga> vaganova = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
                for (int i = 0; i < QuantidadeDeVagasExistentes; i++)
                {

                    Vaga Vaga = new Vaga(i + 1, false, Andar, "Descoberta", i + 1);


                    vaganova.InsertOne(Vaga);
                }
                return true;

            }
            catch (MongoClientException e)
            {
                e.ToString();
                return false;
            }

        }


        public void SetVagaCobertaIntervalo(int IntervaloIni, int IntervaloFinal)
        {
            IMongoCollection<Vaga> VagasSet = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var Filtro = Builders<Vaga>.Filter.Where(p => p.Codigovaga >= IntervaloIni && p.Codigovaga <= IntervaloFinal);
            var update = Builders<Vaga>.Update.Set("TipoVaga", "Coberta");
            VagasSet.UpdateMany(Filtro, update);

        }

        public void SetVagaCobertaIntervaloPorID(int idvaga)
        {
            IMongoCollection<Vaga> VagasSet = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var Filtro = Builders<Vaga>.Filter.Where(p => p.Codigovaga == idvaga);
            var update = Builders<Vaga>.Update.Set("Descoberta", "Coberta");
            VagasSet.UpdateMany(Filtro, update);

        }

        public void SetVagaOcupada(int idvaga)
        {
            IMongoCollection<Vaga> VagasSet = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var Filtro = Builders<Vaga>.Filter.Where(p => p.Codigovaga == idvaga);
            var update = Builders<Vaga>.Update.Set("VerOcupacao", "true");
            VagasSet.UpdateMany(Filtro, update);

        }


        public string ConvertListForJson(List<Vaga> list)
        {
            List<Vaga> VAGAS = new List<Vaga>();

            foreach (Vaga vaga in list)
            {
                VAGAS.Add(vaga);

            }

            var JsonSerializado = JsonConvert.SerializeObject(VAGAS);
            return JsonSerializado;

        }




    }
}