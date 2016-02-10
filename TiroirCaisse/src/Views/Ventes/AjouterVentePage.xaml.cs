using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.src.Views.Ventes
{
    /// <summary>
    /// Logique d'interaction pour AjouterVentePage.xaml
    /// </summary>
    public partial class AjouterVentePage : Page, INotifyPropertyChanged
    {
        private VenteController controller { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Vendeur> _listVendeurs{ get; set; }
        public List<Vendeur> listVendeurs
        {
            get
            {
                return _listVendeurs;
                
            }
            set
            {
                _listVendeurs = value;
                OnPropertyChanged("listVendeurs");
            }
        }
        private List<Client> _listClients { get; set; }
        public List<Client> listClients
        {
            get
            {
                return _listClients;

            }
            set
            {
                _listClients = value;
                OnPropertyChanged("listClients");
            }
        }
        private List<Prestation> _listPrestations { get; set; }
        public List<Prestation> listPrestations
        {
            get
            {
                return _listPrestations;

            }
            set
            {
                _listPrestations = value;
                OnPropertyChanged("listPrestations");
            }
        }
        private List<Produit> _listProduits { get; set; }
        public List<Produit> listProduits
        {
            get
            {
                return _listProduits;

            }
            set
            {
                _listProduits = value;
                OnPropertyChanged("listProduits");
            }
        }
        private List<Item> _listItems { get; set; }
        public List<Item> listItems
        {
            get
            {
                return _listItems;

            }
            set
            {
                _listItems = value;
                OnPropertyChanged("listItems");
            }
        }
        public AjouterVentePage()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new VenteController();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listVendeurs = controller.getAllVendeurs();
            listClients = controller.getAllClients();
            listPrestations = controller.getAllPrestations();
            listProduits = controller.getAllProduits();
            _listItems = new List<Item>();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ListBoxPrestation_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (listBox_prestation.SelectedItem != null)
            {
               Prestation selectedPrestation = (Prestation)listBox_prestation.SelectedItem;
                listItems.Add(selectedPrestation);
            }
        }

        private void ListBoxProduit_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (listBox_produit.SelectedItem != null)
            {
                Produit selectedProduit = (Produit)listBox_produit.SelectedItem;
                listItems.Add(selectedProduit);
            }
        }
    }
}
