using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public DateTime DateArrivee { get;  private set; }
        public string NumeroFixe { get; private set; }
        public string NumeroPortable { get; private set; }

        public Client(int id, string nom, string prenom, DateTime dateArrivee, string numeroFixe, string numeroPortable)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateArrivee = dateArrivee;
            NumeroFixe = numeroFixe;
            NumeroPortable = numeroPortable;
        }
        public Client(string nom, string prenom, DateTime dateArrivee, string numeroFixe, string numeroPortable)
        {
            Id = -1;
            Nom = nom;
            Prenom = prenom;
            DateArrivee = dateArrivee;
            NumeroFixe = numeroFixe;
            NumeroPortable = numeroPortable;
        }
        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
