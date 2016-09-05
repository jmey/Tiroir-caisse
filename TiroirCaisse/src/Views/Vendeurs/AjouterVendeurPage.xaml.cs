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
using TiroirCaisse.Entities;
using TiroirCaisse.src.Controllers;

namespace TiroirCaisse.src.Views.Vendeurs
{
    /// <summary>
    /// Logique d'interaction pour AjouterVendeurPage.xaml
    /// </summary>
    public partial class AjouterVendeurPage : Page
    {
        public const int TailleTexte = 20;
        public VendeurController VendeurController = new VendeurController();
        public AjouterVendeurPage()
        {
            InitializeComponent();
        }

        private Vendeur creerVendeurFromView()
        {

            Vendeur res = null;
            try
            {
                return new Vendeur(textBoxNom.Text, textBoxPrenom.Text, textBoxTypeContrat.Text);
            }
            catch
            {
            }
            return res;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Vendeur vendeurToAdd = creerVendeurFromView();
            if (vendeurToAdd != null)
            {
                int res = VendeurController.ajouterVendeur(vendeurToAdd);
                if (res == 1)
                {
                    MessageBox.Show("L'utilisateur a été rajouté");
                    textBoxNom.Text = "";
                    textBoxPrenom.Text = "";
                    textBoxTypeContrat.Text = "";
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
