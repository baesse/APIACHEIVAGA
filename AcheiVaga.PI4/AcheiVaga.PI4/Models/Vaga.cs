using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AcheiVaga.PI4.Models
{
    public  class Vaga
    {

        public ObjectId IdVaga { get; set; }

        public string MongoId
        {
            get { return IdVaga.ToString(); }
            set { IdVaga = ObjectId.Parse(value); }
        }

       

       

        public bool VerOcupacao { get; set; }
        public int IdEstacionamento { get; set; }
        public static   List<Vaga> VagasOcupadas = new List<Vaga>();
        

       

       
        public string RetornoVagasJson()
        {
            string json = "";
            var Vagas = JsonConvert.DeserializeObject<List<Models.Vaga>>(json);
            Vagas = new List<Vaga>();
           //Models.Vaga vaga0 = new Vaga(1,true,0);
           // Vagas.Add(vaga0);
            var Json_Serializado = JsonConvert.SerializeObject(Vagas);
            return Json_Serializado;
        }

        public bool CadastrodeVaga()
        {
            try
            {
                var Cliente = new MongoClient("mongodb://localhost:27017");
                var database = Cliente.GetDatabase("DBacheivaga");
                IMongoCollection<Vaga> vaganova = database.GetCollection<Vaga>("Vagas");
               // Vaga vagacadastrar = new Vaga(1, true, 5);
                //vaganova.InsertOne(vagacadastrar);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public string ListadeVagas()
        {

            var Cliente = new MongoClient("mongodb://localhost:27017");
            var database = Cliente.GetDatabase("DBacheivaga");
            IMongoCollection<Vaga> vagas = database.GetCollection<Vaga>("Vagas");
            var filtro = Builders<Models.Vaga>.Filter.Empty;
            var pessoas = vagas.Find<Vaga>(filtro).ToList();

            string json = "";
            var Jsonvagas = JsonConvert.DeserializeObject<List<Models.Vaga>>(json);
            Jsonvagas = new List<Vaga>();

            foreach(Models.Vaga vaga in pessoas)
            {
                Jsonvagas.Add(vaga);

            }

            var Json_Serializado = JsonConvert.SerializeObject(vagas);
            return Json_Serializado;

        }


    }
}