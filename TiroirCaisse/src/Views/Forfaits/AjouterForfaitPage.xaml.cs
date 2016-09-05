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

namespace TiroirCaisse.src.Views.Forfaits
{
    /// <summary>
    /// Logique d'interaction pour AjouterForfaitPage.xaml
    /// </summary>
    public partial class AjouterForfaitPage : Page
    {
        public ForfaitController forfaitController = new ForfaitController();
        public AjouterForfaitPage()
        {
            InitializeComponent();
        }
        private Forfait creerForfaitFromView()
        {
            Forfait res = null;
            try
            {
                float prixTTCfloat = float.Parse(textBoxPrixTTC.Text);
                
                return new Forfait(textBoxNom.Text, prixTTCfloat);
            }
            catch
            {
            }
            return res;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forfait forfaitToAdd = creerForfaitFromView();
            if (forfaitToAdd != null)
            {
                int res = forfaitController.ajouterForfait(forfaitToAdd);
                if (res == 1)
                {
                    MessageBox.Show("Le forfait a été rajouté");
                    textBoxNom.Text = "";
                    textBoxPrixTTC.Text = "";
                }
                else
                {
                    MessageBox.Show("Problème interne, le forfait n'a pas été ajouté");
                }
            }
            else
            {
                MessageBox.Show("Veuillez vérifier que les informations sont correctes");
            }
        }
    }
}
