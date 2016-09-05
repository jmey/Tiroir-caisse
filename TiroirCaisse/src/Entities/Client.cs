using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get;  set; }
        public string Prenom { get;  set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NumeroFixe { get; set; }
        public string NumeroPortable { get;  set; }
        public float Fidelite { get; set; }
        public string Adresse { get; set; }
        public string FullName
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }
        public string Commentaire { get; set; }
        public string Mail { get; set; }

        public Client(int id, string nom, string prenom, DateTime dateArrivee, string numeroFixe, string numeroPortable, float fidelite, DateTime dateNaissance, string adresse, string commentaire, string mail)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateArrivee = dateArrivee;
            NumeroFixe = numeroFixe;
            NumeroPortable = numeroPortable;
            Fidelite = fidelite;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Commentaire = commentaire;
            Mail = mail;
        }

        public Client(string nom, string prenom, DateTime dateArrivee, string numeroFixe, string numeroPortable, float fidelite, DateTime dateNaissance, string adresse, string commentaire, string mail)
        {
            Id = -1;
            Nom = nom;
            Prenom = prenom;
            DateArrivee = dateArrivee;
            NumeroFixe = numeroFixe;
            NumeroPortable = numeroPortable;
            Fidelite = fidelite;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Commentaire = commentaire;
            Mail = mail;
        }
        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
