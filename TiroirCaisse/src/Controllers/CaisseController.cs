using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    public class CaisseController : Controller
    {
        private ObjectBddTransition transition { get; set; }
        public CaisseController()
        {
            transition = new ObjectBddTransition();
        }
        public float getMontantRecu(string type)
        {
            float res = 0;
            List<Vente> listVente = transition.getAllVentesBy("type_paiement = " + type);
            foreach(Vente v in listVente)
            {
                res += v.PrixTotal;
            }
            return res;


        }
        public float getMontantPrit(string type)
        {
            return 0;
        }
        public float getMontantTotal(string type)
        {
            return getMontantRecu(type) - getMontantPrit(type);
        }
    }
}
