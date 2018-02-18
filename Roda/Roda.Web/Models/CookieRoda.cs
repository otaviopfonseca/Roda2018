using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roda.Web.Models
{
    public class CookieRoda
    {
        public int IDProcessador { get; set; }
        public int IDPlacaVideo { get; set; }
        public double Memoria { get; set; }
        public double HD { get; set; }

        public CookieRoda() { }

        public CookieRoda(int idProcessador, int idPlacaVideo, double memoria, double hd)
        {
            this.IDProcessador = idProcessador;
            this.IDPlacaVideo = idPlacaVideo;
            this.Memoria = memoria;
            this.HD = hd;
        }

        public CookieRoda(string valorConcatenado)
        {
            string[] valores = valorConcatenado.Split('_');
            this.IDProcessador = Convert.ToInt32(valores[0]);
            this.IDPlacaVideo = Convert.ToInt32(valores[1]);
            this.Memoria = Convert.ToDouble(valores[2]);
            this.HD = Convert.ToDouble(valores[3]);
        }

        public override string ToString()
        {
            return String.Format("{0}_{1}_{2}_{3}", IDProcessador, IDPlacaVideo, Memoria, HD);
        }
    }
}