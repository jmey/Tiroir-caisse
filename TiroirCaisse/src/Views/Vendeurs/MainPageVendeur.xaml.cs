﻿using System;
using System.Collections.Generic;
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

namespace TiroirCaisse.src.Views.Vendeurs
{
    /// <summary>
    /// Logique d'interaction pour MainPageVendeur.xaml
    /// </summary>
    public partial class MainPageVendeur : Page
    {
        public MainPageVendeur()
        {
            InitializeComponent();
            ContentControlAjouterVendeur.Content = new AjouterVendeurPage();
            ContentControlVisualisationVendeurs.Content = new VisualisationVendeurPage();
        }
    }
}
