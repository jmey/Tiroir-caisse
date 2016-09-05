using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Entities
{
    public class Element
    {
        public int Id { get; set; }
        public string Nom { get;  set; }
        public float PrixTTC { get; set; }
        public string Type { get;  set; }
    }
}
