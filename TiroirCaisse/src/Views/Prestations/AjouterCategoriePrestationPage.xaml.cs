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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiroirCaisse.src.Controllers;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.src.Views.Prestations
{
    /// <summary>
    /// Logique d'interaction pour AjouterCategoriePrestationPage.xaml
    /// </summary>
    public partial class AjouterCategoriePrestationPage : Page
    {
        public PrestationController prestationtController = new PrestationController();
        public AjouterCategoriePrestationPage()
        {
            InitializeComponent();
        }

        private CategoriePrestation creerCategorieFromView()
        {
            CategoriePrestation res = null;
            try
            {
                res = new CategoriePrestation(textBoxNom.Text);
            }
            catch
            {
            }
            return res;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CategoriePrestation categorieToAdd = creerCategorieFromView();
            if (categorieToAdd != null)
            {
                int res = prestationtController.ajouterCategoriePrestation(categorieToAdd);
                if (res == 1)
                {
                    MessageBox.Show("L'utilisateur a été rajouté");
                    textBoxNom.Text = "";
                }
                else
                {
                    MessageBox.Show("Problème interne, l'utilisateur n'a pas été ajouté");
                }
            }
            else
            {
                MessageBox.Show("Veuillez vérifier que les informations sont correctes (Bon format de date par exemple)");
            }
        }
    }
}
