   M S B A M L   `   `   `  ����D  @Dentistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Dentistry.Views.PatientPagesDentistry.Views.PatientPages  5      /    )Dentistry.Views.PatientPages.ServicesForP   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Dentistry.Views.PatientPages     5      $
��auto��5   0   $
��auto��6=     N� Title$  ServicesForP��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ServicesList��5      $   HorizontalScrollBarVisibility$ Visible=�6)      AutoGenerateColumns .  $��0,2,0,0q�6m   $��1��6~      PrimaryHueLightBrush#���   6�   
���   �   	RowHeight$ 60Q�6�   $��Tahoma)�6�   $��16(�6�    J� Opacity$	 0.9Q�6%  ��6  �� *
Services+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$# Название услуги��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6>   	   FontSize$	 14Q�6J   
   
FontFamily$
 Tahoma)�6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6l   ��  �� Path$
 Name�  5      $	 14Q�6%   $
 Tahoma)�63   $ Цена��6G    6U   �� $
 Cost�4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 
Врачи��6)      CellTemplate 5      �� 5      .R�5      �� ��6'   �� *	Doctors+��5   "   �� 5   &   .R�5   *   �� $��Tahoma)�6N   $��16(�6b   ��64   �� *
LastName+6b   5   '   5      5      5      5       5!      5"      