using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace legoApp2.Models
{
    public class Legosett
    {
        //Atributter(+ tilgangsmetoder hente verdier ut )
        
        public String Navn { get; set; }
        public int AntallDeler { get; set; }
        public double Pris { get; set; }
        public String Bilde { get; set; }
    }
}