using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.Entities
{
    public class Vendeur
    {
        public int Id { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string TypeContrat { get; private set; }

        public Vendeur(int id, string nom, string prenom, string typeContrat)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            TypeContrat = typeContrat;
        }

        public Vendeur(string nom, string prenom, string typeContrat)
        {
            Id = -1;
            Nom = nom;
            Prenom = prenom;
            TypeContrat = typeContrat;
        }
        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
