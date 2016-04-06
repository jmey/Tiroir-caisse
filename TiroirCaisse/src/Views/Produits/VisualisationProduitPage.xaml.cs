using Microsoft.Win32;
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

namespace TiroirCaisse.src.Views.Produits
{
    /// <summary>
    /// Logique d'interaction pour VisualisationProduitPage.xaml
    /// </summary>
    public partial class VisualisationProduitPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ProduitController produitController { get; set; }
        private List<Produit> _listProduit;
        public List<Produit> listProduit
        {
            get { return _listProduit; }
            set
            {
                _listProduit = value;
                OnPropertyChanged("listProduit");
            }
        }
        public VisualisationProduitPage()
        {

            produitController = new ProduitController();

            InitializeComponent();
            DataGrid.DataContext = this;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listProduit = produitController.getAllProduits();
        }
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Produit selectedProduit = DataGrid.SelectedItem as Produit;
                    int res = produitController.supprimerProduit(selectedProduit);
                    if (res == 1)
                    {
                        MessageBox.Show("L'élement a été supprimé", "Informations");
                        listProduit = produitController.getAllProduits();

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

        private void ExportCSV_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                List<object> listObject = listProduit.Select(x => x as object).ToList();
                string csv = produitController.listToCSV(listObject, typeof(Produit));
                produitController.saveCSVFile(dialog.FileName, csv);
            }
        }
    }
}
