   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      Y UStockInventoryAndBillingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:StockInventoryAndBillingSystem.Templates(StockInventoryAndBillingSystem.Templates 5      e7clr-namespace:StockInventoryAndBillingSystem.ViewModels)StockInventoryAndBillingSystem.ViewModels 5      ?   9StockInventoryAndBillingSystem.Templates.TableUserDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      Hlocal6clr-namespace:StockInventoryAndBillingSystem.Templates     5      Fvm7clr-namespace:StockInventoryAndBillingSystem.ViewModels     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��Customer Name : ��6   $��Calibri)�5      $��22(�5      $��	150 0 0 0q�5      $��0��5       $��0��5!      �� 5"   
   $��0��5#      $��1��5$      $��Calibri)�5%      $��22(�5&      $��0 10 0 0q�5'      ��5"      �� *DataContext.CustomerName+ �� RelativeSource ��  �� AncestorType$
 PageL� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5'   $    � 	Resources 5(       �� 
TargetType �� Property	 �� Value��%c   '��       �� 5)      " ��6   .�5*      ��  �@��CornerRadius$	 10��5+      5,      5-      .��6!   ��5.      1&clr-namespace:System;assembly=mscorlibSystem  50      �� 5/      6sys&clr-namespace:System;assembly=mscorlib     50      " ��5/      
 �� 	Resources
 51         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%  &	        !� 52      $
 Left=�53   &   $	 Top=�54   &   $
 None=�55   &    56      �� 57   "   
�������}�. $��Stretch=�59   (   ��5:   &   �� 5;   *   " ��60   .�5<   .   ��  � ��$	 Name of the customer��5=   5   5>   +   5@   #   5B      5C       �� Triggers 5D      P� 5E       P� Property � �� �� Empty P� Value# Z 5F   "   . �5G      ��  � ��#	 [  5H   %   5I      P� 5J       � �� 5K   "   Z� . �5L      ��  � ��#	 [  5M   %   5N      P� 5O       �@J�IsKeyboardFocused . . �5Q      ��  � ��
	 �����5R   %   5S      5U      .��5W      5X      �� 5[   
   $��Order Date : ��6   $��Calibri)�5\      $��22(�5]      $��	150 0 0 0q�5^      $��0��5_      $��2��5`      (  "System.Windows.Controls.DatePicker  5b   
      SelectedDateFormat$
 Long=�6      DisplayDateStart$ 1/01/09X�5d         DisplayDateEnd$ 12/31/99X�5e         FirstDayOfWeek$ Sunday=�5f      $��0��5g      $��3��5h      $��	0 10 10 0q�5i         SelectedDate 5c      �� *DataContext.BillDate+ �� $
 PageL�5k      �� 5�      $��	Waiter : ��6   $��	235 0 0 0q�5�      $��Calibri)�5�      $��22(�5�      $��1��5�      $��0��5�      �� 5�   
   $��1��6   $��1��5�       �� DisplayMemberPath$ FullName��5�       �� SelectedIndex$ 0��5�      $��	0 10 0 10q�5�      ��5�      �� *DataContext.WaiterList+ �� $
 PageL� �� SelectedItem 5�      �� *DataContext.SelectedWaiter+ �� $
 PageL�$ TwoWay=�$ PropertyChanged=�5�      �� 5�   
   $��
Cashier : ��6   $��	180 0 0 0q�5�      $��Calibri)�5�      $��22(�5�      $��1��5�      $��2��5�      �� 5�   
   $��1��6   $��3��5�      $ FullName��5�      $ 0��5�      $��
0 10 10 10q�5�      ��5�      �� *DataContext.CashierList+ �� $
 PageL� 5�      �� *DataContext.SelectedCashier+ �� $
 PageL�$ TwoWay=�$ PropertyChanged=�5�      5�      5�      