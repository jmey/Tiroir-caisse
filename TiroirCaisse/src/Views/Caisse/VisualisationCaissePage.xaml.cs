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

namespace TiroirCaisse.src.Views.Caisse
{
    /// <summary>
    /// Logique d'interaction pour VisualisationCaissePage.xaml
    /// </summary>
    public partial class VisualisationCaissePage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _montantCBRecu { get; set; }
        private string _montantCBPris { get; set; }
        private string _montantCBTotal { get; set; }

        private string _montantEspeceRecu { get; set; }
        private string _montantEspecePris { get; set; }
        private string _montantEspeceTotal { get; set; }

        private string _montantChequeRecu { get; set; }
        private string _montantChequePris { get; set; }
        private string _montantChequeTotal { get; set; }

        private string _montantTotalRecu { get; set; }
        private string _montantTotalPris { get; set; }
        private string _montantTotalTotal { get; set; }

        public string montantCBRecu 
        {
            get { return _montantCBRecu; }
            set
            {
                _montantCBRecu = value;
                OnPropertyChanged("montantCBRecu");
            }
        }
        public string montantCBPris
        {
            get { return _montantCBPris; }
            set
            {
                _montantCBPris = value;
                OnPropertyChanged("montantCBPris");
            }
        }
        public string montantCBTotal
        {
            get { return _montantCBTotal; }
            set
            {
                _montantCBTotal = value;
                OnPropertyChanged("montantCBTotal");
            }
        }

        public string montantEspeceRecu
        {
            get { return _montantEspeceRecu; }
            set
            {
                _montantEspeceRecu = value;
                OnPropertyChanged("montantEspeceRecu");
            }
        }
        public string montantEspecePris
        {
            get { return _montantEspecePris; }
            set
            {
                _montantEspecePris = value;
                OnPropertyChanged("montantEspecePris");
            }
        }
        public string montantEspeceTotal
        {
            get { return _montantEspeceTotal; }
            set
            {
                _montantEspeceTotal = value;
                OnPropertyChanged("montantEspeceTotal");
            }
        }

        public string montantTotalRecu
        {
            get { return _montantTotalRecu; }
            set
            {
                _montantCBRecu = value;
                OnPropertyChanged("montantTotalRecu");
            }
        }
        public string montantTotalPris
        {
            get { return _montantTotalPris; }
            set
            {
                _montantTotalPris = value;
                OnPropertyChanged("montantTotalPris");
            }
        }
        public string montantTotalTotal
        {
            get { return _montantTotalTotal; }
            set
            {
                _montantTotalTotal = value;
                OnPropertyChanged("montantTotalTotal");
            }
        }

        public VisualisationCaissePage()
        {

            InitializeComponent();
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
           
        }
    }
}