   M S B A M L   `   `   `  ����O  KOnline Grocery Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Online_Grocery_Store.ViewsOnline_Grocery_Store.Views  5      Q-clr-namespace:Online_Grocery_Store.ConvertersOnline_Grocery_Store.Converters  5      -    'Online_Grocery_Store.Views.CustomerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Online_Grocery_Store.Views     5      @local1-clr-namespace:Online_Grocery_Store.Converters     5        � 	Resources  5
      6   0Online_Grocery_Store.Converters.MyMultiConverter   myConverter��%   &	          5   
   68   5      .��5      � 
������� � RowDefinitions 5   
   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   .+�5      �� $��Login��6    �� TextAlignment$ Center=�6%   $��30(�6<   6M   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Name��6   $��20(�6(   68   �� 5      -   5         ��Name$ CustName��5      $	��223��6,   $��30,0,0,0q�68   6L   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Password��6   $��20(�6,   6=   G� 5      -   5         G�Name$ Passwrd��5      $	��223��6/   6=   5       �� 5!      .+�5"      �� -   5         ��Name$ Logbtn��5"      $��Login��6J   $��87��6Z   $��0,20,0,0q�6e   ��6)   �� *LoginCommand+��5#      `� 5$       `� 	Converter# [  6'   .1�5%      �� 	 �� ElementName$	 CustName��6&   6?   �� 5&      $	 Passwrd��6&   6>   �� 5'      $
	 Err1��6&   6;   5(      5*      5+      �� 5,      .+�5-      �� -   5        
 ��Name$

 Err1��5-      
���  ��$��20(�6;   6K   5.      5/      �� 50   
   $��2��6   .+�51      �� $��Sign Up��6   $ Center=�6'   $��30(�6>   6O   �� 53      $ 
Horizontal=�6   .+�54      �� $
��Name��6   $��20(�6(   68   �� 55      -   5        $ 	CustName1��55      $	��236��6-   $��40,0,0,0q�69   6M   56      �� 57      $ 
Horizontal=�6   .+�58      �� $��Password��6   $��20(�6,   6<   G� 59      -   5        $ 	Password1��59      $	��237��61   $��9,0,0,0q�6=   6P   5:      �� 5;      $ 
Horizontal=�6   .+�5<      �� $��Phone no��6   $��20(�6,   6<   �� 5=      -   5        $ Phone��5=      $	��237��6)   $��7,0,10,0q�65   5>      �� 5?      .+�5@      �� -   5        $ Signbtn��5@      $��SignUp��6L   $��74��6]   $��0,20,0,0q�6h   ��6*   �� *SignupCommand+��5A      `� 5B      # [  6'   .1�5C      �� $	 	CustName1��6&   6@   �� 5D      $	 	Password1��6&   6@   �� 5E      $	 Phone��6&   6<   �� 5F      $
	 Err2��6&   6;   5H      5J      5K      �� 5L      .+�5M      �� -	   5        $

 Err2��5M      
���  ��$��20(�6;   6K   5N      5O      5P      5Q      