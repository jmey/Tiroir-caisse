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

namespace TiroirCaisse.src.Views.Ventes
{
    /// <summary>
    /// Logique d'interaction pour AjouterVentePage.xaml
    /// </summary>
    public partial class AjouterVentePage : Page, INotifyPropertyChanged
    {
        private VenteController controller { get; set; }
        private ProduitController pController { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Vendeur> _listVendeurs{ get; set; }
        public List<Vendeur> listVendeurs
        {
            get
            {
                return _listVendeurs;
                
            }
            set
            {
                _listVendeurs = value;
                OnPropertyChanged("listVendeurs");
            }
        }
        private List<Client> _listClients { get; set; }
        public List<Client> listClients
        {
            get
            {
                return _listClients;

            }
            set
            {
                _listClients = value;
                OnPropertyChanged("listClients");
            }
        }
        private List<Prestation> _listPrestations { get; set; }
        public List<Prestation> listPrestations
        {
            get
            {
                return _listPrestations;

            }
            set
            {
                _listPrestations = value;
                OnPropertyChanged("listPrestations");
            }
        }

        private List<Produit> _listProduits { get; set; }
        public List<Produit> listProduits
        {
            get
            {
                return _listProduits;

            }
            set
            {
                _listProduits = value;
                OnPropertyChanged("listProduits");
            }
        }

        private List<Element> _listItems { get; set; }
        public List<Element> listItems
        {
            get
            {
                return _listItems;

            }
            set
            {
                _listItems = value;
                OnPropertyChanged("listItems");
            }
        }

        private float _PrixTotal { get; set; }
        public float PrixTotal
        {
            get
            {
                return _PrixTotal;

            }
            set
            {
                _PrixTotal = value;
                OnPropertyChanged("PrixTotal");
            }
        }

        private List<CategoriePrestation> _listCategoriePrestation { get; set; }
        public List<CategoriePrestation> listCategoriePrestation
        {
            get
            {
                return _listCategoriePrestation;

            }
            set
            {
                _listCategoriePrestation = value;
                OnPropertyChanged("listCategoriePrestation");
            }
        }

        private List<CategorieProduit> _listCategorieProduit { get; set; }
        public List<CategorieProduit> listCategorieProduit
        {
            get
            {
                return _listCategorieProduit;

            }
            set
            {
                _listCategorieProduit = value;
                OnPropertyChanged("listCategorieProduit");
            }
        }

        private List<FamilleProduit> _listFamilleProduit { get; set; }
        public List<FamilleProduit > listFamilleProduit
        {
            get
            {
                return _listFamilleProduit;
            }
            set
            {
                _listFamilleProduit = value;
                OnPropertyChanged("listFamilleProduit");
            }
        }
        public AjouterVentePage()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new VenteController();
            pController = new ProduitController();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listVendeurs = controller.getAllVendeurs();
            listClients = controller.getAllClients();
            listPrestations = controller.getAllPrestations();
            listProduits = controller.getAllProduits();
            listFamilleProduit = controller.getAllFamille();
            listCategoriePrestation = controller.getAllCategoriePrestation();
            listCategorieProduit = controller.getAllCategoriePoduit();

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ListBoxPrestation_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (listBox_prestation.SelectedItem != null)
            {
               Prestation selectedPrestation = (Prestation)listBox_prestation.SelectedItem;
                dataGrid_Element.Items.Add(selectedPrestation);
                PrixTotal += selectedPrestation.PrixTTC;
            }
        }

        private void ListBoxProduit_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (listBox_produit.SelectedItem != null)
            {
                Produit selectedProduit = (Produit)listBox_produit.SelectedItem;
                dataGrid_Element.Items.Add(selectedProduit);
                PrixTotal += selectedProduit.PrixTTC;
            }
        }

        private Vente creerVenteFromView()
        {
            Vente vente = null;
            if (typePaiement_comboBox != null && typePaiement_comboBox.SelectedIndex >= 0)
            {
                List<Prestation> listPrestation = new List<Prestation>();
                List<Produit> listProduit = new List<Produit>();
                Client client = null;
                Vendeur vendeur = null;
                
                if (comboBox_client.SelectedIndex != -1 && comboBox_vendeur.SelectedIndex != -1)
                {
                    client = listClients[comboBox_client.SelectedIndex];
                    vendeur = listVendeurs[comboBox_vendeur.SelectedIndex];
                }
                foreach (Element elem in dataGrid_Element.Items)
                {
                    if (elem is Prestation)
                    {
                        listPrestation.Add((Prestation)elem);
                    }
                    else if (elem is Produit)
                    {
                        listProduit.Add((Produit)elem);
                    }
                }
                float prixTotal;
                if (float.TryParse(textBox_prixTotal.Text, out prixTotal))
                {
                    if (client != null && vendeur != null)
                    {
                        string typePaiement = "";
                        string test = ((ComboBoxItem)typePaiement_comboBox.SelectedItem).Content.ToString();
                        if (test == "Carte bancaire")
                            typePaiement = "cb";
                        else if (test == "Espèces")
                            typePaiement = "especes";
                        else if (test == "Chèque")
                            typePaiement = "cheque";
                        if (typePaiement != "")
                            vente = new Vente(prixTotal, client, vendeur, listProduit, listPrestation, typePaiement, DateTime.Now);

                    }
                }
            }
            return vente;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Vente vente = creerVenteFromView();
            if (vente != null && vente.PrixTotal >= 0)
            {
                int res = controller.ajouterVente(vente);
                if(res < 2)
                {
                    MessageBox.Show("Erreur interne durant l'ajout", "Erreur");
                }
                else
                {
                    MessageBox.Show("Vente ajouté", "OK");
                    foreach (Produit p in vente.ListProduit)
                        pController.decrementStockProduit(p);
                }
            }
            else
            {
                MessageBox.Show("Des champs ne sont pas remplies", "Erreur");
            }
        }

        private void comboBox_categoriePrestation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox_categoriePrestation.SelectedIndex>=0)
            {
                CategoriePrestation selectedCategoriePrestation = listCategoriePrestation[comboBox_categoriePrestation.SelectedIndex];
                listPrestations = controller.getPrestationByCategorie(selectedCategoriePrestation);
            }
           
        }

        private void comboBoxFamilleProduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxFamilleProduit.SelectedIndex >= 0)
            {
                FamilleProduit selectedFamilleProduit = listFamilleProduit[comboBoxFamilleProduit.SelectedIndex];
                listCategorieProduit = controller.getCategorieProduitByFamille(selectedFamilleProduit);
                listProduits = controller.getProduitByFamille(selectedFamilleProduit);
            }
        }

        private void comboBoxCategorieProduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCategorieProduit.SelectedIndex >= 0)
            {
                CategorieProduit selectedCategorieProduit = listCategorieProduit[comboBoxCategorieProduit.SelectedIndex];
                listProduits = controller.getProduitByCategorie(selectedCategorieProduit);
            }
        }

        private void dataGrid_Element_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                Element selectedElement = dataGrid_Element.SelectedItem as Element;
                if (selectedElement != null)
                {
                    PrixTotal -= selectedElement.PrixTTC;
                    dataGrid_Element.Items.Remove(selectedElement);
                }
                
            }
        }
    }
}
