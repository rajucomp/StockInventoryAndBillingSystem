   M S B A M L   `   `   `  ����Y  UStockInventoryAndBillingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:StockInventoryAndBillingSystem.Templates(StockInventoryAndBillingSystem.Templates  5      <    6StockInventoryAndBillingSystem.Templates.TableCommands   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:StockInventoryAndBillingSystem.Templates     5        � 	Resources  5       �� 
TargetType   BlueButtonStyle �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding �� Color	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  &	        �� 5	   
   " ��6   .�5      ��  � ��$ Calibri)�5      �� 5       � ��$ 18(�5      �� 5       � ��
 �����5      �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ ButtonBorder��5   %   $��2q�5   %   $ 4��5   %   $ 3q�5   %   
����  ���5   "   �� 5   &   ButtonBorderBrush��$ Black��5   6   ._�5   "   �� $��Center=�63   $	��4,2q�5   3   5       5!      	 5"      P� 5#      
 �@J�IsMouseOver . . �5%   "   �� $ ButtonBorder��6)    � �� �#C0C0C05'   )   5(      5*      5,      5-      5.      .��5/      �  � ColumnDefinitions 50   
   �� 51      $��1* �6   �� 52      $��1* �6   �� 53      $��1* �6   �� 54      $��1* �6   .+�57   
   �� $��0��6   $��Add new item��58      $��Center=�59      $��0 5 0 0q�5:      #��[  5;      ��5<      �� *DataContext.AddNewRowCommand+ �� RelativeSource ��  �� AncestorType$
 PageL��� 5>   
   $��1��6   $��Delete item��5?      $��Center=�5@      $��0 5 0 0q�5A      #��[  5B      ��5C      �� *DataContext.DeleteRowCommand+ �� $
 PageL��� 5F   
   $��2��6   $��	Save Bill��5G      $��Center=�5H      $��0 5 0 0q�5I      #��[  5J      ��5K      �� *DataContext.DeleteRowCommand+ �� $
 PageL��� 5N   
   $��3��6   $��Start New Bill��5O      $��Center=�5P      $��0 5 0 0q�5Q      #��[  5R      ��5S      �� *#!DataContext.ResetViewModelCommand+ �� $
 PageL�5U      5V      