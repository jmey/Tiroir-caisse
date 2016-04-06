using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TiroirCaisse.Entities;
using TiroirCaisse.src.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    public class PrestationController : Controller
    {
        private ObjectBddTransition transition { get; set; }
        public PrestationController()
        {
            transition = new ObjectBddTransition();
        }

        public List<Prestation> getAllPrestations()
        {
            List<Prestation> resultat = transition.getAllPrestationsBy("");
            return resultat;
        }
        public int ajouterPrestation(Prestation prestation)
        {
            int res = transition.addPrestation(prestation);
            return res;
        }
        public int supprimerPrestation(Prestation prestation)
        {
            int res = transition.deletePrestationBy("id=" + prestation.Id);
            return res;
        }

        public List<CategoriePrestation> getAllCategoriePrestation()
        {
            List<CategoriePrestation> listCategorie = transition.getAllCategoriePrestationBy("");
            return listCategorie;
        }

        public int ajouterCategoriePrestation(CategoriePrestation categorie)
        {
            int res = transition.addCategoriePrestation(categorie);
            return res;
        }
        public int supprimerCategoriePrestation(CategoriePrestation categorie)
        {
            int res = transition.deleteCategorieProduitBy("id=" + categorie.Id);
            return res;
        }

    }
}
