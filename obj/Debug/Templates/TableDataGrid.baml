   M S B A M L   `   `   `  ����Y  UStockInventoryAndBillingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:StockInventoryAndBillingSystem.Templates(StockInventoryAndBillingSystem.Templates  5      <    6StockInventoryAndBillingSystem.Templates.TableDataGrid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:StockInventoryAndBillingSystem.Templates     5        � 	Resources  5         ComboBoxList �� Source �� RelativeSource �� AncestorType��%a   &	        �� 5	   
    5
      �� *DataContext.ItemsList+ �� $
 PageL�5      5      .��5      &   System.Windows.Controls.DataGrid  -   5        $	��DG1��5         AutoGenerateColumns .     CanUserAddRows .    CanUserDeleteRows . 
�������   GridLinesVisibility$
 None=�5      ��5      �� *DataContext.TableDetails+ �� $
 PageL�   Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Item Code��6!   
   
FontFamily$
 Calibri)�5   !      FontSize$ 20Q�5   !      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5   !   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   !   �� *
ItemCode+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ Explicit=�   HeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5      ��  �� Property � �� �� Value
 �����5   !   �� 5       � ��
 �   �5    !   �� 5!       � ��$ 18(�5"   !   5#      5%      4  .System.Windows.Controls.DataGridComboBoxColumn  5'      $	 Item Description��6%   $ 4* 5(   %      DisplayMemberPath$ ItemName��5+   %      ItemsSource 5)   %   ��  �� Source# [     SelectedItemBinding 5*   %   �� *SelectedMenuItem+ 5,      �� 5-      "  6   .�5.      ��  � ��
 �����5/   !   �� 50       � ��
 �   �51   !   �� 52       � ��$ 18(�53   !   54      56        5G      $	 Quantity��6!   $
 Calibri)�5H   !   $ 20Q�5I   !   $ 1* 5J   !    5K   !   �� *ItemQuantity+$ TwoWay=�$ Explicit=� 5L      �� 5M      "  6   .�5N      ��  � ��
 �����5O   !   �� 5P       � ��
 �   �5Q   !   �� 5R       � ��$ 18(�5S   !   5T      5V        5W      $	 Price��6!   $
 Calibri)�5X   !   $ 20Q�5Y   !   $ 1* 5Z   !    5[   !   �� *	ItemPrice+$ TwoWay=�$ Explicit=� 5\      �� 5]      "  6   .�5^      ��  � ��
 �����5_   !   �� 5`       � ��
 �   �5a   !   �� 5b       � ��$ 18(�5c   !   5d      5f        5g      $	 Amount��6!   $
 Calibri)�5h   !   $ 20Q�5i   !   $ 1* 5j   !    5k   !   �� *
ItemAmount+$ OneWay=�$ Explicit=� 5l      �� 5m      "  6   .�5n      ��  � ��
 �����5o   !   �� 5p       � ��
 �   �5q   !   �� 5r       � ��$ 18(�5s   !   5t      5v      5z      5{      