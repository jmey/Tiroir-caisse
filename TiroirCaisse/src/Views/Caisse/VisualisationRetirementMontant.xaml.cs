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

namespace TiroirCaisse.src.Views.Caisse
{
    /// <summary>
    /// Logique d'interaction pour VisualisationRetirementMontant.xaml
    /// </summary>
    public partial class VisualisationRetirementMontant : Page, INotifyPropertyChanged
    {
        CaisseController controller;
        private List<MontantRetireCaisse> _listMontantRetireCaisse;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<MontantRetireCaisse> listMontantRetireCaisse
        {
            get { return _listMontantRetireCaisse; }
            set
            {
                _listMontantRetireCaisse = value;
                OnPropertyChanged("listMontantRetireCaisse");
            }
        }
        public VisualisationRetirementMontant()
        {
            DataContext = this;
            controller = new CaisseController();
            InitializeComponent();
            
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MontantRetireCaisse selectedMontant = DataGrid.SelectedItem as MontantRetireCaisse;
                    int res = controller.supprimerMontantRetirerCaisse(selectedMontant);
                    if (res == 1)
                    {
                        listMontantRetireCaisse = controller.getAllMontantRetire();

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

        }
        protected void OnPropertyChanged(string name)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listMontantRetireCaisse = controller.getAllMontantRetire();
        }
    }
}
