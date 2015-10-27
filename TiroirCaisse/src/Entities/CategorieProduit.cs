using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Entities
{
    public class CategorieProduit
    {
        public int Id { get; private set; }
        public string Nom { get; private set; }

        public CategorieProduit(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public CategorieProduit(string nom)
        {
            Id = -1;
            Nom = nom;
        }
    }
}
