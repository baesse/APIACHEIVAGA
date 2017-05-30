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
            this.lojasdistancia = new List<LojaMapa>();
            for (int i = 1; i < 6; i++)
            {               

                this.lojasdistancia.Add(new LojaMapa(i, i * 10, i));
               

            }
            
        }

       
    }
}