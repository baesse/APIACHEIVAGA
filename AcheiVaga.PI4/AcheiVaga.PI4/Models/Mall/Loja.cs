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
        public List<LojaMapa> lojasdistancia { get; set; }

      

        public Loja(String nome,int codigo)
        {
            this.nomedaloja = nome;
            LojaMapa rota = new LojaMapa();
            this.lojasdistancia = new List<LojaMapa>();

            rota.codigoloja = codigo;
            rota.DistanciaLoja = codigo * 10;
            lojasdistancia.Add(rota);
        }

       
    }
}