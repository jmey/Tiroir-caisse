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

namespace TiroirCaisse.src.Views.Forfaits
{
    /// <summary>
    /// Logique d'interaction pour MainPageForfait.xaml
    /// </summary>
    public partial class MainPageForfait : Page
    {
        public MainPageForfait()
        {
            InitializeComponent();
            ContentControlAjouterForfait.Content = new AjouterForfaitPage();
            ContentControlVisualisationForfaits.Content = new VisualisationForfaitPage();

        }
    }
}
