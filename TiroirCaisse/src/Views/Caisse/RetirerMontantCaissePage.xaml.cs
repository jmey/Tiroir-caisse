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

namespace TiroirCaisse.src.Views.Caisse
{
    /// <summary>
    /// Logique d'interaction pour RetirerMontantCaissePage.xaml
    /// </summary>
    public partial class RetirerMontantCaissePage : Page
    {
        private CaisseController controller { get; set; }
        public RetirerMontantCaissePage()
        {
            controller = new CaisseController();
            InitializeComponent();
        }

        private MontantRetireCaisse createMontantRetireCaisseFromView()
        {
            float resParse;
            if (!float.TryParse(textBoxMontant.Text, out resParse))
                return null;
            string test = ((ComboBoxItem)textBoxType.SelectedItem).Content.ToString();
            MontantRetireCaisse res = new MontantRetireCaisse(DateTime.Now, resParse, test);
            return res;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MontantRetireCaisse montantRetire = createMontantRetireCaisseFromView();
            if (montantRetire != null)
            {
                int res = controller.addRetirementCaisse(montantRetire);
                if(res == 1)
                {
                    MessageBox.Show("Entrée effectuée avec succès", "OK");
                    textBoxMontant.Text = "";
                    textBoxType.Text = "";
                }
                else
                {
                    MessageBox.Show("Erreur interne lors de l'ajout", "Erreur");
                }
            }
            else
            {
                MessageBox.Show("Veuillez vérifier que les informations sont correctes");
            }

        }
    }
}
