   M S B A M L   `   `   `  ����B  >Puzrain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Puzrain.ViewPuzrain.View  5          Puzrain.View.ProductView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Puzrain.View     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $��220px �6    �� 5      .+�5   
   �� $��0��6   $��10q�5      .+�5      �� $��200px��6   $��200px��6#   ._�5      �� $��200px��6   $��200px��6&   ��65   ��  �� Path$ Product.Image�5      �� 5      $	��200��6   $��30��6!   $��0,5,0,0q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��16px(�6    $��Center=�5         product_PriceTextBox#���   5      $��0,0,5,0q�5      5       �� 5!      $��20(�6    $��Medium"�5"      $��Center=�5#      ��5$      ��  �� StringFormat$ {0} ₽��$ Product.Price�5%      5&      5'      �� 5(      $	��200��6   $��30��6!   $��0,5,0,0q�5)      ._�5*      �� $ 
Horizontal=�6   .+�5+      �� $
��16px(�6    $��Center=�5,        product_CategoryTextBox#���  5-      $��0,0,5,0q�5.      5/      �� 50      $
��16px(�6    $��Center=�51      $��Medium"�52      ��53      �� *Product.Category+54      55      56      �� 57      $	��200��6   $��30��6!   $��0,5,0,0q�58      ._�59      �� $ 
Horizontal=�6   .+�5:      �� $
��16px(�6    $��Center=�5;        product_StockTextBox#���  5<      $��0,0,5,0q�5=      5>      �� 5?      $
��20px(�6    $��Center=�5@      $��Medium"�5A      ��5B      �� *Product.Stock+5C      5D      5E      �� 5F      $ 
Horizontal=�6   $��0,5,0,0q�5G      .+�5H      �� $��30��6   $��30��5I      $��0,0,5,0q�5J      ._�5K      �� 
������ 
���   �$��1q�5M      ��5N      �� *RemoveProduct+.��5O      �� $;��5D:\ООП_Мущук\Puzrain\Puzrain\Images\trash.png��6    5P      5Q      �� 5R      $��30��6   $��30��5S      ._�5T      �� 
������ 
���   �$��1q�5V      ��5W      �� *OpenEditProduct+.��5X      �� $:��4D:\ООП_Мущук\Puzrain\Puzrain\Images\edit.png��6    5Y      5Z      5[      5\      �� 5]   
   $
��Auto=�6   $��1��5^      $��10q�5_      .��5`      �� .+�5a      �� $��36(�6   $��Medium"�5b      $��0,0,0,20q�5c      ��5d      �� *Product.Title+5e      �� 5f      $��16(�6   $
��Wrap=�5g      ��5h      �� *Product.Description+5i      5j      5k      5l      5m      