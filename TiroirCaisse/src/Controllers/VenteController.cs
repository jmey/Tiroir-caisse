using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
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
    }
}
