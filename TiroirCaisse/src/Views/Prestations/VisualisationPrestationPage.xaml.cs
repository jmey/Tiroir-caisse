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
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {

        }
        /*
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

   clientController = new ClientController();

   InitializeComponent();
   DataGrid.DataContext = this;

}
private void Page_Loaded(object sender, RoutedEventArgs e)
{
   listClient = clientController.getAllClients();
}
private void DataGrid_KeyDown(object sender, KeyEventArgs e)
{
   if (e.Key == Key.Delete || e.Key == Key.Back)
   {
       if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
       {
           Client selectedClient = DataGrid.SelectedItem as Client;
           int res = clientController.supprimerClient(selectedClient);
           if (res == 1)
           {
               MessageBox.Show("L'élement a été supprimé", "Informations");
               listClient = clientController.getAllClients();

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

*/
    }
    
}
