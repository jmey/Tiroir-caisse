using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Entities
{
    public class Item
    {
        public int Id { get; protected set; }
        public string Nom { get; protected set; }
        public float PrixTTC { get; protected set; }
        public string Type { get; protected set; }
    }
}
