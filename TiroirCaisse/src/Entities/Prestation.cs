using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.Entities
{
    public class Prestation
    {
        public int Id { get; private set; }
        public string Nom { get; private set; }
        public float PrixTTC { get; private set; }
        public string TypePrestation { get; private set; }
        public List<Forfait> ListForfait { get; private set; }
        public CategoriePrestation Categorie { get; private set; }

        public Prestation(int id, string nom, float prixTTC, string typePrestation, CategoriePrestation categorie, List<Forfait> listForfait )
        {
            Id = id;
            Nom = nom;
            PrixTTC = prixTTC;
            TypePrestation = typePrestation;
            Categorie = categorie;
            ListForfait = ListForfait;

        }

        public Prestation(string nom, float prixTTC, string typePrestation, CategoriePrestation categorie, List<Forfait> listForfait)
        {
            Id = -1;
            Nom = nom;
            PrixTTC = prixTTC;
            TypePrestation = typePrestation;
            Categorie = categorie;
            ListForfait = ListForfait;

        }
    }
}
