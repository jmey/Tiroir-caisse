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
using TiroirCaisse.src.Controllers;
using TiroirCaisse.src.Entities;

namespace TiroirCaisse.src.Views.Produits
{
    /// <summary>
    /// Logique d'interaction pour AjouterCategorieProduitPage.xaml
    /// </summary>
    public partial class AjouterCategorieProduitPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ProduitController produitController = new ProduitController();
        public AjouterCategorieProduitPage()
        {
            InitializeComponent();
            DataContext = this;
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


        private CategorieProduit creerCategorieFromView()
        {
            CategorieProduit res = null;
            if(comboBox_famille.SelectedIndex < 0)
            {
                return null;
            }
            FamilleProduit famille = listFamille[comboBox_famille.SelectedIndex];
            if (famille != null)
            {
                try
                {
                    res = new CategorieProduit(textBoxNom.Text, famille);
                }
                catch
                {
                }
            }
            return res;          
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CategorieProduit categorieToAdd = creerCategorieFromView();
            if (categorieToAdd != null)
            {
                int res = produitController.ajouterCategorieProduit(categorieToAdd);
                if (res == 1)
                {
                    MessageBox.Show("La catégorie a été rajouté");
                    textBoxNom.Text = "";
                    comboBox_famille.Text = "";
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            listFamille = produitController.getAllFamilleProduit();
            
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
