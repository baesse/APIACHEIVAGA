using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models.Mall
{
    public class Loja
    {
        public String nomedaloja { get; set; }
        public int Codigodopiso  { get; set; }

      

        public Loja(String nome,int codigo)
        {
            this.nomedaloja = nome;
            codigo = codigo + 1;

            
        }

       
    }
}