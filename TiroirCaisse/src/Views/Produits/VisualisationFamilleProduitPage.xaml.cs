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
using TiroirCaisse.src.Controllers;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.src.Views.Produits
{
    /// <summary>
    /// Logique d'interaction pour VisualisationFamilleProduitPage.xaml
    /// </summary>
    public partial class VisualisationFamilleProduitPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ProduitController produitController { get; set; }
        private List<FamilleProduit> _listFamilleProduit;
        public List<FamilleProduit> listFamilleProduit
        {
            get { return _listFamilleProduit; }
            set
            {
                _listFamilleProduit = value;
                OnPropertyChanged("listFamilleProduit");
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listFamilleProduit = produitController.getAllFamilleProduit();
        }
        public VisualisationFamilleProduitPage()
        {

            produitController = new ProduitController();

            InitializeComponent();
            DataGrid.DataContext = this;

        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    FamilleProduit selectedFamille = DataGrid.SelectedItem as FamilleProduit;
                    int res = produitController.supprimerFamilleProduit(selectedFamille);
                    if (res == 1)
                    {
                        MessageBox.Show("L'élement a été supprimé", "Informations");
                        listFamilleProduit = produitController.getAllFamilleProduit();

                    }
                    else
                    {
                        MessageBox.Show("Echec de la supression", "Informations");
                    }
                }

            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
