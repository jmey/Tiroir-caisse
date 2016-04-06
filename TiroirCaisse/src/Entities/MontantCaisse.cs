using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Entities
{
    public abstract class MontantCaisse
    {      
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public float MontantCheque { get; private set; }
        public float MontantEspece { get; private set; }
        public float MontantCb { get; set; }

        public MontantCaisse(int _id, DateTime _date, float _montantCheque, float _montantEspece, float _montantCb)
        {
            Id = _id;
            Date = _date;
            MontantCheque = _montantCheque;
            MontantEspece = _montantEspece;
            MontantCb = _montantCb;
        }
        public MontantCaisse(DateTime _date, float _montantCheque, float _montantEspece, float _montantCb)
        {
            Id = -1;
            Date = _date;
            MontantCheque = _montantCheque;
            MontantEspece = _montantEspece;
            MontantCb = _montantCb;
        }

    }
}
