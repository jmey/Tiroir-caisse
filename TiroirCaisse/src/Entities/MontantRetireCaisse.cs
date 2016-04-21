using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.src.Entities
{
    public class MontantRetireCaisse
    {      
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public float Montant { get; private set; }
        public string Type { get; private set; }
        public MontantRetireCaisse(int _id, DateTime _date, float _montant, string _type)
        {
            Id = _id;
            Date = _date;
            Montant = _montant;
            Type = _type;
        }
        public MontantRetireCaisse(DateTime _date, float _montant, string _type)
        {
            Id = -1;
            Date = _date;
            Montant = _montant;
            Type = _type;
        }

    }
}
