   M S B A M L   `   `   `  ���� O  KOnline Grocery Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Online_Grocery_Store.ViewsOnline_Grocery_Store.Views  Q-clr-namespace:Online_Grocery_Store.ConvertersOnline_Grocery_Store.Converters  -    'Online_Grocery_Store.Views.CustomerView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:Online_Grocery_Store.Views     @local1-clr-namespace:Online_Grocery_Store.Converters       � 	Resources  6   0Online_Grocery_Store.Converters.MyMultiConverter   myConverter��%   &	          .��� 
������� � RowDefinitions ��  � ColumnDefinitions �� �� .+��� $��0��.+��� $��Login�� �� TextAlignment$ Center=�$��30(���  �� Orientation$ 
Horizontal=�.+��� $
��Name��$��20(��� -    ��Name$ CustName��$	��223��$��30,0,0,0q��� $ 
Horizontal=�.+��� $��Password��$��20(�G� -    G�Name$ Passwrd��$	��223���� .+��� -    ��Name$ Logbtn��$��Login��$��87��$��0,20,0,0q����� *LoginCommand+��`�  `� 	Converter# [  .1��� 	 �� ElementName$	 CustName���� $	 Passwrd���� $
	 Err1���� .+��� -   
 ��Name$

 Err1��
���  ��$��20(��� $��2��.+��� $��Sign Up��$ Center=�$��30(��� $ 
Horizontal=�.+��� $
��Name��$��20(��� -   $ 	CustName1��$	��236��$��40,0,0,0q��� $ 
Horizontal=�.+��� $��Password��$��20(�G� -   $ 	Password1��$	��237��$��9,0,0,0q��� $ 
Horizontal=�.+��� $��Phone no��$��20(��� -   $ Phone��$	��237��$��7,0,10,0q��� .+��� -   $ Signbtn��$��SignUp��$��74��$��0,20,0,0q����� *SignupCommand+��`� # [  .1��� $	 	CustName1���� $	 	Password1���� $	 Phone���� $
	 Err2���� .+��� -	   $

 Err2��
���  ��$��20(�