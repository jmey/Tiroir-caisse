using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.src.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    public class ProduitController
    {
        private ObjectBddTransition transition { get; set; }
        public ProduitController()
        {
            transition = new ObjectBddTransition();
        }

        public List<Produit> getAllProduits()
        {
            List<Produit> resultat = transition.getAllProduitsBy("");
            return resultat;
        }
        public int ajouterProduit(Produit produit)
        {
            int res = transition.addProduit(produit);
            return res;
        }
        public int supprimerProduit(Produit produit)
        {
            int res = transition.deleteProduitBy("id=" + produit.Id);
            return res;
        }
        public List<CategorieProduit> getAllCategorieProduit()
        {
            List<CategorieProduit> listCategorie = transition.getAllCategorieProduitBy("");
            return listCategorie;
        }
        public int ajouterCategorieProduit(CategorieProduit categorie)
        {
            int res = transition.addCategorieProduit(categorie);
            return res;
        }
        public int supprimerCategorieProduit(CategorieProduit categorie)
        {
            int res = transition.deleteCategorieProduitBy("id=" + categorie.Id);
            return res;
        }
    }

}
