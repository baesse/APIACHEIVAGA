using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace AcheiVaga.PI4.Models
{
    public  class Vaga
    {

        public ObjectId _id { get; set; }  
        public int codigovaga { get; set;}                  
        public bool VerOcupacao { get; set; }
        public int IdEstacionamento { get; set; }

        public static   List<Vaga> VagasOcupadas = new List<Vaga>();


        public Vaga(int codigovaga,Boolean Verop, int Idestaciona){

            this.VerOcupacao = Verop;
            this.IdEstacionamento = Idestaciona;
            this.codigovaga = codigovaga;


            }

        public Vaga()
        {
            



        }



        public string RetornoVagasJson()
        {
            string json = "";
            var Vagas = JsonConvert.DeserializeObject<List<Models.Vaga>>(json);
            Vagas = new List<Vaga>();
            Vaga vaga0 = new Vaga(1,true,0);
            Vagas.Add(vaga0);
            var Json_Serializado = JsonConvert.SerializeObject(Vagas);
            return Json_Serializado;
        }

        public bool CadastrodeVaga()
        {
                  
              
                IMongoCollection<Vaga> vaganova = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
                Vaga vagacadastrar = new Vaga( 2,true, 5);
                vaganova.InsertOne(vagacadastrar);
                return true;

        }

        public string ListadeVagas()
        {         



            IMongoCollection<Vaga> vagas = Banco.Conexao.DataBase.GetCollection<Vaga>("Vagas");
            var filtro = Builders<Vaga>.Filter.Empty;
            var pessoas = vagas.Find<Vaga>(filtro).ToList();
            string json = "";
            var Jsonvagas = JsonConvert.DeserializeObject<List<Models.Vaga>>(json);
            Jsonvagas = new List<Vaga>();

            foreach(Vaga vaga in pessoas)
            {
                Jsonvagas.Add(vaga);

            }

            var Json_Serializado = JsonConvert.SerializeObject(Jsonvagas);
            return Json_Serializado;

        }


    }
}