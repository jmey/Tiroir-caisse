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

namespace TiroirCaisse.src.Views.Caisse
{
    /// <summary>
    /// Logique d'interaction pour MainPageCaisse.xaml
    /// </summary>
    public partial class MainPageCaisse : Page
    {
        public MainPageCaisse()
        {
            InitializeComponent();
            ContentControlVisualisationCaisse.Content = new VisualisationCaissePage();
            ContentControlRetirerCaisse.Content = new RetirerMontantCaissePage();
            ContentControlRetirerCaisseVisualisation.Content = new VisualisationRetirementMontant();
        }
    }
}
