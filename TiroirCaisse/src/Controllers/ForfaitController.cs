using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    public class ForfaitController : Controller
    {
        private ObjectBddTransition transition { get; set; }
        public ForfaitController()
        {
            transition = new ObjectBddTransition();
        }

        public List<Forfait> getAllForfaits()
        {
            List<Forfait> resultat = transition.getAllForfaitsBy("");
            return resultat;
        }
        public int ajouterForfait(Forfait forfait)
        {
            int res = transition.addForfait(forfait);
            return res;
        }
        public int supprimerForfait(Forfait forfait)
        {
            int res = transition.deleteForfaitBy("id=" + forfait.Id);
            return res;
        }
    }
}
