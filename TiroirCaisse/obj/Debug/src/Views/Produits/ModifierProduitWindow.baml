   M S B A M L   `   `   `  ����G  CTiroirCaisse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:TiroirCaisse.src.Views.ProduitsTiroirCaisse.src.Views.Produits  5   	   ;    5TiroirCaisse.src.Views.Produits.ModifierProduitWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:TiroirCaisse.src.Views.Produits     5   	     � Title$  Modification��5   	   $	��615��6   $��513.529��6+   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   $
��Left=�6,   $��	36,50,0,0q�6G   .+�5      ]� ��.  .+�5      �� -   5         ��Name$ label��5      $	��Nom��6'   $
��Left=�65   $
��Left=�6P   $��20(�6f   �� 5      -   5         ��Name$ 
textBoxNom��5      $	��200��6.   $�� ��6:   $��Right=�6B   $��20(�6Y   5      ]� 5      ��.  $��0,10,0,0q�6.   .+�5      �� -   5        $ label2��5      $
��Type��6(   $
��Left=�67   $
��Left=�6R   $��20(�6h   �� 5      -   5        $ textBoxType��5      $	��200��6/   $�� ��6;   $��Right=�6C   $��20(�6Z   5      ]� 5      ��.  $��0,10,0,0q�6.   .+�5      �� -   5        $ label3��5      $��Nombre en stock��6(   $
��Left=�6B   $
��Left=�6]   $��20(�6s   �� 5      -   5        $ textBoxNombreStock��5      $	��200��66   $�� ��6B   $��Right=�6J   $��20(�6a   5      ]� 5      ��.  $��0,10,0,0q�6.   .+�5      �� -   5        $ label4��5      $��Seuil d'alerte��6(   $
��Left=�6A   $
��Left=�6\   $��20(�6r   �� 5      -   5        $ textBoxSeuilAlerte��5      $	��200��66   $�� ��6B   $��Right=�6J   $��20(�6a   5      ]� 5      ��.  $��0,10,0,0q�6.   .+�5      �� -	   5        $ label5��5      $��Fournisseur��6(   $
��Left=�6>   $
��Left=�6Y   $��20(�6o   �� 5      -
   5        $ textBoxFournisseur��5      $	��200��66   $�� ��6B   $��Right=�6J   $��20(�6a   5      ]� 5      ��.  $��0,10,0,0q�6.   .+�5       �� -   5        $ label6��5       $��Référence Fournisseur��6(   $
��Left=�6H   $
��Left=�6c   $��20(�6y   �� 5!      -   5        $! textBoxReferenceFournisseur��5!      $	��200��6?   $�� ��6K   $��Right=�6S   $��20(�6j   5"      ]� 5#      ��.  $��0,10,0,0q�6.   .+�5$      �� -   5        $ label7��5$      $
��Prix��6(   $
��Left=�67   $
��Left=�6R   $��20(�6h   �� 5%      -   5        $ textBoxPrix��5%      $	��200��6/   $�� ��6;   $��Right=�6C   $��20(�6Z   5&      ]� 5'      ��.  $��0,10,0,0q�6.   .+�5(      �� -   5        $ label8��5(      $��Prix Fournisseur��6(   $
��Left=�6C   $
��Left=�6^   $��20(�6t   �� 5)      -   5        $ textBoxPrixFournisseur��5)      $	��200��6:   $�� ��6F   $��Right=�6N   $��20(�6e   5*      ]� 5+      ��.  $��0,10,0,0q�6.   .+�5,      �� -   5        $ label9��5,      $��Famille��6(   $
��Left=�6:   $
��Left=�6U   $��20(�6k   �� 5-      -   5         ��Name$ ComboBoxFamille��5-      $	��200��64    �� Text$  ��6@   $��Right=�6H   $��20(�6_    �� DisplayMemberPath$	 Nom��6o    �� SelectedValuePath$	 Nom��6�   6�   5.      ]� 5/      ��.  $��0,10,0,0q�6.   .+�50      �� -   5        $ label10��50      $��
Catégorie��6)   $
��Left=�6=   $
��Left=�6X   $��20(�6n   �� 51      -   5        $ ComboBoxCategorie��51      $	��200��66   $  ��6B   $��Right=�6J   $��20(�6a   $	 Nom��6q   $	 Nom��6�   52      �� 53      -   5        $��Valider��53      $��0,10,0,0q�6'   $��20(�69   6G   54      55      56      