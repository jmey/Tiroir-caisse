using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.Entities
{
    public class Prestation : Item
    {

        public CategoriePrestation Categorie { get; private set; }

        public Prestation(int id, string nom, float prixTTC, string typePrestation, CategoriePrestation categorie)
        {
            Id = id;
            Nom = nom;
            PrixTTC = prixTTC;
            Type = typePrestation;
            Categorie = categorie;

        }

        public Prestation(string nom, float prixTTC, string typePrestation, CategoriePrestation categorie)
        {
            Id = -1;
            Nom = nom;
            PrixTTC = prixTTC;
            Type = typePrestation;
            Categorie = categorie;

        }
    }
}
