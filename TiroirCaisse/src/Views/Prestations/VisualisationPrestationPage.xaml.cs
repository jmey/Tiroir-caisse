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

namespace TiroirCaisse.src.Views.Prestations
{
    /// <summary>
    /// Logique d'interaction pour VisualisationPrestationPage.xaml
    /// </summary>
    public partial class VisualisationPrestationPage : Page//, INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        private PrestationController prestationController { get; set; }
        private List<Prestation> _listPrestation;
        public List<Prestation> listPrestation
        {
           get { return _listPrestation; }
           set
           {
               _listPrestation = value;
               OnPropertyChanged("listPrestation");
           }
        }
        public VisualisationPrestationPage()
        {

           prestationController = new PrestationController();

           InitializeComponent();
           DataGrid.DataContext = this;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           listPrestation = prestationController.getAllPrestations();
        }
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.Key == Key.Delete || e.Key == Key.Back)
           {
               if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
               {
                   Prestation selectedPrestation = DataGrid.SelectedItem as Prestation;
                   int res = prestationController.supprimerPrestation(selectedPrestation);
                   if (res == 1)
                   {
                       MessageBox.Show("L'élement a été supprimé", "Informations");
                       listPrestation = prestationController.getAllPrestations();

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
