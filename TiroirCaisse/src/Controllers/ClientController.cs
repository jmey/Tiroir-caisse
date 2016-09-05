using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    public class ClientController : Controller
    {
        private ObjectBddTransition transition { get; set; }
        public ClientController()
        {
            transition = new ObjectBddTransition();
        }

        public List<Client> getAllClients()
        {
            List<Client> resultat = transition.getAllClientsBy("");
            return resultat;
        }
        public int ajouterClient(Client client)
        {
            int res = transition.addClient(client);
            return res;
        }
        public int supprimerClient(Client client)
        {
            int res = transition.deleteClientBy("id=" + client.Id);
            return res;
        }

        internal bool updateClient(Client client)
        {
            bool res = transition.updateClient(client);
            return res;
        }
    }
}
