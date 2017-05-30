using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcheiVaga.PI4.Models.Mall
{
    public class LojaMapa
    {

        public int codigoloja { get; set; }
        public int DistanciaLoja { get; set; }
        public int CodigodoPiso { get; set; }

        public LojaMapa(int codigoloja,int DistanciaLoja,int CodigodoPiso)
        {
            this.CodigodoPiso = CodigodoPiso;
            this.DistanciaLoja = DistanciaLoja;
            this.codigoloja = codigoloja;

        }
    }
}