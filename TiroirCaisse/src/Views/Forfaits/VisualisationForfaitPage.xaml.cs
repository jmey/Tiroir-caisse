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

namespace TiroirCaisse.src.Views.Forfaits
{
    /// <summary>
    /// Logique d'interaction pour VisualisationForfaitPage.xaml
    /// </summary>
    public partial class VisualisationForfaitPage : Page, INotifyPropertyChanged
    {
        private ForfaitController forfaitController { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Forfait> _listForfait { get; set; }
        public List<Forfait> listForfait
        {
            get { return _listForfait; }
            set
            {
                _listForfait = value;
                OnPropertyChanged("listForfait");
            }
        }
        public VisualisationForfaitPage()
        {
            forfaitController = new ForfaitController();
            InitializeComponent();
            DataGrid.DataContext = this;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listForfait = forfaitController.getAllForfaits();
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Forfait selectedForfait = DataGrid.SelectedItem as Forfait;
                    int res = forfaitController.supprimerForfait(selectedForfait);
                    if (res == 1)
                    {
                        MessageBox.Show("L'élement a été supprimé", "Informations");
                        listForfait = forfaitController.getAllForfaits();

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
