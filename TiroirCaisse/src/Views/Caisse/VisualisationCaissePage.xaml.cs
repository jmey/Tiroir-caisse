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

namespace TiroirCaisse.src.Views.Caisse
{
    /// <summary>
    /// Logique d'interaction pour VisualisationCaissePage.xaml
    /// </summary>
    public partial class VisualisationCaissePage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool loadFinish;
        private CaisseController controller { get; set; }

        private string _montantCBRecu { get; set; }
        private string _montantCBPris { get; set; }
        private string _montantCBTotal { get; set; }

        private string _montantEspeceRecu { get; set; }
        private string _montantEspecePris { get; set; }
        private string _montantEspeceTotal { get; set; }

        private string _montantChequeRecu { get; set; }
        private string _montantChequePris { get; set; }
        private string _montantChequeTotal { get; set; }

        private string _montantTotalRecu { get; set; }
        private string _montantTotalPris { get; set; }
        private string _montantTotalTotal { get; set; }

        private DateTime _dateDebut { get; set; }
        private DateTime _dateFin { get; set; }

        public string montantCBRecu 
        {
            get { return _montantCBRecu; }
            set
            {
                _montantCBRecu = value;
                OnPropertyChanged("montantCBRecu");
            }
        }
        public string montantCBPris
        {
            get { return _montantCBPris; }
            set
            {
                _montantCBPris = value;
                OnPropertyChanged("montantCBPris");
            }
        }
        public string montantCBTotal
        {
            get { return _montantCBTotal; }
            set
            {
                _montantCBTotal = value;
                OnPropertyChanged("montantCBTotal");
            }
        }

        public string montantEspeceRecu
        {
            get { return _montantEspeceRecu; }
            set
            {
                _montantEspeceRecu = value;
                OnPropertyChanged("montantEspeceRecu");
            }
        }
        public string montantEspecePris
        {
            get { return _montantEspecePris; }
            set
            {
                _montantEspecePris = value;
                OnPropertyChanged("montantEspecePris");
            }
        }
        public string montantEspeceTotal
        {
            get { return _montantEspeceTotal; }
            set
            {
                _montantEspeceTotal = value;
                OnPropertyChanged("montantEspeceTotal");
            }
        }

        public string montantChequeRecu
        {
            get { return _montantChequeRecu; }
            set
            {
                _montantChequeRecu = value;
                OnPropertyChanged("montantChequeRecu");
            }
        }
        public string montantChequePris
        {
            get { return _montantChequePris; }
            set
            {
                _montantChequePris = value;
                OnPropertyChanged("montantChequePris");
            }
        }
        public string montantChequeTotal
        {
            get { return _montantChequeTotal; }
            set
            {
                _montantChequeTotal = value;
                OnPropertyChanged("montantChequeTotal");
            }
        }

        public string montantTotalRecu
        {
            get { return _montantTotalRecu; }
            set
            {
                _montantTotalRecu = value;
                OnPropertyChanged("montantTotalRecu");
            }
        }
        public string montantTotalPris
        {
            get { return _montantTotalPris; }
            set
            {
                _montantTotalPris = value;
                OnPropertyChanged("montantTotalPris");
            }
        }
        public string montantTotalTotal
        {
            get { return _montantTotalTotal; }
            set
            {
                _montantTotalTotal = value;
                OnPropertyChanged("montantTotalTotal");
            }
        }

        public DateTime dateDebut
        {
            get { return _dateDebut; }
            set
            {
                _dateDebut = value;
                OnPropertyChanged("dateDebut");
            }
        }

        public DateTime dateFin
        {
            get { return _dateFin; }
            set
            {
                _dateFin = value;
                _dateFin = _dateFin.AddHours(23).AddMinutes(59).AddSeconds(59);
                OnPropertyChanged("dateFin");
            }
        }

        public VisualisationCaissePage()
        {
            loadFinish = false;
            controller = new CaisseController();
            this.DataContext = this;
            InitializeComponent();
            
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dateDebut = DateTime.Now;
            dateFin = DateTime.Now;
            datePickerDebut.Text = DateTime.Now.ToLongDateString();
            datePickerFin.Text = DateTime.Now.ToLongDateString();
            datePickerFin.DisplayDateEnd = DateTime.Today;
            datePickerDebut.DisplayDateEnd = DateTime.Today;
            loadFinish = true;
            MajValeur();
        }


        private void datePickerDebut_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MajValeur();
        }
        private void MajValeur()
        {
            if (loadFinish)
            {
                montantCBRecu = controller.getMontantRecuBetweenDate("cb", dateDebut, dateFin).ToString();
                montantEspeceRecu = controller.getMontantRecuBetweenDate("espece", dateDebut, dateFin).ToString();
                montantChequeRecu = controller.getMontantRecuBetweenDate("cheque", dateDebut, dateFin).ToString();
                montantTotalRecu = (float.Parse(montantCBRecu) + float.Parse(montantEspeceRecu) + float.Parse(montantChequeRecu)).ToString();

                montantCBPris = controller.getMontantRetireBetweenDate("cb", dateDebut, dateFin).ToString();
                montantEspecePris = controller.getMontantRetireBetweenDate("espece", dateDebut, dateFin).ToString();
                montantChequePris = controller.getMontantRetireBetweenDate("cheque", dateDebut, dateFin).ToString();
                montantTotalPris = (float.Parse(montantCBPris) + float.Parse(montantEspecePris) + float.Parse(montantChequePris)).ToString();

                montantCBTotal = (float.Parse(montantCBRecu) - float.Parse(montantCBPris)).ToString();
                montantEspeceTotal = (float.Parse(montantEspeceRecu) - float.Parse(montantEspecePris)).ToString();
                montantChequeTotal = (float.Parse(montantChequeRecu) - float.Parse(montantChequePris)).ToString();
                montantTotalTotal = (float.Parse(montantCBTotal) + float.Parse(montantEspeceTotal) + float.Parse(montantChequeTotal)).ToString();
            }
        }

    }
}
