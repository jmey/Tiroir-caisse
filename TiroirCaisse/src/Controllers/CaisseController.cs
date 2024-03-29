﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.src.Entities;
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
        public float getMontantRecuBetweenDate(string type, DateTime _dateDebut, DateTime _dateFin)
        {
            float res = 0;
            List<Vente> listVente = transition.getAllVentesBy("moyen_paiement = '" + type +"'");

            foreach(Vente v in listVente)
            {
                if (_dateDebut.CompareTo(v.DatePaiement) <= 0 && _dateFin.CompareTo(v.DatePaiement) >= 0)
                {
                    res += v.PrixTotal;
                }
            }
            return res;
        }

        public float getMontantRetireBetweenDate(string type, DateTime _dateDebut, DateTime _dateFin)
        {
            float res = 0;
            List <MontantRetireCaisse> listMontantRetire = transition.getAllMontantsCaisseBy("type='" + type + "'");
            foreach(MontantRetireCaisse montant in listMontantRetire)
            {
                if (_dateDebut.CompareTo(montant.Date) <= 0 && _dateFin.CompareTo(montant.Date) >= 0)
                {
                    res += montant.Montant;
                }
            }
            return res;
        }
        public float getMontantPrit(string type)
        {
            return 0;
        }

        public int addRetirementCaisse(MontantRetireCaisse montant)
        {
            int resultat;
            resultat = transition.addMontantCaisse(montant);
            return resultat;
        }

        public int supprimerMontantRetirerCaisse(MontantRetireCaisse selectedMontant)
        {
            return transition.deleteMontantCaisseBy("id=" + selectedMontant.Id);
        }
        /*public float getMontantTotal(string type)
        {
            return getMontantRecu(type) - getMontantPrit(type);
        }*/

        public List<MontantRetireCaisse> getAllMontantRetire()
        {
            List<MontantRetireCaisse> res = transition.getAllMontantsCaisseBy("");
            return res;
        }
    }
}
