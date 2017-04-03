using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models.Usuario
{
    public class Usuario
    {
        public ObjectId _id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string PlacaCarro { get; set; }
        public string pontuacao { get; set; }


    }
}