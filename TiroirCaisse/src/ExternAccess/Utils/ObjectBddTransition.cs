using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
               /*imeSpan ts;
                if (dataReader["date_arrivee"].ToString() != "")
                {
                    ts = new TimeSpan(long.Parse(dataReader["date_arrivee"].ToString()));
                }
                else
                {
                    ts = new TimeSpan(0);
                }
                TimeSpan ts2;
                if (dataReader["date_naissance"].ToString() != "")
                {
                    ts2 = new TimeSpan(long.Parse(dataReader["date_naissance"].ToString()));
                }
                else
                {
                    ts2 = new TimeSpan(0);
                }*/
                try
                {

                    DateTime dt = DateTime.FromBinary(long.Parse(dataReader["date_arrivee"].ToString()));
                    DateTime dt2= DateTime.FromBinary(long.Parse(dataReader["date_naissance"].ToString()));
                    int id = int.Parse(dataReader["id"].ToString());
                    string nom = dataReader["nom"].ToString();
                    string prenom = dataReader["prenom"].ToString();
                    string telephoneFixe = dataReader["telephone_fixe"].ToString();
                    string telephonePortable = dataReader["telephone_portable"].ToString();
                    float fidelite = float.Parse(dataReader["fidelite"].ToString());
                    string adresse = dataReader["adresse"].ToString();
                    string commentaire = dataReader["commentaire"].ToString();
                    string mail = dataReader["mail"].ToString();
                    Client client = new Client(id, nom, prenom, dt, telephoneFixe, telephonePortable, fidelite, dt2, adresse, commentaire, mail);
                    listeClient.Add(client);
                }
                catch(Exception)
                {

                }
            }
            
            return listeClient;
        }
        
        public int deleteClientBy(string whereClause)
        {
            int resfonction = 0;
            string query = "DELETE FROM client";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resfonction = sqliteAccess.ExecuteComandWOReturn(query);
            }
      

            return resfonction;
        }

        public int addClient(Client client)
        {       
            string query = "INSERT INTO client('nom','prenom','date_arrivee', 'telephone_fixe', 'telephone_portable', 'date_naissance', 'adresse', 'commentaire', 'mail') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("'" + client.Nom.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + client.Prenom.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + client.DateArrivee.ToBinary() + "'" + ",");
            stringBuilder.Append("'" + client.NumeroFixe.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + client.NumeroPortable.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + client.DateNaissance.ToBinary()+ "'" + ",");
            stringBuilder.Append("'" + client.Adresse.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + client.Commentaire.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + client.Mail.Replace("'", "''") + "'" + ")");
            int res = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
           
           return res;        
        }

        public bool updateClient(Client client)
        {
            string query = "UPDATE client SET ";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("nom = '" + client.Nom.Replace("'", "''") + "',");
            stringBuilder.Append("prenom = '" + client.Prenom.Replace("'", "''") + "',");
            stringBuilder.Append("date_arrivee = '" + client.DateArrivee.ToBinary() + "',");
            stringBuilder.Append("telephone_fixe = '" + client.NumeroFixe.Replace("'", "''") + "',");
            stringBuilder.Append("telephone_portable = '" + client.NumeroPortable.Replace("'", "''") + "',");
            stringBuilder.Append("date_naissance = '" + client.DateNaissance.ToBinary()+ "',");
            stringBuilder.Append("adresse = '" + client.Adresse.Replace("'", "''") + "',");
            stringBuilder.Append("fidelite = '" + client.Fidelite + "'");
            stringBuilder.Append(" WHERE id=" +  client.Id);
            int res = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
            return (res == 1);
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
            string query = "INSERT INTO forfait('nom','prix_ttc') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("'" + forfait.Nom.Replace("'", "''") + "'" + ",");
            stringBuilder.Append(forfait.PrixTTC + ")");

            int res =  sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return res;
        }

        public int updateForfait(string setClause, string whereClause)
        {
            string query = "UPDATE forfait SET " + setClause + " WHERE " + whereClause;
            int res = sqliteAccess.ExecuteComandWOReturn(query);
            return res;
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

               
                listePrestation.Add(new Prestation(idPrestation, dataReader["nom"].ToString(), int.Parse(dataReader["prix_ttc"].ToString()),
                    dataReader["type_prestation"].ToString(), categoriePrestation
                    ));
            }

            return listePrestation;
        }

        public int deletePrestationBy(string whereClause)
        {
            int resultat = 0;
            string query = "DELETE FROM prestation";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }

            return resultat;
        }

        public int addPrestation(Prestation prestation)
        {
            int resultat;
            string query = "INSERT INTO prestation('nom','prix_ttc','type_prestation', 'id_categorie_prestation') VALUES(";
            if(prestation != null || prestation.Categorie.Id != -1)
            { 
                StringBuilder stringBuilder = new StringBuilder(query);
                stringBuilder.Append("\"" + prestation.Nom.Replace("'", "''") + "\",");
                stringBuilder.Append(prestation.PrixTTC + ",");
                stringBuilder.Append("\"" + prestation.Type.Replace("'", "''") + "\",");
                stringBuilder.Append(prestation.Categorie.Id + ")");

                resultat = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

        public int updatePrestation(string setClause, string whereClause)
        {
            string query = "UPDATE prestation SET " + setClause + " WHERE " + whereClause;
            int res = sqliteAccess.ExecuteComandWOReturn(query);
            return res;
        }

        #endregion

        #region Fonctions liées à l'entité Produit

        public int updateProduit(string setClause, string whereClause)
        {
            int resultat;
            string query = "UPDATE Produit SET ";
            if (setClause != null && setClause != "")
            {
                query += setClause;
            }
            else
            {
                resultat = 0;
            }
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }
            else
            {
                resultat = 0;
            }
            return resultat;
        }

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
                int idCategorieProduit = int.Parse(dataReader["id_categorie_produit"].ToString());
                List<CategorieProduit> categoriesProduit = getAllCategorieProduitBy("id=" + idCategorieProduit);
                if(categoriesProduit.Count == 0)
                { return null; }
                
                CategorieProduit categorieProduit = categoriesProduit[0];
                listeProduit.Add(new Produit(int.Parse(dataReader["id"].ToString()), dataReader["nom"].ToString(), dataReader["type"].ToString(),
                    int.Parse(dataReader["nombre_stock"].ToString()), int.Parse(dataReader["seuil_alerte"].ToString()), dataReader["fournisseur"].ToString(),
                    dataReader["reference_fournisseur"].ToString(), float.Parse(dataReader["prix_ttc"].ToString()), 
                    float.Parse(dataReader["prix_fournisseur"].ToString()), categorieProduit
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
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }
            else
            {
                resultat = 0;
            }
            return resultat;
        }

        public int addProduit(Produit produit)
        {
            int resultat;
            string query = "INSERT INTO produit('nom', 'type', 'nombre_stock', 'seuil_alerte', 'fournisseur', 'reference_fournisseur', 'prix_fournisseur', 'prix_ttc', 'id_categorie_produit') VALUES(";
            if (produit.Categorie != null || produit.Categorie.Id != -1)
            {
                StringBuilder stringBuilder = new StringBuilder(query);
                stringBuilder.Append("\"" + produit.Nom.Replace("'", "''") + "\"" + ",");
                stringBuilder.Append("\"" + produit.Type.Replace("'", "''") + "\"" + ",");
                stringBuilder.Append(produit.NombreStock + ",");
                stringBuilder.Append(produit.SeuilAlerte + ",");
                stringBuilder.Append("\"" + produit.Fournisseur.Replace("'", "''") + "\"" + ",");
                stringBuilder.Append("\"" + produit.ReferenceFournisseur.Replace("'", "''") + "\"" + ",");
                stringBuilder.Append(produit.PrixFournisseur + ",");
                stringBuilder.Append(produit.PrixTTC + ",");
                stringBuilder.Append(produit.Categorie.Id + ")");

                resultat = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            }
            else
            {
                resultat = 1;
            }
            return resultat;
        }

        public bool updateProduit(Produit produit)
        {
            string query = "UPDATE produit SET ";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("nom = '" + produit.Nom.Replace("'", "''") + "',");
            stringBuilder.Append("type = '" + produit.Type.Replace("'", "''") + "',");
            stringBuilder.Append("nombre_stock = '" + produit.NombreStock + "',");
            stringBuilder.Append("seuil_alerte = '" + produit.SeuilAlerte + "',");
            stringBuilder.Append("fournisseur = '" + produit.Fournisseur.Replace("'", "''") + "',");
            stringBuilder.Append("reference_fournisseur = '" + produit.ReferenceFournisseur.Replace("'", "''") + "',");
            stringBuilder.Append("prix_fournisseur = '" + produit.PrixFournisseur + "',");
            stringBuilder.Append("prix_ttc = '" + produit.PrixTTC + "',");
            stringBuilder.Append("id_categorie_produit = '" + produit.Categorie.Id + "'");
            stringBuilder.Append(" WHERE id=" + produit.Id);

            int resultat = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
            return (resultat == 1);
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
            int resultat =0;
            string query = "DELETE FROM vendeur";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }

            return resultat;
        }

        public int addVendeur(Vendeur vendeur)
        {
            string query = "INSERT INTO vendeur('nom','prenom', 'type_contrat') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("'" + vendeur.Nom.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + vendeur.Prenom.Replace("'", "''") + "'" + ",");
            stringBuilder.Append("'" + vendeur.TypeContrat.Replace("'", "''") + "'" + ")");

            int res = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return res;
        
    }

        public int updateVendeur(string setClause, string whereClause)
        {
            string query = "UPDATE vendeur SET " + setClause + " WHERE " + whereClause;
            int res = sqliteAccess.ExecuteComandWOReturn(query);
            return res;
        }

        #endregion

        #region Fonctions liées à l'entité Vente

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
                Client client = null;
                Vendeur vendeur = null;
                List<Produit> listeProduit = null;
                List<Prestation> listePrestation = null;
                int idVente = int.Parse(dataReader["id"].ToString());
                List<Client> listClient = getAllClientsBy("id=" + dataReader["id_client"].ToString());
                if(listClient.Count >0)
                {
                    client = listClient[0];
                }
                else
                {
                    client = new Client("Plus enregistré", null, DateTime.MinValue, null, null, 0, DateTime.MinValue, null, null, null);
                }
                List<Vendeur> listVendeur = getAllVendeursBy("id=" + dataReader["id_vendeur"].ToString());
                if (listVendeur.Count > 0)
                {
                    vendeur = listVendeur[0];
                }
                else
                {
                    vendeur = new Vendeur("Plus enregistré", null, null);
                }
                listeProduit = getAllProduitsBy("p.id IN (SELECT id_produit FROM vente_produit  WHERE id_vente = " + int.Parse(dataReader["id"].ToString()) + ")");
                listePrestation = getAllPrestationsBy("p.id IN (SELECT id_prestation FROM vente_prestation  WHERE id_vente = " + int.Parse(dataReader["id"].ToString()) + ")");
                // --- set the number of prestation and produit because the query just return DISTINCT object ....
                List<Prestation> listeIntPrestation = new List<Prestation>();
                listePrestation.ForEach((item) =>
                {
                    listeIntPrestation.Add(item as Prestation);
                });
                foreach (Prestation p in listeIntPrestation)
                {
                    int nbVentePrestation = getNbventePrestation(p.Id, idVente);
                    if(nbVentePrestation>1)
                    {
                        for(int i = 1; i<nbVentePrestation; i++)
                        {
                            listePrestation.Add(p);
                        }
                    }
                }
                List<Produit> listeIntProduit = new List<Produit>();
                listeProduit.ForEach((item) =>
                {
                    listeIntProduit.Add(item as Produit);
                });
                foreach (Produit p in listeIntProduit)
                {
                    int nbVenteProduit = getNbventeProduit(p.Id, idVente);
                    if (nbVenteProduit > 1)
                    {
                        for (int i = 1; i <nbVenteProduit; i++)
                        {
                            listeProduit.Add(p);
                        }
                    }
                }
                // ----

                DateTime date = DateTime.FromBinary(long.Parse(dataReader["date"].ToString()));
                listeVente.Add(new Vente(idVente, float.Parse(dataReader["prix_ttc"].ToString()), client, vendeur, listeProduit, listePrestation, dataReader["moyen_paiement"].ToString(), date));
            }
            return listeVente;

            
        }

        public int deleteVenteBy(string whereClause)
        {
            int resultat;
            string query = "DELETE FROM vente";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
                
            }
            else
            {
                resultat = 0;
            }
            return resultat;
        }

        public int addVente(Vente vente)
        {
            int res = 0;
            string query = "INSERT INTO vente('id_client', 'id_vendeur', 'prix_ttc', 'date', 'moyen_paiement') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append(vente.Client.Id + ",");
            stringBuilder.Append(vente.Vendeur.Id + ",");
            stringBuilder.Append(vente.PrixTotal + ",");
            stringBuilder.Append("'" + vente.DatePaiement.ToBinary() + "'" + ",");
            stringBuilder.Append("'" + vente.TypePaiement.Replace("'", "''") + "'" + ")");

            res += sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn("SELECT last_insert_rowid() FROM vente");
            dataReader.Read();
            int idVente = int.Parse(dataReader["last_insert_rowid()"].ToString());
            
            foreach(Produit p in vente.ListProduit)
            {
                query = "INSERT INTO vente_produit('id_vente', 'id_produit') VALUES(";
                stringBuilder = new StringBuilder(query);
                stringBuilder.Append(idVente + ",");
                stringBuilder.Append(p.Id + ")");

                res += sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
            }

            foreach(Prestation p in vente.ListPrestation)
            {
                query = "INSERT INTO vente_prestation('id_vente', 'id_prestation') VALUES(";
                stringBuilder = new StringBuilder(query);
                stringBuilder.Append(idVente + ",");
                stringBuilder.Append(p.Id + ")");

                res += sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());
            }


            return res;
        }

        public int updateVente(string setClause, string whereClause)
        {
            string query = "UPDATE vente SET " + setClause + " WHERE " + whereClause;
            int res = sqliteAccess.ExecuteComandWOReturn(query);
            return res;
        }

        public int getNbventePrestation(int idPrestation, int idVente)
        {
            int res=1;
            string query = "SELECT COUNT(*) AS count FROM vente_prestation WHERE id_prestation = " + idPrestation + " AND id_vente = " + idVente + ";";
            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                res = int.Parse(dataReader["count"].ToString());
            }
            return res;
        }

        public int getNbventeProduit(int idProduit, int idVente)
        {
            int res = 1;
            string query = "SELECT COUNT(*) AS count FROM vente_produit WHERE id_produit = " + idProduit + " AND id_vente = " + idVente + ";";
            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                res = int.Parse(dataReader["count"].ToString());
            }
            return res;
        }

        #endregion

        #region Fonctions liées à l'entité CategorieProduit

        public List<CategorieProduit> getAllCategorieProduitBy(string whereClause)
        {
            List<CategorieProduit> listeCategorieProduit = new List<CategorieProduit>();
            string query = "SELECT * FROM categorie_produit";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                int idProduit = int.Parse(dataReader["id"].ToString());
                string string_id = dataReader["id_famille_produit"].ToString();
                FamilleProduit famille;
                if (string_id != null && string_id != "")
                {
                    int id_famille_produit = int.Parse(dataReader["id_famille_produit"].ToString());
                    List<FamilleProduit> listFamille = getAllFamilleProduitBy("id=" + id_famille_produit);                   
                    if (listFamille.Count > 0)
                    {
                        famille = listFamille[0];
                    }
                    else
                    {
                        famille = new FamilleProduit("Inconnue");
                    }
                }
                else
                {
                    famille = new FamilleProduit("Inconnue");
                }
               
                listeCategorieProduit.Add(new CategorieProduit(idProduit, dataReader["nom"].ToString(), famille));
            }

            return listeCategorieProduit;
        }

        public int deleteCategorieProduitBy(string whereClause)
        {
            int resultat = 0;
            string query = "DELETE FROM categorie_produit";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }

            return resultat;
        }

        public int addCategorieProduit(CategorieProduit categorie)
        {
            string query = "INSERT INTO categorie_produit('nom', 'id_famille_produit') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("'" + categorie.Nom.Replace("'", "''") + "'" + ",");
            stringBuilder.Append(categorie.Famille.Id + ")");
            int res = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return res;
        }



        #endregion

        #region Fonctions liées à l'entité CategoriePrestation

        public List<CategoriePrestation> getAllCategoriePrestationBy(string whereClause)
        {
            List<CategoriePrestation> listeCategoriePrestation = new List<CategoriePrestation>();
            string query = "SELECT * FROM categorie_prestation";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {
                listeCategoriePrestation.Add(new CategoriePrestation(int.Parse(dataReader["id"].ToString()), dataReader["nom"].ToString()));
            }

            return listeCategoriePrestation;
        }

        public int deleteCategoriePrestationBy(string whereClause)
        {
            int resultat = 0;
            string query = "DELETE FROM categorie_prestation";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }

            return resultat;
        }

        public int addCategoriePrestation(CategoriePrestation categorie)
        {
            string query = "INSERT INTO categorie_prestation('nom') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("'" + categorie.Nom.Replace("'", "''") + "'" + ")");

            int res = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return res;
        }
        #endregion

        #region Fonctions liées à l'entité MontantCaisse

        public List<MontantRetireCaisse> getAllMontantsCaisseBy(string whereClause)
        {
            List<MontantRetireCaisse> listeMontantCaisse = new List<MontantRetireCaisse>();
            string query = "SELECT * FROM montant_retire_caisse";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    DateTime date = DateTime.FromBinary(long.Parse(dataReader["date"].ToString()));
                    listeMontantCaisse.Add(new MontantRetireCaisse(int.Parse(dataReader["id"].ToString()), date, float.Parse(dataReader["montant_retire"].ToString()), dataReader["type"].ToString()));
                }
            }
            return listeMontantCaisse;
        }

        public int deleteMontantCaisseBy(string whereClause)
        {
            int resultat = 0;
            string query = "DELETE FROM montant_retire_caisse";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }

            return resultat;
        }

        public int addMontantCaisse(MontantRetireCaisse _montant)
        {
            string query = "INSERT INTO montant_retire_caisse('date', 'montant_retire', 'type') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append(_montant.Date.ToBinary() + ",");
            stringBuilder.Append(_montant.Montant + ",");
            stringBuilder.Append("'" + _montant.Type.Replace("'", "''") + "'"  + ")");

            int res = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return res;
        }

        #endregion

        #region Fonctions liées à l'entité FamilleProduit

        public List<FamilleProduit> getAllFamilleProduitBy(string whereClause)
        {
            List<FamilleProduit> listeFamilleProduit = new List<FamilleProduit>();
            string query = "SELECT * FROM famille_produit";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
            }

            SQLiteDataReader dataReader = sqliteAccess.ExecuteCommandWReturn(query);
            while (dataReader.Read())
            {

                listeFamilleProduit.Add(new FamilleProduit(int.Parse(dataReader["id"].ToString()), dataReader["nom"].ToString()));
            }

            return listeFamilleProduit;
        }

        public int deleteFamilleProduitBy(string whereClause)
        {
            int resultat = 0;
            string query = "DELETE FROM famille_produit";
            if (whereClause != null && whereClause != "")
            {
                query += " WHERE " + whereClause;
                resultat = sqliteAccess.ExecuteComandWOReturn(query);
            }

            return resultat;
        }

        public int addFamilleProduit(FamilleProduit famille)
        {
            string query = "INSERT INTO famille_produit('nom') VALUES(";
            StringBuilder stringBuilder = new StringBuilder(query);
            stringBuilder.Append("'" + famille.Nom.Replace("'", "''") + "'" + ")");

            int res = sqliteAccess.ExecuteComandWOReturn(stringBuilder.ToString());

            return res;
        }
        #endregion
    }
}
