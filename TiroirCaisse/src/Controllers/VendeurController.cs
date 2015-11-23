using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    public class VendeurController
    {
        private ObjectBddTransition transition { get; set; }
        public VendeurController()
        {
            transition = new ObjectBddTransition();
        }

        public List<Vendeur> getAllVendeurs()
        {
            List<Vendeur> resultat = transition.getAllVendeursBy("");
            return resultat;
        }
        public int ajouterVendeur(Vendeur vendeur)
        {
            int res = transition.addVendeur(vendeur);
            return res;
        }
        public int supprimerVendeur(Vendeur vendeur)
        {
            int res = transition.deleteVendeurBy("id=" + vendeur.Id);
            return res;
        }
    }
}
