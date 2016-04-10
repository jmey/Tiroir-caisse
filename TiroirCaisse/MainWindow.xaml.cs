using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using MahApps.Metro.Controls;
using TiroirCaisse.src.Views.Clients;
using TiroirCaisse.src.Views.Prestations;
using TiroirCaisse.src.Views.Forfaits;
using TiroirCaisse.src.Views.Vendeurs;
using TiroirCaisse.src.Views.Produits;
using TiroirCaisse.src.Views.Ventes;
using TiroirCaisse.src.Views.Caisse;

namespace TiroirCaisse
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow() 
        {
           
            InitializeComponent();
            ContentControlClients.Content = new MainPageClient();
            ContentControlPrestations.Content = new MainPagePrestation();
            ContentControlVendeurs.Content = new MainPageVendeur();
            ContentControlProduits.Content = new MainPageProduit();
            ContentControlVentes.Content = new MainPageVente();
            ContentControlCaisse.Content = new MainPageCaisse();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
/*            TabControl currentControl = sender as TabControl;
            TabItem currentTab = currentControl.SelectedItem as TabItem;
            switch(currentTab.Name)
            {
                case "Clients":
                    MainContent.Content = new MainWindowClient() as Page;
                    break;
                default:
                   // MainContent.Content = null;
                    break;
            }*/
        }
    }
}
