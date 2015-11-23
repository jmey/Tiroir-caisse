using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    class VenteController
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
    }
}
