using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models.Usuario
{
    public class Endereco
    {
        public ObjectId _Id { get; set; }
        public string Rua { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }


        public Endereco(string rua, string numero, string cep, string bairro, string complemento)
        {
            this.Rua = rua;
            this.numero = numero;
            this.cep = cep;
            this.bairro = bairro;
            this.complemento = complemento;

        }

        public Endereco()
        {
           

        }

    }
}