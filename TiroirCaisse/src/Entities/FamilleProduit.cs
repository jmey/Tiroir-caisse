using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Entities
{
    public class FamilleProduit
    {
        public int Id { get; private set; }
        public string Nom { get; private set; }

        public FamilleProduit(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public FamilleProduit(string nom)
        {
            Id = -1;
            Nom = nom;
        }

        public override string ToString()
        {
            return Nom;
        }

    }
}
