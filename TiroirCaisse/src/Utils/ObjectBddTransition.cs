using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.ExternAccess;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.Utils
{
    //TODO: Requête plus jolie en definissant les variables lignes après lignes
    public class ObjectBddTransition
    {
        private SQLiteAccess sqliteAccess { get; set; }
        public ObjectBddTransition()
        {
            sqliteAccess = SQLiteAccess.Instance;
        }

        #region  Fonctions liées à l'entité Client

        public List<Client> getAllClientsBy(string whereClause)
        {
            List<Client> listeClient = new List<Client>();
            string query = "SELECT * FROM client";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }
         
            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);

            while (dataReader != null && dataReader.Read())
            {
                TimeSpan ts;
                if (dataReader["date_arrivee"].ToString() != "")
                {
                    ts = new TimeSpan(long.Parse(dataReader["date_arrivee"].ToString()));
                }
                else
                {
                    ts = new TimeSpan(0);
                }
                listeClient.Add(new Client(int.Parse(dataReader["id"].ToString()), dataReader["nom"].ToString(), dataReader["prenom"].ToString(), Convert.ToDateTime(ts.ToString()), dataReader["telephone_fixe"].ToString(), dataReader["telephone_portable"].ToString()));
            }
            
            return listeClient;
        }
        
        public int deleteClientBy(string whereClause)
        {
            int resultat;
            int resfonction = 1;
            string query = "DELETE FROM client";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
                if(resultat == 0)
                {
                    resfonction = 0; 
                }
                else
                {
                    resfonction = 2;
                }
            }
      

            return resfonction;
        }

        public int addClient(Client client)
        {       
            string query = "INSERT INTO client('nom','prenom','date_arrivee', 'telephone_fixe', 'telephone_portable') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("'" + client.Nom + "'" + ",");
            stringBuilder.Append("'" + client.Prenom + "'" + ",");
            stringBuilder.Append("'" + client.DateArrivee.ToLongDateString() + "'" + ",");
            stringBuilder.Append("'" + client.NumeroFixe + "'" + ",");
            stringBuilder.Append("'" + client.NumeroPortable + "'" + ")");

            sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return 0;        
        }

        #endregion

        #region Fonctions liées à l'entité Forfait

        public List<Forfait> getAllForfaitsBy(string whereClause)
        {
            List<Forfait> listeForfait = new List<Forfait>();
            string query = "SELECT * FROM forfait f";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                listeForfait.Add(new Forfait(int.Parse(dataReader["id"].ToString()), dataReader["nom"].ToString(), float.Parse(dataReader["prix_ttc"].ToString())));
            }

            return listeForfait;
        }
      
        public int deleteForfaitBy(string whereClause)
        {
            int resultat;
            string query = "DELETE FROM forfait";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                sqliteAccess.ExecuteComandWOReturn(query);
                resultat = 0;
            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

        public int addForfait(Forfait forfait)
        {
            string query = "INSERT forfait('nom','prix_ttc) VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append(forfait.Nom + ",");
            stringBuilder.Append(forfait.PrixTTC);

            sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return 0;
        }

        #endregion

        #region Fonction liées à l'entité Prestation

        public List<Prestation> getAllPrestationsBy(string whereClause)
        {
            List<Prestation> listePrestation = new List<Prestation>();
            string query = "SELECT p.*, cp.nom AS categorie FROM prestation p INNER JOIN categorie_prestation cp ON p.id_categorie_prestation = cp.id";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }
            
            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                int idPrestation = int.Parse(dataReader["id"].ToString());
                int idCategoriePrestation = int.Parse(dataReader["id_categorie_prestation"].ToString());
                CategoriePrestation categoriePrestation = new CategoriePrestation(idCategoriePrestation, dataReader["categorie"].ToString());

                List<Forfait> listeForfait = getAllForfaitsBy("f.id = (SELECT id_forfait FROM forfait_prestation WHERE id = " + idPrestation + ")");
                listePrestation.Add(new Prestation(idPrestation, dataReader["nom"].ToString(), int.Parse(dataReader["prix_ttc"].ToString()),
                    dataReader["type_prestation"].ToString(), categoriePrestation, listeForfait
                    ));
            }

            return listePrestation;
        }

        public int deletePrestationtBy(string whereClause)
        {
            int resultat;
            string query = "DELETE FROM prestation";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                sqliteAccess.ExecuteComandWOReturn(query);
                resultat = 0;
            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

        public int addPrestation(Prestation prestation)
        {
            int resultat;
            string query = "INSERT prestation('nom','prix_ttc','type_prestation', id_categorie_prestation) VALUES(";
            if(prestation.Categorie.Id != -1)
            { 
                StringBuilder stringBuilder = new StringBuilder(query);
                stringBuilder.Append(prestation.Nom + ",");
                stringBuilder.Append(prestation.PrixTTC + ",");
                stringBuilder.Append(prestation.TypePrestation + ",");
                stringBuilder.Append(prestation.Categorie.Id + ")");

                sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

                resultat = 0;
            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

        #endregion

        #region Fonctions liées à l'entité Produit

        public List<Produit> getAllProduitsBy(string whereClause)
        {
            List<Produit> listeProduit = new List<Produit>();
            string query = "SELECT p.*, cp.nom AS categorie FROM produit p INNER JOIN categorie_produit cp ON p.id_categorie_produit = cp.id";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                int idCategoriePrestation = int.Parse(dataReader["id_categorie_produit"].ToString());
                CategorieProduit categorieProduit = new CategorieProduit(idCategoriePrestation, dataReader["categorie"].ToString());
                listeProduit.Add(new Produit(int.Parse(dataReader["id"].ToString()), dataReader["nom"].ToString(), dataReader["type"].ToString(),
                    int.Parse(dataReader["nombre_stock"].ToString()), int.Parse(dataReader["seuil_alerte"].ToString()), dataReader["fournisseur"].ToString(),
                    dataReader["reference_fournisseur"].ToString(), float.Parse(dataReader["prix_fournisseur"].ToString()), 
                    float.Parse(dataReader["prix_ttc"].ToString()), categorieProduit
                    ));
            }

            return listeProduit;
        }

        public int deleteProduitBy(string whereClause)
        {
            int resultat;
            string query = "DELETE FROM produit";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                sqliteAccess.ExecuteComandWOReturn(query);
                resultat = 0;
            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

        public int addProduit(Produit produit)
        {
            int resultat;
            string query = "INSERT produit('nom', 'type', 'nombre_stock', 'seuil_alerte', 'fournisseur', 'reference_fournisseur', 'prix_fournisseur', 'prix_ttc', id_categorie_prestation) VALUES(";
            if (produit.Categorie.Id != -1)
            {
                StringBuilder stringBuilder = new StringBuilder(query);
                stringBuilder.Append(produit.Nom + ",");
                stringBuilder.Append(produit.Type + ",");
                stringBuilder.Append(produit.NombreStock + ",");
                stringBuilder.Append(produit.SeuilAlerte + ",");
                stringBuilder.Append(produit.Fournisseur + ",");
                stringBuilder.Append(produit.ReferenceFournisseur + ",");
                stringBuilder.Append(produit.PrixFournisseur + ",");
                stringBuilder.Append(produit.Prix + ",");
                stringBuilder.Append(produit.Categorie.Id + ")");

                sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

                resultat = 0;
            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }
        #endregion

        #region Fonctions liées à l'entité Vendeur

        public List<Vendeur> getAllVendeursBy(string whereClause)
        {
            List<Vendeur> listeVendeur = new List<Vendeur>();
            string query = "SELECT * FROM vendeur";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                listeVendeur.Add(new Vendeur(int.Parse(dataReader["id"].ToString()), dataReader["nom"].ToString(), dataReader["prenom"].ToString(), dataReader["type_contrat"].ToString()));
            }

            return listeVendeur;
        }

        public int deleteVendeurBy(string whereClause)
        {
            int resultat;
            string query = "DELETE FROM vendeur";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                sqliteAccess.ExecuteComandWOReturn(query);
                resultat = 0;
            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

        public int addVendeur(Vendeur vendeur)
        {
            string query = "INSERT vendeur('nom','prenom','date_arrivee', 'type_contrat') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append(vendeur.Nom + ",");
            stringBuilder.Append(vendeur.Prenom + ",");
            stringBuilder.Append(vendeur.TypeContrat + ")");

            sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return 0;
        
    }

        #endregion

        #region Fonctions liées à l'entité Ventes

        public List<Vente> getAllVentesBy(string whereClause)
        {
            List<Vente> listeVente = new List<Vente>();
            string query = "SELECT * FROM vente";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                int idVente = int.Parse(dataReader["id"].ToString());
                Client client = getAllClientsBy("id=" + dataReader["id_client"].ToString())[0];
                Vendeur vendeur = getAllVendeursBy("id=" + dataReader["id_vendeur"].ToString())[0];
                List<Forfait> listeForfait = getAllForfaitsBy("id = (SELECT id_forfait FROM vente_forfait WHERE id_vente = " + int.Parse(dataReader["id"].ToString()) + ")");
                List<Produit> listeProduit = getAllProduitsBy("p.id = (SELECT id_produit FROM vente_produit  WHERE id_vente = " + int.Parse(dataReader["id"].ToString()) + ")");
                List<Prestation> listePrestation = getAllPrestationsBy("p.id = (SELECT id_produit FROM vente_produit  WHERE id_vente = " + int.Parse(dataReader["id"].ToString()) + ")");
                listeVente.Add(new Vente(idVente, float.Parse(dataReader["prix_ttc"].ToString()), client, vendeur, listeForfait, listeProduit, listePrestation)); ;
            }
            return listeVente;

            
        }

        public int deleteVentesBy(string whereClause)
        {
            int resultat;
            string query = "DELETE FROM vente";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                sqliteAccess.ExecuteComandWOReturn(query);
                resultat = 0;
            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

       public int addVente(Vente vente)
        {
            string query = "INSERT vente('id_client, id_vendeur, prix_ttc) VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append(vente.Client.Id + ",");
            stringBuilder.Append(vente.Vendeur.Id + ",");
            stringBuilder.Append(vente.PrixTotal + ")");

            sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn("SELECT last_insert_rowid() FROM client");
            dataReader.Read();
            int idVente = int.Parse(dataReader["last_insert_rowid()"].ToString());
            
            foreach(Produit p in vente.ListProduit)
            {
                query = "INSERT vente_produit('id_vente', 'id_produit') VALUES(";
                stringBuilder = new StringBuilder(query);
                stringBuilder.Append(idVente + ",");
                stringBuilder.Append(p.Id + ")");

                sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
            }
            foreach (Forfait f in vente.ListForfait)
            {
                query = "INSERT vente_forfait('id_vente', 'id_forfait') VALUES(";
                stringBuilder = new StringBuilder(query);
                stringBuilder.Append(idVente + ",");
                stringBuilder.Append(f.Id + ")");

                sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
            }
            foreach(Prestation p in vente.ListPrestation)
            {
                query = "INSERT vente_prestation('id_vente', 'id_prestation') VALUES(";
                stringBuilder = new StringBuilder(query);
                stringBuilder.Append(idVente + ",");
                stringBuilder.Append(p.Id + ")");

                sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
            }
            return 0;
        }

        #endregion
    }
}
