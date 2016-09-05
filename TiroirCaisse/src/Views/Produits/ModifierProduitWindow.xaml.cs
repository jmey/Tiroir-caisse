using System;
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
using System.Windows.Shapes;
using TiroirCaisse.Entities;
using TiroirCaisse.src.Controllers;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.src.Views.Produits
{
    /// <summary>
    /// Logique d'interaction pour UpdateProduitWindow.xaml
    /// </summary>
    public partial class ModifierProduitWindow : Window
    {
        private ProduitController ProduitController;
        private Produit produit;
        public ModifierProduitWindow(Produit produit)
        {
            this.produit = produit;
            InitializeComponent();
            ProduitController = new ProduitController();
            textBoxFournisseur.Text = produit.Fournisseur;
            textBoxNom.Text = produit.Nom;
            textBoxNombreStock.Text = produit.NombreStock.ToString();
            textBoxPrix.Text = produit.PrixTTC.ToString();
            textBoxPrixFournisseur.Text = produit.PrixFournisseur.ToString();
            textBoxReferenceFournisseur.Text = produit.ReferenceFournisseur;
            textBoxSeuilAlerte.Text = produit.SeuilAlerte.ToString();
            textBoxType.Text = produit.Type;
            ComboBoxCategorie.ItemsSource = ProduitController.getAllCategorieProduit();
            ComboBoxFamille.ItemsSource = ProduitController.getAllFamilleProduit();
            ComboBoxCategorie.SelectedValue = produit.Categorie;
            ComboBoxCategorie.SelectedItem = produit.Categorie;
            ComboBoxFamille.SelectedValue = produit.Categorie.Famille;
            ComboBoxFamille.SelectedItem = produit.Categorie.Famille;
            
        }
        private void modifierProduitFromView()
        {
            try
            {
                produit.Fournisseur = textBoxFournisseur.Text;
                produit.Nom = textBoxNom.Text;
                produit.NombreStock = int.Parse(textBoxNombreStock.Text);
                produit.PrixTTC = float.Parse(textBoxPrix.Text);
                produit.PrixFournisseur = float.Parse(textBoxPrixFournisseur.Text);
                produit.ReferenceFournisseur = textBoxReferenceFournisseur.Text;
                produit.SeuilAlerte = int.Parse(textBoxSeuilAlerte.Text);
                produit.Type = textBoxType.Text;
                produit.Categorie = (CategorieProduit)ComboBoxCategorie.SelectedItem;
                
            }
            catch
            {
                throw;
            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                modifierProduitFromView();
                if(!ProduitController.updateProduit(produit))
                {
                    MessageBox.Show("Erreur interne, l'objet courant n'a pas été modifié");
                }
                else
                {
                    MessageBox.Show("Objet modifié");
                    textBoxNom.Text = "";
                    textBoxNombreStock.Text = "";
                    textBoxPrix.Text = "";
                    textBoxPrixFournisseur.Text = "";
                    textBoxReferenceFournisseur.Text = "";
                    textBoxSeuilAlerte.Text = "";
                    textBoxType.Text = "";
                    ComboBoxCategorie.Text = "";
                    ComboBoxFamille.Text = "";
                    this.Close();
                }
                     
            }
            catch
            {
                MessageBox.Show("Les champs ont été mal renseignés");
            }

        }

        private void ComboBoxFamille_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFamille.SelectedIndex >= 0)
            {
                FamilleProduit selectedFamille = ProduitController.getAllFamilleProduit()[ComboBoxFamille.SelectedIndex];
                ComboBoxCategorie.ItemsSource = ProduitController.getAllCategorieProduitByFamille(selectedFamille);
            }
        }
    }
}
