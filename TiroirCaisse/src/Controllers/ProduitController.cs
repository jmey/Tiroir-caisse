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
    public class ProduitController : Controller
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
        public int decrementStockProduit(Produit produit)
        {
            int res = transition.updateProduit("nombre_stock = nombre_stock-1", "id=" + produit.Id );
            return res;
        }
        public List<FamilleProduit> getAllFamilleProduit()
        {
            List<FamilleProduit> res = transition.getAllFamilleProduitBy("");
            return res;
        }
        public int addFamilleProduit(FamilleProduit famille)
        {
            int res = transition.addFamilleProduit(famille);
            return res;
        }
        public int supprimerFamilleProduit(FamilleProduit famille)
        {
            int res = transition.deleteFamilleProduitBy("id=" + famille.Id);
            return res;
        }
        public List<CategorieProduit> getAllCategorieProduitByFamille(FamilleProduit famille)
        {
            List<CategorieProduit> listCategorie = null;
            listCategorie = transition.getAllCategorieProduitBy("id_famille_produit=" + famille.Id);
            return listCategorie;
        }
        public List<Produit> getProduitNecessaire()
        {
            List<Produit> res;
            res = transition.getAllProduitsBy("nombre_stock<=seuil_alerte");
            return res;
        }

        public bool updateProduit(Produit produit)
        {
            return transition.updateProduit(produit);
        }
    }

}
