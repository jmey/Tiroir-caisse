using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiroirCaisse.Entities;
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Controllers
{
    public class ClientController
    {
        public ClientController()
        {

        }

        public List<Client> getAllClients()
        {
            ObjectBddTransition transition = new ObjectBddTransition();
            List<Client> resultat = transition.getAllClientsBy("");
            return resultat;
        }
        public int ajouterClient(Client client)
        {
            ObjectBddTransition transition = new ObjectBddTransition();
            int res = transition.addClient(client);
            return res;
        }

    }
}
