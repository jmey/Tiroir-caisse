using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.Entities
{
    public class Forfait
    {
        public int Id { get; private set; }
        public string Nom { get; private set; }
        public float PrixTTC { get; private set; }

        public Forfait(int id, string nom, float prixTTC)
        {
            Id = id;
            Nom = nom;
            PrixTTC = prixTTC;
        }
        public Forfait(string nom, float prixTTC)
        {
            Id = -1;
            Nom = nom;
            PrixTTC = prixTTC;
        }
        public override string ToString()
        {
            return Nom;
        }


    }

}
