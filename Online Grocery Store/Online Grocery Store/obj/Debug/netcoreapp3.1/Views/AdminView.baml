   M S B A M L   `   `   `  ����O  KOnline Grocery Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Online_Grocery_Store.ViewsOnline_Grocery_Store.Views  5      Q-clr-namespace:Online_Grocery_Store.ViewModelsOnline_Grocery_Store.ViewModels  5      Q-clr-namespace:Online_Grocery_Store.ConvertersOnline_Grocery_Store.Converters  5      *    $Online_Grocery_Store.Views.AdminView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Online_Grocery_Store.Views     5      D
viewModels-clr-namespace:Online_Grocery_Store.ViewModels     5      @local1-clr-namespace:Online_Grocery_Store.Converters     5        � 	Resources  5      6   0Online_Grocery_Store.Converters.MyMultiConverter   myConverter��%   &	          5   
   68   5      .��5      � 
������� J� RenderTransformOrigin$ 0.576,0.502&�6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0��69   .+�5      �� $��Add New Product��6   $��30(�6/   6?   �� 5      $ 
Horizontal=�6   .+�5      �� $��
Product Id��6   $��25(�6.   $��10,0,0,0q�6<   6P   �� 5      -   5         ��Name$ ID��5      $��25(�6(   $	��207��66   $��50,0,0,0q�6B   6V   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Product Name��6   $��25(�60   $��10,0,0,0q�6>   6R   �� 5      -   5        $
 NAME��5      $��25(�6)   $	��207��67   $��5,0,0,0q�6C   6V   5      �� 5       $ 
Horizontal=�6   .+�5!      �� $��Product Price��6   $��25(�61   $��10,0,0,0q�6?   6S   �� 5"      -   5        $ PRICE��5"      $��25(�6*   $	��207��68   $��18,0,0,0q�6D   6X   5#      �� 5$      $ 
Horizontal=�6   $��10,0,0,0q�62   .+�5%      �� $��Product Qnty��6   $��25(�60   6@   �� 5&      -   5        $	 QTY��5&      $��25(�6(   $	��207��66   $��17,0,0,0q�6B   6V   5'      �� 5(      .+�5)      �� -   5         ��Name$ errMsg��5)      
���  ��$
��Left=�6@   $��	178,0,0,0q�6[   $��3��6n   $ -0.163,-0.354&�6{   $��44��6�   $	��221��6�   $��18(�6�   5+      �� 5,      .+�5-      �� $��For deleting a product��6   $��20(�6:   6J   �� 5.      $��Product Id:��6   $��20(�6/   6?   �� 5/      -   5        $ prodId��5/      $��38��6*   $	��251��66   $��	100,0,0,0q�6B   6W   50      51      �� 52   
   $��1��6   .+�53      �� -   5         ��Name$ AddProd��53      $��Add Product��6?   $��16(�6U   ��6&   �� *cmd1+��54      `� 55       `� 	Converter# [  6#   	 `� UpdateSourceTrigger$	 PropertyChanged=�6L   .1�56      �� 
 �� ElementName$
 ID��6#   �� 57      $

 NAME��6#   �� 58      $
 PRICE��6#   �� 59      $	
 QTY��6#   �� 5:      $
 errMsg��6#    �� Mode$ OneWay=�68   5;      5=      �� 5>      -   5        $ 
DeleteProd��5>      $��Delete Product��6)   $��16(�6\   $��0,30,0,0q�6j   ��6C   �� *cmd2+��5?      �� 5@      $
 prodId��6   5B      �� 5C      -	   5        $ 	View_Prod��5C      $��View Product��6(   $��16(�6X   $��0,30,0,0q�6f   ��6?   �� *cmd3+6f   �� 5D      -
   5        $ LogOut��5D      $��LogOut��6K   $��Logout��6e   $��16(�6v   $��0,30,0,0q�6�   ��6%   �� *UpdateViewCommand+6�   5E      �� 5F   
   ��6   �� *SelectedViewModel+6C   5I      5J      