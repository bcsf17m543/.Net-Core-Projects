   M S B A M L   `   `   `  ���� O  KOnline Grocery Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Online_Grocery_Store.ViewsOnline_Grocery_Store.Views  Q-clr-namespace:Online_Grocery_Store.ViewModelsOnline_Grocery_Store.ViewModels  Q-clr-namespace:Online_Grocery_Store.ConvertersOnline_Grocery_Store.Converters  *    $Online_Grocery_Store.Views.AdminView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:Online_Grocery_Store.Views     D
viewModels-clr-namespace:Online_Grocery_Store.ViewModels     @local1-clr-namespace:Online_Grocery_Store.Converters       � 	Resources  6   0Online_Grocery_Store.Converters.MyMultiConverter   myConverter��%   &	          .��� 
������� J� RenderTransformOrigin$ 0.576,0.502&� � ColumnDefinitions �� ��  � RowDefinitions �� .+���  �� Orientation$ Vertical=�$��0��$��0��.+��� $��Add New Product��$��30(��� $ 
Horizontal=�.+��� $��
Product Id��$��25(�$��10,0,0,0q��� -    ��Name$ ID��$��25(�$	��207��$��50,0,0,0q��� $ 
Horizontal=�.+��� $��Product Name��$��25(�$��10,0,0,0q��� -   $
 NAME��$��25(�$	��207��$��5,0,0,0q��� $ 
Horizontal=�.+��� $��Product Price��$��25(�$��10,0,0,0q��� -   $ PRICE��$��25(�$	��207��$��18,0,0,0q��� $ 
Horizontal=�$��10,0,0,0q�.+��� $��Product Qnty��$��25(��� -   $	 QTY��$��25(�$	��207��$��17,0,0,0q��� .+��� -    ��Name$ errMsg��
���  ��$
��Left=�$��	178,0,0,0q�$��3��$ -0.163,-0.354&�$��44��$	��221��$��18(��� .+��� $��For deleting a product��$��20(��� $��Product Id:��$��20(��� -   $ prodId��$��38��$	��251��$��	100,0,0,0q��� $��1��.+��� -    ��Name$ AddProd��$��Add Product��$��16(����� *cmd1+��`�  `� 	Converter# [  	 `� UpdateSourceTrigger$	 PropertyChanged=�.1��� 
 �� ElementName$
 ID���� $

 NAME���� $
 PRICE���� $	
 QTY���� $
 errMsg�� �� Mode$ OneWay=��� -   $ 
DeleteProd��$��Delete Product��$��16(�$��0,30,0,0q����� *cmd2+���� $
 prodId���� -	   $ 	View_Prod��$��View Product��$��16(�$��0,30,0,0q����� *cmd3+�� -
   $ LogOut��$��LogOut��$��Logout��$��16(�$��0,30,0,0q����� *UpdateViewCommand+�� ���� *SelectedViewModel+