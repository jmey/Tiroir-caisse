using MahApps.Metro.Controls.Dialogs;
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
using TiroirCaisse.src.Utils;

namespace TiroirCaisse.src.Views.Clients
{
    /// <summary>
    /// Logique d'interaction pour AjouterClientPage.xaml
    /// </summary>
    
    public partial class AjouterClientPage : Page
    {
        public const int TailleTexte = 20;
        public ClientController clientController = new ClientController();
        public AjouterClientPage()
        {
            InitializeComponent();
        }

        private Client creerClientFromView()
        {
            DateTime? temp_dateArrivee = datePickerDateArrivee.SelectedDate;
            DateTime dateArrivee;
            Client res = null;
            try
            {
                dateArrivee = temp_dateArrivee.Value;
                return new Client(textBoxNom.Text, textBoxPrenom.Text, dateArrivee, textBoxTéléphoneFixe.Text, textBoxTelephonePortable.Text);
            }
            catch
            {
            }
            return res;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client clientToAdd = creerClientFromView();
            if (clientToAdd != null)
            {
                int res = clientController.ajouterClient(clientToAdd);
                if(res ==1)
                {
                    MessageBox.Show("L'utilisateur a été rajouté");
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
