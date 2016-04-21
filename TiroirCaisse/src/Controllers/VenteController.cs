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
    class VenteController : Controller
    {
        private ObjectBddTransition transition { get; set; }
        public VenteController()
        {
            transition = new ObjectBddTransition();
        }

        public List<Vente> getAllVentes()
        {
            List<Vente> resultat = transition.getAllVentesBy("");
            return resultat;
        }

        public int ajouterVente(Vente vente)
        {
            int res = transition.addVente(vente);
            return res;
        }

        public int supprimerVente(Vente vente)
        {
            int res = transition.deleteVenteBy("id=" + vente.Id);
            return res;
        }

        public List<Vendeur> getAllVendeurs()
        {
            List<Vendeur> resultat = transition.getAllVendeursBy("");
            return resultat;
        }

        public List<Client> getAllClients()
        {
            List<Client> resultat = transition.getAllClientsBy("");
            return resultat;
        }

        public List<Produit> getAllProduits()
        {
            List<Produit> resultat = transition.getAllProduitsBy("");
            return resultat;
        }

        public List<Prestation> getAllPrestations()
        {
            List<Prestation> resultat = transition.getAllPrestationsBy("");
            return resultat;
        }
        public List<FamilleProduit> getAllFamille()
        {
            List<FamilleProduit> resultat = transition.getAllFamilleProduitBy("");
            return resultat;
        }
        public List<CategoriePrestation> getAllCategoriePrestation()
        {
            List<CategoriePrestation> resultat = transition.getAllCategoriePrestationBy("");
            return resultat;
        }
        public List<CategorieProduit> getAllCategoriePoduit()
        {
            List<CategorieProduit> resultat = transition.getAllCategorieProduitBy("");
            return resultat;
        }

        public List<Prestation> getPrestationByCategorie(CategoriePrestation selectedCategoriePrestation)
        {
            List<Prestation> resultat = transition.getAllPrestationsBy("id_categorie_prestation=" + selectedCategoriePrestation.Id);
            return resultat;
        }
        public List<Produit> getProduitByCategorie(CategorieProduit selectedCategorieProduit)
        {
            List<Produit> resultat = transition.getAllProduitsBy("id_categorie_produit=" + selectedCategorieProduit.Id);
            return resultat;
        }
        public List<Produit> getProduitByFamille(FamilleProduit selectedFamilleProduit)
        {
            List<Produit> res = new List<Produit>();
            List<CategorieProduit> listCategorie = transition.getAllCategorieProduitBy("id_famille_produit=" + selectedFamilleProduit.Id);
            foreach(CategorieProduit categorie in listCategorie)
            {
                List<Produit> currentRes = getProduitByCategorie(categorie);
                res.AddRange(currentRes);
            }
            return res;
        }
        public List<CategorieProduit> getCategorieProduitByFamille(FamilleProduit selectedFamilleProduit)
        {
            List<CategorieProduit> resultat = transition.getAllCategorieProduitBy("id_famille_produit=" + selectedFamilleProduit.Id);
            return resultat;
        }
    }
}
