   M S B A M L   `   `   `  ���� O  KOnline Grocery Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Online_Grocery_Store.ViewsOnline_Grocery_Store.Views  Q-clr-namespace:Online_Grocery_Store.ConvertersOnline_Grocery_Store.Converters  -    'Online_Grocery_Store.Views.SampleWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:Online_Grocery_Store.Views     @local1-clr-namespace:Online_Grocery_Store.Converters       � Title$  Customer Cart��$	��450��$	��960�� � 	Resources 6   0Online_Grocery_Store.Converters.MyMultiConverter   myConverter��%   &	          .���  � ColumnDefinitions �� $
��auto ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��50(�$��0��$��0��$��Customer Side��$��2��$��Center=�$��0,0,0,31q�$��5��$	��330���� $��0��.+���  �� Orientation$ 
Horizontal=�$��0,30,0,0q�.+��� $��Item Id���� -    ��Name$	 TID��$	��150��$��10,0,0,0q����� *ID+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $ 
Horizontal=�.+��� $��Quantity��$��0,10,0,0q��� -   $	 QTY��$	��151������ *Qty+$ PropertyChanged=�$ TwoWay=��� $��Center=�$��1��$��4��$ 
Horizontal=�.+��� $��	20,0,20,0q�$��Add Item��$��20(�$	��112������ *
AddCommand+�� $��	20,0,20,0q�$��Print Receipt��$��20(�$	��117������ *PrintCommand+�� -    ��Name$ 
Logout_btn��$��Logout��$��20(�$��10,0,0,0q��� -   $��Finish��$��20(�$��10,0,0,0q����� *FinishCommand+�� -   	 ��Name$	 MyItems��$��6��$��
0,0,0,-206q�
 �� View
 �� .P��� $��
Product Id�� �� Width$	 120�� �� DisplayMemberBinding �� *Id+�� $��Product Name��$	 120�� �� *
Prodname+�� $��Product Price��$	 120�� �� *Price+�� $��Product Quantity��$	 120�� �� *Qty+�� -   $	 
Myshopping��$��3��$��6��$��
0,0,0,-206q����� *MyCart+
 �� .P��� $��
Product Id��$	 120�� �� *Id+�� $��Product Name��$	 120�� �� *
Prodname+�� $��Product Price��$	 120�� �� *Price+�� $��Product Quantity��$	 120�� �� *Qty+