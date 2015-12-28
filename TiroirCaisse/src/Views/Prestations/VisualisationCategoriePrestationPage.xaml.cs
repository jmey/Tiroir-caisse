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

namespace TiroirCaisse.src.Views.Prestations
{
    /// <summary>
    /// Logique d'interaction pour VisualisationCategoriePrestationPage.xaml
    /// </summary>
    public partial class VisualisationCategoriePrestationPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PrestationController prestationController { get; set; }
        private List<CategoriePrestation> _listCategoriePrestation;
        public List<CategoriePrestation> listCategoriePrestation
        {
            get { return _listCategoriePrestation; }
            set
            {
                _listCategoriePrestation = value;
                OnPropertyChanged("listCategoriePrestation");
            }
        }
        public VisualisationCategoriePrestationPage()
        {

            prestationController = new PrestationController();

            InitializeComponent();
            DataGrid.DataContext = this;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listCategoriePrestation = prestationController.getAllCategoriePrestation();
        }
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CategoriePrestation selectedCategorie = DataGrid.SelectedItem as CategoriePrestation;
                    int res = prestationController.supprimerCategoriePrestation(selectedCategorie);
                    if (res == 1)
                    {
                        MessageBox.Show("L'élement a été supprimé", "Informations");
                        listCategoriePrestation = prestationController.getAllCategoriePrestation();

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
