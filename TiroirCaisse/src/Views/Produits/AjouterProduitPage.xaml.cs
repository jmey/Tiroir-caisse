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
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.src.Views.Produits
{
    /// <summary>
    /// Logique d'interaction pour AjouterProduitPage.xaml
    /// </summary>
    public partial class AjouterProduitPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public const int TailleTexte = 20;
        private List<CategorieProduit> _listCategorie;
        public List<CategorieProduit> listCategorie
        {
            get
            {
                return _listCategorie;
            }
            set
            {
                _listCategorie = value;
                OnPropertyChanged("listCategorie");
            }
        }
        private List<FamilleProduit> _listFamille;
        public List<FamilleProduit> listFamille
        {
            get
            {
                return _listFamille;
            }
            set
            {
                _listFamille = value;
                OnPropertyChanged("listFamille");
            }
        }
        public ProduitController ProduitController = new ProduitController();
        public AjouterProduitPage()
        {
            InitializeComponent();
            DataContext = this;
        }


        private Produit creerProduitFromView()
        {

            Produit res = null;
            try
            {
                CategorieProduit selectedCategorie=null;
                if(ComboBoxCategorie.SelectedIndex >= 0)
                {
                    selectedCategorie = listCategorie[ComboBoxCategorie.SelectedIndex];
                }
                return new Produit(textBoxNom.Text, textBoxType.Text, int.Parse(textBoxNombreStock.Text), int.Parse(textBoxSeuilAlerte.Text), textBoxFournisseur.Text, textBoxReferenceFournisseur.Text, float.Parse(textBoxPrix.Text), float.Parse(textBoxPrixFournisseur.Text), selectedCategorie);
            }
            catch
            {
            }
            return res;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Produit produitToAdd = creerProduitFromView();
            if (produitToAdd != null)
            {
                int res = ProduitController.ajouterProduit(produitToAdd);
                if (res == 1)
                {
                    MessageBox.Show("Le produit a été rajouté");
                    textBoxNom.Text = "";
                    textBoxNombreStock.Text = "";
                    textBoxPrix.Text = "";
                    textBoxPrixFournisseur.Text = "";
                    textBoxReferenceFournisseur.Text = "";
                    textBoxFournisseur.Text = "";
                    textBoxSeuilAlerte.Text = "";
                    textBoxType.Text = "";
                    ComboBoxCategorie.Text = "";
                    ComboBoxFamille.Text = "";
                }
                else
                {
                    MessageBox.Show("Problème interne, le produit n'a pas été ajouté");
                }
            }
            else
            {
                MessageBox.Show("Veuillez vérifier que les informations sont correctes (Bon format de date par exemple)");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listCategorie = ProduitController.getAllCategorieProduit();
            listFamille = ProduitController.getAllFamilleProduit();
        }

        protected void OnPropertyChanged(string name)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ComboBoxFamille_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFamille.SelectedIndex >= 0)
            {
                FamilleProduit selectedFamille = listFamille[ComboBoxFamille.SelectedIndex];
                listCategorie = ProduitController.getAllCategorieProduitByFamille(selectedFamille);
            }
        }

        private void textBoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
