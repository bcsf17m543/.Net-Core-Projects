   M S B A M L   `   `   `  ����O  KOnline Grocery Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Online_Grocery_StoreOnline_Grocery_Store  5   	   %    Online_Grocery_Store.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Online_Grocery_Store     5   	     � Title$  Online Grocery Store��5   	   $	��550��6&   $	��800��63   .��5	      �  � ColumnDefinitions 5
   
    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   o� $��20(�6   .@�5      m� $
��File��6   .@�5      m� $��Customer��6    m� CommandParameter$ Customer��5       m� Command 5      �� *UpdateViewCommand+5      m� 5      $��Admin��6   $ Admin��5       5      �� *UpdateViewCommand+5      5      5      �� 5   
   $��Online Grocery Store��6   $��50(�60   
����i��$��Oblique$�6S   $��0,20,0,0q�6g   6{   �� 5   
   $
��Left=�6    �� Orientation$ 
Horizontal=�60   $��1��6I   .+�5       �� $
��Home��5!      $��20q�5"      $
��Home��6!   $��20(�60   ��5       �� *UpdateViewCommand+5"   A   �� 5#      $��Customer��5$      $��20q�5%      $��Customer��6!   $��20(�64   ��5#      �� *UpdateViewCommand+5%   E   �� 5&      $��Admin��5'      $��20q�5(      $��Admin��6   $��20(�6-   ��5&      �� *UpdateViewCommand+5(   >   5)      �� 5*   
   $��2��6   ��6&   �� *SelectedViewModel+6O   5+      5,      