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
    /// Logique d'interaction pour VisualisationCategorieProduitPage.xaml
    /// </summary>
    public partial class VisualisationCategorieProduitPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ProduitController produitController { get; set; }
        private List<CategorieProduit> _listCategorieProduit;
        public List<CategorieProduit> listCategorieProduit
        {
            get { return _listCategorieProduit; }
            set
            {
                _listCategorieProduit = value;
                OnPropertyChanged("listCategorieProduit");
            }
        }
        public VisualisationCategorieProduitPage()
        {

            produitController = new ProduitController();

            InitializeComponent();
            DataGrid.DataContext = this;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listCategorieProduit = produitController.getAllCategorieProduit();
        }
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CategorieProduit selectedCategorie = DataGrid.SelectedItem as CategorieProduit;
                    int res = produitController.supprimerCategorieProduit(selectedCategorie);
                    if (res == 1)
                    {
                        MessageBox.Show("L'élement a été supprimé", "Informations");
                        listCategorieProduit = produitController.getAllCategorieProduit();

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
    }
}
