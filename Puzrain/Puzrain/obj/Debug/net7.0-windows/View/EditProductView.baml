   M S B A M L   `   `   `  ����B  >Puzrain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Puzrain.ViewPuzrain.View  5      "    Puzrain.View.EditProductView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Puzrain.View     5      
�������  � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $) #/Puzrain;component/Style/Label.xaml?�6%   %    5      .��5      �� $��0��6   $��1��5      $��10q�5      ._�5   
   �� $��Disabled=�6   $
��Auto=�5      .��5      �� .+�5      ��    	FormLabel#��[  6     add_TitleLabel#���  5      6E   �� 5        FormBorderTextBox#���  6   ._�5      ��   FormTextBox#��[ 6   ��5      �� *Title+.��65   5      5      �� 5      #��[  6     add_DescriptionLabel#���  5      5       �� 5!      #���  6   $	��100��6E   ._�5"      �� #��[ 6    �� TextWrapping$
 Wrap=�5$       �� AcceptsReturn$
 True��5%      ��5#      �� *Description+.��5%   3   5&      5'      �� 5(      #��[  6     add_CategoryLabel#���  5)      6H   �� 5*      #���  6   ._�5+      �� #��[ 6   ��5,      �� *
Category+6:   5-      �� 5.      #��[  6     add_PriceLabel#���  5/      6E   �� 50      #���  6   ._�51      �� #��[ 6   ��52      �� *Price+67   53      �� 54      #��[  6     add_StockLabel#���  55      6E   �� 56      #���  6   ._�57      �� #��[ 6   ��58      �� *Stock+67   59      �� 5:      #��[  6     add_ImageLabel#���  5;      6E   � 5<      $��0,0,0,30q�6    � RowDefinitions 5=      �� 5>      $
��40px �6(    � ColumnDefinitions 5A      �� 5B      $��150px �6+   �� 5C      .+�5F      �� $��0��6   $��0��5G       	 OpenFileDialogBorder#��� 	 5H      ._�5I      ��  
 add_OpenImageLabel#��� 
 6!   $
��18px(�5J   !   
�������
������ $��0q�5M   !   ��5N   !   �� *OpenFileDialog+5O      5P      �� 5Q      $
��40px��6   $��0��5R      $��1��5S       �� Padding$ 	20,10,0,0q�5T      ._�5U      �� $
��16px(�6$   ��64   �� *	ImagePath+6Q   5V      5W      �� 5X        SaveProductBorder#���  6   ._�5Y      ��   edit_EditProductButton#���  6   
�������
������ $��18(�5\      $��0q�5]      $
��Bold"�5^      ��5_      �� *EditProduct+5`      5a      5b      5c      5d      