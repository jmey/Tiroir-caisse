   M S B A M L   `   `   `  ����G  CTiroirCaisse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TiroirCaisse.src.Views.VentesTiroirCaisse.src.Views.Ventes  5      4    .TiroirCaisse.src.Views.Ventes.AjouterVentePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:TiroirCaisse.src.Views.Ventes     5      -   5          N� Title$  AjouterVentePage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��0.25* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   .+�5      �� $ Vertical=�6   $	��300��60   .+�5      ]� ��.  $��	0,20,0,20q�62   .+�5      �� $��Vendeur��6   $
��Left=�6/   $
��Left=�6J   $��20(�6`   �� 5      -   5        $��comboBox_vendeur��5   �   $	��200��6    �� Text$  ��6+   $��Right=�63   $��20(�6J    �� DisplayMemberPath$ Prenom��6~    �� 
IsEditable . ��6X   �� *listVendeurs+6�   5      ]� 5      ��.  $��	0,20,0,20q�62   .+�5      �� $��Client��6   $
��Left=�6-   $
��Left=�6H   $��20(�6^   �� 5      -   5        $��comboBox_client��5   �   $	��200��6   $  ��6+   $��Right=�63   $��20(�6J   $ FullName��6|    . ��6X   �� *listClients+6�   5      5      ]� 5      ��.  .+�5      �� $ 
Horizontal=�6   $
��Left=�66   .+�5      �� $ Vertical=�6!   .+�5      �� $��Catégories Prestation��6    $��20(�6A   $
��Bold"�6O   �� 5       -   5        $"��comboBox_categoriePrestation��5    S   ��6#   �� *listCategoriePrestation+6w   5!      �� 5"      $ Vertical=�6!   .+�5#      �� $��Prestations��6    $��20(�67   $
��Bold"�6E   �� 5$      -   5         ��Name$ listBox_prestation��5$   "   $	��180��6>   $	��150��6J   $��	0,10,10,0q�6Y   $	 Nom��6�   ��6l   �� *listPrestations+6�   5%      5&      �� 5'      $ 
Horizontal=�6   $��Right=�66   $��	0,0,0,150q�6M   .+�5(      �� $ Vertical=�6!   .+�5)      �� $��Familles Produit��6    $��20(�6<   $
��Bold"�6J   �� 5*      -   5        $��comboBoxFamilleProduit��5*   N   ��6#   �� *listFamilleProduit+6l   5+      �� 5,      $ Vertical=�6!   .+�5-      �� $��Catégories Produit��6    $��20(�6>   $
��Bold"�6L   �� 5.      -   5        $��comboBoxCategorieProduit��5.   P   ��6#   �� *listCategorieProduit+6p   5/      �� 50      $ Vertical=�6!   .+�51      �� $��Produits��6    $��20(�64   $
��Bold"�6B   �� 52      -   5        $��listBox_produit��52   �   $	��180��6"   $	��150��6.   $��	10,10,0,0q�6;   $	 Nom��6t   ��6O   �� *listProduits+6�   53      54      55      56      &   System.Windows.Controls.DataGrid  58   
   -	   5        $��dataGrid_Element��58   }   $��1��6      AutoGenerateColumns .     
IsReadOnly . $	��250��6�   $��0,0,0,6q�6�   ��6<   �� *	listItems+	 �� Mode$	 TwoWay=�
   Columns
 59      0  *System.Windows.Controls.DataGridTextColumn  5:      -
   5        	cType��,  &System.Windows.Controls.DataGridColumn   Header$
 Type��5:   L      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Nom+6Z     5;      -   5        cNom��$	 Nom��5;   L   $
 0.5* 6Y    63   �� *Type+6Y     5<      -   5        cID��$
 Prix��5<   N   $
 0.5* 6\    62   �� *	PrixTTC+6\   5>      �� 5?   
   $ Vertical=�6   $��2��6,   $
��Left=�69   .+�5@      � .+�5A      �� $��Cagnotte fidélité��6   $��20(�64   �� 5B      -   5        $��textBox_fidelite��5B   B   $��20(�64   $��20,0,0,0q�6Z   $��60��6l    �� 
IsReadOnly . ��6   �� *
fidelite+6w   �� 5C      $	��€��6   $��20(�6$   $
��Bold"�62   5D      � 5E      $��0,20,0,0q�6   .+�5F      �� $��Utiliser la cagnotte��6   $��20(�67   �� 5G      -   5        $��utiliserFideliteCheckBox��5G      6b   5H      5I      � 5J   
   $��2��6   $��Right=�6!   .+�5K      �� -   5        $��textBox_prixTotal��5K   Q   $��20(�61   $
��Bold"�6?   $��40,0,0,0q�6j   ��6   �� *	PrixTotal+6j   �� 5L      $	��€��6   $��20(�6    $
��Bold"�6.   �� 5M      -   5        $��typePaiement_comboBox��5M      $��	40,0,40,0q�64   $��20(�6G   $	��200��6U   .@�5N      �� .��6   Carte bancaire6/   �� 5O      .��6   	Chèque6'   �� 5P      .��6   
Espèces6(   5R      �� 5S      -   5        $��Valider l'achat��5S      $��20(�6/   $��	40,0,40,0q�6=   6P   5T      5U      5V      