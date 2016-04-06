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
        public FamilleProduit Famille { get; set; }

        public CategorieProduit(int id, string nom, FamilleProduit famille)
        {
            Id = id;
            Nom = nom;
            Famille = famille;
        }

        public CategorieProduit(string nom, FamilleProduit famille)
        {
            Id = -1;
            Nom = nom;
            Famille = famille;
        }
        public override string ToString()
        {
            return Nom;
        }
    }
}
