using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.Entities
{
   public  class Produit
    {
        public int Id { get; private set; }
        public string Nom { get; private set; }
        public string Type { get; private set; }
        public int NombreStock { get; private set; }
        public int SeuilAlerte { get; private set; }
        public string Fournisseur { get; private set; }
        public string ReferenceFournisseur { get; private set; }
        public float Prix { get; private set; }
        public float PrixFournisseur { get; private set; }
        public CategorieProduit Categorie { get; private set; }

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
            Prix = prix;
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
            Prix = prix;
            PrixFournisseur = prixFournisseur;
            Categorie = categorie;
        }

    }
}
