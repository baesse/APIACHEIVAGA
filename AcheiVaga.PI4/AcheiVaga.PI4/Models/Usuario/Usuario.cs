using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace AcheiVaga.PI4.Models.Usuario
{
    public class Usuario
    {
        public ObjectId _id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string PlacaCarro { get; set; }
        public string pontuacao { get; set; }
        public Endereco Endereco { get; set; }

        public Usuario(string NomeUsuario, string Senha, string PlacaCarro, string pontuacao)
        {
            this.NomeUsuario = NomeUsuario;
            this.Senha = Senha;
            this.PlacaCarro = PlacaCarro;
            this.pontuacao = pontuacao;
            Endereco = new Endereco();
        }

        public Usuario()
        {
            
        }



        public void InserirUsuario(Usuario usuario)
        {
            var Cliente = new MongoClient("mongodb://localhost:27017");
            var DataBase = Cliente.GetDatabase("DBacheivaga");
            IMongoCollection<Usuario> ColecaoUsuario = DataBase.GetCollection<Usuario>("Cad_Usuario");
            ColecaoUsuario.InsertOne(usuario);

        }

        public List<Usuario> ListaCadastro()
        {
            string json = "";

            var Cliente = new MongoClient("mongodb://localhost:27017");
            var DataBase = Cliente.GetDatabase("DBacheivaga");
            IMongoCollection<Usuario> ColecaoUsuario = DataBase.GetCollection<Usuario>("Cad_Usuario");
            var filtro = Builders<Usuario>.Filter.Empty;
            var listausuario = ColecaoUsuario.Find<Usuario>(filtro).ToList();
            var Jsonusuario = JsonConvert.DeserializeObject<List<Usuario>>(json);
            Jsonusuario = new List<Usuario>();
            foreach(Usuario usuario in listausuario)
            {
                Usuario usu = new Usuario(usuario.NomeUsuario, usuario.Senha, usuario.PlacaCarro, usuario.pontuacao);
                Jsonusuario.Add(usu);
            }

           // var jsonserializado = JsonConvert.SerializeObject(Jsonusuario);
            return Jsonusuario;
        }
    }
}