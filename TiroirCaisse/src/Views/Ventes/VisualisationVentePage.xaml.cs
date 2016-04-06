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

namespace TiroirCaisse.src.Views.Ventes
{
    /// <summary>
    /// Logique d'interaction pour VisualisationVentePage.xaml
    /// </summary>
    public partial class VisualisationVentePage : Page, INotifyPropertyChanged
    {
        private VenteController controller { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Vente> _listVentes { get; set; }
        public List<Vente> listVentes
        {
            get
            {
                return _listVentes;
            }
            set
            {
                _listVentes = value;
                OnPropertyChanged("listVentes");
            }
        }

        public VisualisationVentePage()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new VenteController();
        }


        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            listVentes = controller.getAllVentes();
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Vente selectedVente = DataGrid.SelectedItem as Vente;
                    int res = controller.supprimerVente(selectedVente);
                    if (res == 1)
                    {
                        MessageBox.Show("L'élement a été supprimé", "Informations");
                        listVentes = controller.getAllVentes();

                    }
                    else
                    {
                        MessageBox.Show("Echec de la supression", "Informations");
                    }
                }

            }
        }

        private void ExportCSV_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                List<object> listObject = listVentes.Select(x => x as object).ToList();
                string csv = controller.listToCSV(listObject, typeof(Vente));
                controller.saveCSVFile(dialog.FileName, csv);
            }
        }
    }
}
