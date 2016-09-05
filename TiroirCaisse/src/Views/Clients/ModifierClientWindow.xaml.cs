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
using TiroirCaisse.Utils;

namespace TiroirCaisse.src.Views.Clients
{
    /// <summary>
    /// Logique d'interaction pour ModifierClientWindow.xaml
    /// </summary>
    public partial class ModifierClientWindow : Window
    {
        private Client client;
        public ModifierClientWindow(Client client)
        {
            this.client = client;
            InitializeComponent();
            textBoxNom.Text = client.Nom;
            textBoxPrenom.Text = client.Prenom;
            textBoxTelephonePortable.Text = client.NumeroPortable;
            textBoxTéléphoneFixe.Text = client.NumeroFixe;
            datePickerDateArrivee.SelectedDate = client.DateArrivee;
            datePickerDateNaissance.SelectedDate = client.DateNaissance;
            textBoxAdresse.Text = client.Adresse;
        }
        public void modifierClientFromView()
        {
            DateTime? temp_dateArrivee = datePickerDateArrivee.SelectedDate;
            DateTime? temp_dateNaissance = datePickerDateNaissance.SelectedDate;
            DateTime dateArrivee = new DateTime(), dateNaissance = new DateTime();
            if (temp_dateArrivee != null)
            {
                client.Nom = textBoxNom.Text;
                client.Prenom = textBoxPrenom.Text;
                client.NumeroFixe = textBoxTéléphoneFixe.Text;
                client.NumeroPortable = textBoxTelephonePortable.Text;
                client.Adresse = textBoxAdresse.Text;
                try
                {
                    dateArrivee = temp_dateArrivee.Value;
                    dateNaissance = temp_dateNaissance.Value;
                }
                catch { }
                client.DateArrivee = dateArrivee;
                client.DateNaissance = dateNaissance;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            modifierClientFromView();
            if (client != null)
            {
                ObjectBddTransition transition = new ObjectBddTransition();
                ClientController controller = new ClientController();
                if(controller.updateClient(client))
                {
                    MessageBox.Show("Objet modifié");
                    textBoxNom.Text = "";
                    textBoxPrenom.Text = "";
                    textBoxTelephonePortable.Text = "";
                    textBoxTéléphoneFixe.Text = "";
                    datePickerDateArrivee.Text = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur interne, l'objet courant n'a pas été modifié");
                }
            }
            else
            {
                MessageBox.Show("Les champs ont été mal renseignés");
            }
        }
    }
}
