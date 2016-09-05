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

namespace TiroirCaisse.src.Views.Produits
{
    /// <summary>
    /// Logique d'interaction pour AjouterFamilleProduitPage.xaml
    /// </summary>
    public partial class AjouterFamilleProduitPage : Page
    {
        public ProduitController produitController = new ProduitController();
        public AjouterFamilleProduitPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FamilleProduit familleToAdd = creerFamilleFromView();
            if (familleToAdd != null)
            {
                int res = produitController.addFamilleProduit(familleToAdd);
                if (res == 1)
                {
                    MessageBox.Show("La catégorie a été rajouté");
                    textBoxNom.Text = "";
                }
                else
                {
                    MessageBox.Show("Problème interne, la catégorie n'a pas été rajoutée");
                }
            }
            else
            {
                MessageBox.Show("Veuillez vérifier que les informations sont correctes (Bon format de date par exemple)");
            }
        }

        private FamilleProduit creerFamilleFromView()
        {
            FamilleProduit famille = new FamilleProduit(textBoxNom.Text);
            return famille;
        }
    }
}
