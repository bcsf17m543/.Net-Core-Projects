   M S B A M L   `   `   `  ����O  KOnline Grocery Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Online_Grocery_Store.ViewsOnline_Grocery_Store.Views  5   	   Q-clr-namespace:Online_Grocery_Store.ConvertersOnline_Grocery_Store.Converters  6@   -    'Online_Grocery_Store.Views.SampleWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Online_Grocery_Store.Views     5   	   @local1-clr-namespace:Online_Grocery_Store.Converters     6@     � Title$  Customer Cart��5   	   $	��450��6   $	��960��6,    � 	Resources 5	      6   0Online_Grocery_Store.Converters.MyMultiConverter   myConverter��%   &	          5
   
   68   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��50(�6   $��0��5      $��0��5      $��Customer Side��5      $��2��5      $��Center=�5      $��0,0,0,31q�61   $��5��6C   $	��330��6T   5       �� 5#   
   $��0��6   .+�5$      ��  �� Orientation$ 
Horizontal=�6   $��0,30,0,0q�62   .+�5%      �� $��Item Id��6   6-   �� 5&      -   5         ��Name$	 TID��5&      $	��150��6l   $��10,0,0,0q�6x   ��6'   �� *ID+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   5'      �� 5(      $ 
Horizontal=�6   .+�5*      �� $��Quantity��6   $��0,10,0,0q�6,   6@   �� 5+      -   5        $	 QTY��5+      $	��151��6m   ��6'   �� *Qty+$ PropertyChanged=�$ TwoWay=�6{   5-      5.      �� 5/   
   $��Center=�6   $��1��63   $��4��6C   $ 
Horizontal=�6P   .+�50      �� $��	20,0,20,0q�6   $��Add Item��6G   $��20(�6Z   $	��112��6h   ��6(   �� *
AddCommand+52      �� 53      $��	20,0,20,0q�6   $��Print Receipt��6I   $��20(�6a   $	��117��6o   ��6(   �� *PrintCommand+55      �� 56      -   5         ��Name$ 
Logout_btn��56      $��Logout��6)   $��20(�6:   $��10,0,0,0q�6H   6u   57      �� 59   
   -   5        	 ��Name$	 MyItems��59      $��6��6$   $��
0,0,0,-206q�61   
 �� View
 5:      �� 5;      .P�5<      �� $��
Product Id��6%    �� Width$	 120��69    �� DisplayMemberBinding 6E   �� *Id+�� 5=      $��Product Name��6%   $	 120��6;    6G   �� *
Prodname+�� 5>      $��Product Price��6%   $	 120��6<    6H   �� *Price+�� 5?      $��Product Quantity��6%   $	 120��6?    6K   �� *Qty+5A      5C      �� 5D   
   -   5        $	 MyCart��5D      $��3��6M   $��6��6]   $��
0,0,0,-206q�6j   ��6#   ��  �� Path$ cusSer.prods�
 5E      �� 5F      .P�5G      �� $��
Product Id��6%   $	 120��69    6E   �� *Id+�� 5H      $��Product Name��6%   $	 120��6;    6G   �� *
Prodname+�� 5I      $��Product Price��6%   $	 120��6<    6H   �� *Price+�� 5J      $��Product Quantity��6%   $	 120��6?    6K   �� *Qty+5L      5N      5O      5P      