﻿#pragma checksum "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "49BA3FAB1F4715CCC0CBF0432A0DDE2A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TiroirCaisse.src.Views.Ventes;


namespace TiroirCaisse.src.Views.Ventes {
    
    
    /// <summary>
    /// AjouterVentePage
    /// </summary>
    public partial class AjouterVentePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBox_prestation;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBox_produit;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn cType;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn cNom;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn cID;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TiroirCaisse;component/src/views/ventes/ajouterventepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
            ((TiroirCaisse.src.Views.Ventes.AjouterVentePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listBox_prestation = ((System.Windows.Controls.ListBox)(target));
            
            #line 31 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
            this.listBox_prestation.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListBoxPrestation_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listBox_produit = ((System.Windows.Controls.ListBox)(target));
            
            #line 36 "..\..\..\..\..\src\Views\Ventes\AjouterVentePage.xaml"
            this.listBox_produit.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListBoxProduit_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cType = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.cNom = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.cID = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

