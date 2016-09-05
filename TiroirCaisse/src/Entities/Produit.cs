using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.Entities
{
   public  class Produit : Element
    {

        public int NombreStock { get; set; }
        public int SeuilAlerte { get; set; }
        public string Fournisseur { get; set; }
        public string ReferenceFournisseur { get; set; }
        public float PrixFournisseur { get; set; }
        public CategorieProduit Categorie { get; set; }

        public Produit(int id, string nom, string type, int nombreStock, int seuilAlerte, string fournisseur, string referenceFournisseur,
            float prix, float prixFournisseur, CategorieProduit categorie)
        {
            Id = id;
            Nom = nom;
            Type = type;
            NombreStock = nombreStock;
            SeuilAlerte = seuilAlerte;
            Fournisseur = fournisseur;
            ReferenceFournisseur = referenceFournisseur;
            PrixTTC = prix;
            PrixFournisseur = prixFournisseur;
            Categorie = categorie;
        }

        public Produit(string nom, string type, int nombreStock, int seuilAlerte, string fournisseur, string referenceFournisseur,
            float prix, float prixFournisseur, CategorieProduit categorie)
        {
            Id = -1;
            Nom = nom;
            Type = type;
            NombreStock = nombreStock;
            SeuilAlerte = seuilAlerte;
            Fournisseur = fournisseur;
            ReferenceFournisseur = referenceFournisseur;
            PrixTTC = prix;
            PrixFournisseur = prixFournisseur;
            Categorie = categorie;
        }
        public override string ToString()
        {
            return Nom;
        }
    }
}
