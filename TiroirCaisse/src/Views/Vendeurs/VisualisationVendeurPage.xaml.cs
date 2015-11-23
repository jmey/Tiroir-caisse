﻿using System;
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

namespace TiroirCaisse.src.Views.Vendeurs
{
    /// <summary>
    /// Logique d'interaction pour VisualisationVendeurPage.xaml
    /// </summary>
    public partial class VisualisationVendeurPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private VendeurController VendeurController { get; set; }
        private List<Vendeur> _listVendeur;
        public List<Vendeur> listVendeur
        {
            get { return _listVendeur; }
            set
            {
                _listVendeur = value;
                OnPropertyChanged("listVendeur");
            }
        }
        public VisualisationVendeurPage()
        {

            VendeurController = new VendeurController();

            InitializeComponent();
            DataGrid.DataContext = this;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listVendeur = VendeurController.getAllVendeurs();
        }
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Etes vous sûr de supprimer cet élement ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Vendeur selectedVendeur = DataGrid.SelectedItem as Vendeur;
                    int res = VendeurController.supprimerVendeur(selectedVendeur);
                    if (res == 1)
                    {
                        MessageBox.Show("L'élement a été supprimé", "Informations");
                        listVendeur = VendeurController.getAllVendeurs();

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
