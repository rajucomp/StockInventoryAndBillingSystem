   M S B A M L   `   `   `  ����Y  UStockInventoryAndBillingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:StockInventoryAndBillingSystem.Templates(StockInventoryAndBillingSystem.Templates  5      <    6StockInventoryAndBillingSystem.Templates.TableDataGrid   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:StockInventoryAndBillingSystem.Templates     5        � 	Resources  5      ��%    5      .��5      &   System.Windows.Controls.DataGrid  -   5        $	��DG1��5         AutoGenerateColumns .     CanUserAddRows .    CanUserDeleteRows . 
�������   GridLinesVisibility$
 None=�5      ��5      �� *DataContext.TableDetails+ �� RelativeSource ��  �� AncestorType$
 PageL�   Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Item Code��6!   	   
FontFamily$	 Calibri)�5   !   
   FontSize$
 20Q�5   !      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5   !   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   !   �� *
ItemCode+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   HeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5      ��  �� Property � �� �� Value
 �����5   !   �� 5       � ��
 �   �5    !   �� 5!       � ��$ 18(�5"   !   5#      5%      4  .System.Windows.Controls.DataGridTemplateColumn  5'      $ Item Description��6%   $ 4* 6?      CellTemplate 5(      �� 5)      .R�5*      ��  �� DisplayMemberPath$ ItemName��5+   #    �� 
IsEditable . ��5*   #   �� *	ItemsList+ �� SelectedItem 5-   #   �� *SelectedMenuItem+$ PropertyChanged=�$ TwoWay=�55      56       58      �� 59      "  6   .�5:      ��  � ��
 �����5;   !   �� 5<       � ��
 �   �5=   !   �� 5>       � ��$ 18(�5?   !   5A      5C        5F      $ Quantity��6!   $	 Calibri)�5G   !   $
 20Q�5H   !   $ 1* 5I   !    5J   !   �� *ItemQuantity+$ TwoWay=�$ PropertyChanged=� 5K      �� 5L      "  6   .�5M      ��  � ��
 �����5N   !   �� 5O       � ��
 �   �5P   !   �� 5Q       � ��$ 18(�5R   !   5S      5U        5V      $ Price��6!   $	 Calibri)�5W   !   $
 20Q�5X   !   $ 1* 5Y   !    5Z   !   �� *	ItemPrice+$ TwoWay=�$ PropertyChanged=� 5[      �� 5\      "  6   .�5]      ��  � ��
 �����5^   !   �� 5_       � ��
 �   �5`   !   �� 5a       � ��$ 18(�5b   !   5c      5e        5f      $ Amount��6!   $	 Calibri)�5g   !   $
 20Q�5h   !   $ 1* 5i   !    5j   !   �� *
ItemAmount+$ OneWay=�$ PropertyChanged=� 5k      �� 5l      "  6   .�5m      ��  � ��
 �����5n   !   �� 5o       � ��
 �   �5p   !   �� 5q       � ��$ 18(�5r   !   5s      5u      5y      5z      