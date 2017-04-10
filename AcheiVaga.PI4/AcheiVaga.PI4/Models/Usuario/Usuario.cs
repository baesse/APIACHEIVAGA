﻿using MongoDB.Bson;
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
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }



        public Usuario(string NomeUsuario, string Senha, string PlacaCarro, string pontuacao,string email)
        {
            this.NomeUsuario = NomeUsuario;
            this.Senha = Senha;
            this.PlacaCarro = PlacaCarro;
            this.pontuacao = pontuacao;
            this.Email = email;
            this.Latitude = "";
            this.Longitude = "";

      
        }

        public Usuario()
        {
            
        }



        public void InserirUsuario(Usuario usuario)
        {           
            IMongoCollection<Usuario> ColecaoUsuario = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
            ColecaoUsuario.InsertOne(usuario);
        }
























        //public string ListaCadastro()
        //{
        //    string json = "";
        //    IMongoCollection<Usuario> ColecaoUsuario = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
        //    var filtro = Builders<Usuario>.Filter.Empty;
        //    var listausuario = ColecaoUsuario.Find<Usuario>(filtro).ToList();
        //    var Jsonusuario = JsonConvert.DeserializeObject<List<Usuario>>(json);
        //    Jsonusuario = new List<Usuario>();
        //    foreach (Usuario usuario in listausuario)
        //    {
        //        Usuario usu = new Usuario(usuario.NomeUsuario, usuario.Senha, usuario.PlacaCarro, usuario.pontuacao,"");
        //        Jsonusuario.Add(usu);
        //    }
        //    var jsonserializado = JsonConvert.SerializeObject(Jsonusuario);
        //    return jsonserializado;



        //}


        //public string GetLogin(string placa,string senha)
        //{
        //    Usuario retorno = new Usuario();          
        //    var filtro = Builders<Usuario>.Filter.Where(p => p.PlacaCarro==placa);
        //    IMongoCollection<Usuario> colecao = Banco.Conexao.DataBase.GetCollection<Usuario>("Cad_Usuario");
        //    var query = from e in colecao.AsQueryable<Usuario>() where e.NomeUsuario == "Igor" select e;
        //    foreach(Usuario us in query)
        //    {
        //        if(us.PlacaCarro.Equals(placa) &&  us.Senha.Equals(senha))

        //        retorno.NomeUsuario = us.NomeUsuario;
        //        retorno.PlacaCarro = us.PlacaCarro;
        //        retorno.pontuacao = us.pontuacao;


        //    }
        //    return retorno.ToJson();



        //}
    }
}