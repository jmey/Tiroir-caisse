using System;
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

namespace TiroirCaisse.src.Views.Prestations
{
    /// <summary>
    /// Logique d'interaction pour AjouterPrestationPage.xaml
    /// </summary>
    public partial class AjouterPrestationPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PrestationController controller = new PrestationController();
        private List<CategoriePrestation> _listCategorie;
        public List<CategoriePrestation> listCategorie
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
        public AjouterPrestationPage()
        {
            this.DataContext = this;
            InitializeComponent();
            listCategorie = controller.getAllCategoriePrestation();
        }
        private Prestation creerPrestationFromView()
        {

            Prestation res = null;
            try
            {
                CategoriePrestation selectedCategorie = null;
                if (comboBoxCategorie.SelectedIndex >= 0)
                {
                    selectedCategorie = listCategorie[comboBoxCategorie.SelectedIndex];
                }
                return new Prestation(textBoxNom.Text, int.Parse(textBoxPrix.Text), textBoxTypePrestation.Text, selectedCategorie);
            }
            catch
            {
            }
            return res;


        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prestation prestationToAdd = creerPrestationFromView();
            if (prestationToAdd != null)
            {
                int res = controller.ajouterPrestation(prestationToAdd);
                if (res == 1)
                {
                    MessageBox.Show("Le produit a été rajouté");
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
        protected void OnPropertyChanged(string name)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
