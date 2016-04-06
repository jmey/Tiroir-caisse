using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiroirCaisse.Entities
{
    public class Vente
    {
        public int Id { get; private set; }
        public float PrixTotal { get; private set; }
        public Client Client { get; private set; }
        public Vendeur Vendeur { get; private set; }
        public List<Produit> ListProduit { get; private set; }
        public List<Prestation> ListPrestation { get; private set; }
        public DateTime DatePaiement { get; private set; }
        public string TypePaiement { get; private set; }

        public Vente(int id, float prixTotal, Client client, Vendeur vendeur, List<Produit> listProduit, List<Prestation> listPrestation, string type, DateTime _date)
        {
            Id = id;
            PrixTotal = prixTotal;
            Client = client;
            Vendeur = vendeur;
            ListProduit = listProduit;
            ListPrestation = listPrestation;
            DatePaiement = _date;
            TypePaiement = type;
        }

        public Vente(float prixTotal, Client client, Vendeur vendeur, List<Produit> listProduit, List<Prestation> listPrestation, string type, DateTime _date)
        {
            Id = -1;
            PrixTotal = prixTotal;
            Client = client;
            Vendeur = vendeur;
            ListProduit = listProduit;
            ListPrestation = listPrestation;
            DatePaiement = _date;
            TypePaiement = type;
        }
    }
}
