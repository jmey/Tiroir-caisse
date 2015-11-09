using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiroirCaisse.Entities;
using TiroirCaisse.src.Controllers;

namespace TiroirCaisse.src.Views.Clients
{
    /// <summary>
    /// Logique d'interaction pour VisualisationClientPage.xaml
    /// </summary>
    public partial class VisualisationClientPage : Page
    {
        private ClientController clientController { get ;set; }
        public List<Client> listClient { get; set; }
        public VisualisationClientPage()
        {
            
            clientController = new ClientController();
            
            InitializeComponent();
            DataGrid.DataContext = this;
            listClient = clientController.getAllClients();
        }
    }
}
