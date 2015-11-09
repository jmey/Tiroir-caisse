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

namespace TiroirCaisse.src.Views.Clients
{
    /// <summary>
    /// Logique d'interaction pour MainWindowClient.xaml
    /// </summary>
    public partial class MainPageClient : Page
    {
        public MainPageClient()
        {
            InitializeComponent();
            ContentControlAjouterClient.Content = new AjouterClientPage();
            ContentControlVisualisationClients.Content = new VisualisationClientPage();
        }

    }
}
