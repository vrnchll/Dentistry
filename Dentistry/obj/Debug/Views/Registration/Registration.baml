   M S B A M L   `   `   `  ����D  @Dentistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Dentistry.Views.RegistrationDentistry.Views.Registration  5   	   /    )Dentistry.Views.Registration.Registration   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Dentistry.Views.Registration     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6B     � Title$  Registration��5   	   $	��500��6   $	��612��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\    � Icon$; 5pack://application:,,,/Resourses/icons8-зуб-50.png��6r   .��5	      �  J� Opacity$	 0.8Q�6      PrimaryHueLightBrush#���   6   .+�5   
   � y�6   �� *	Visible+ � ColumnDefinitions 5      �� 5      $
��133* �6#   �� 5      $
��653* �6#    � RowDefinitions 5      �� 5      $	��44* �6    6/   �� 5      $	��76* �6    �� 5      $
��351* �6    60   .+�5      �� $��Center=�6   $��0��62   $M��GПожалуйста, выберите тип пользователя!��6?   
���   �$��16(�6�   $
��Bold"�6�   $��3��6�   $��31,10,134,0q�6�   $��1��6�   $	��338��6�   �� 5      -   5         ��Name$ TypeUser��5       �� SelectedIndex$ 0��6*   
���   �$��16(�6O   -  'MaterialDesignThemes.Wpf.ComboBoxAssist	   ClassicMode$
	 true��6]   $��1��6�   $��31,0,133,37q�6�   $��Stretch=�6�   $��1��6�   
 �� SelectedValue
 6�   �� *SelectedItem+.@�5      �� -   5         ��Name$ comboboxPatient��5   1    �� 
IsSelected . $��Пациент��6K   �� 5      $��Доктор��6   5      �� 5       " MaterialDesignFlatDarkBgButton#���  6   $��1��6{   $��1��6�   $��304,44,94,335q�6�   $
��Auto��6�    J� RenderTransformOrigin$ 0.533,0.049&�6�   $��2��6�   ��6N   Z� ��6e   Z� ��6�   �� *
ShowPage+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PageNext=�6*   
���   �$��40(�6M   $��Center=�6[   $ -1,0.812&�6v   5      5      �� 5      $��0,6,33,6q�6B   $	��Top=�6T   $
��Left=�6l   ��6   Z� ��6+   Z� ��6�   �� *
ReturnBack+.��5        $ 	ArrowBack=�6*   ���	#FF333333$��20(�6R   $��22��6`   $��36��6l   5       5!       � 5"   
   -   5          �Name$ frame��5"        � NavigationUIVisibility$ Hidden=�5$      ��5#      �� *CurrentPage+5$      5%      5&      