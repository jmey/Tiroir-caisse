using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiroirCaisse.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;

namespace TiroirCaisse.Utils.Tests
{
    [TestClass()]
    public class ObjectBddTransitionTests
    {
        ObjectBddTransition transition = new ObjectBddTransition();
        [TestMethod()]
        public void getAllClientsByTest()
        {
            ObjectBddTransition transition = new ObjectBddTransition();
            List<Client> listClient = transition.getAllClientsBy("");
            Assert.AreEqual(1, listClient.Count);
        }

        [TestMethod()]
        public void getAllForfaitsByTest()
        {
            ObjectBddTransition transition = new ObjectBddTransition();
            List<Forfait> listForfait = transition.getAllForfaitsBy("");
            Assert.AreEqual(1, listForfait.Count);
        }

        [TestMethod()]
        public void getAllPrestationsByTest()
        {
            ObjectBddTransition transition = new ObjectBddTransition();
            List<Prestation> listPrestation = transition.getAllPrestationsBy("");
            Assert.AreEqual(1, listPrestation.Count);
        }

        [TestMethod()]
        public void getAllProduitsByTest()
        {
            ObjectBddTransition transition = new ObjectBddTransition();
            List<Produit> listProduit = transition.getAllProduitsBy("");
            Assert.AreEqual(1, listProduit.Count);
        }

        [TestMethod()]
        public void getAllVendeursByTest()
        {
            ObjectBddTransition transition = new ObjectBddTransition();
            List<Vendeur> listVendeur = transition.getAllVendeursBy("");
            Assert.AreEqual(1, listVendeur.Count);
        }

        [TestMethod()]
        public void getAllVentesByTest()
        {

            List<Vente> listVente = transition.getAllVentesBy("");
            Assert.AreEqual(1, listVente.Count);
        }

        [TestMethod()]
        public void addClientTest()
        {
            Client client = new Client("test", "test", new DateTime(2015, 10, 24), "0123456789", "0123456789");
            int result = transition.addClient(client);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void deleteClientByTest()
        {
            int result = transition.deleteClientBy("nom = 'mey' AND prenom = 'prenom'");
            Assert.AreEqual(0, result);
        }
    }
}