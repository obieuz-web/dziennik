   M S B A M L   `   `   `  ����C  ?dziennik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:dziennik.Windowsdziennik.Windows  5   	   %    dziennik.Windows.DirectorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:dziennik.Windows     5   	   
����İ�  � Title$  Siema Dyro!��5	   	   $	��450��6   $	��800��6*   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��Auto �6   �� 5      $��8* �6   .+�5   
   R� -   5        $��_treeView_uczniowie��5      
����İ�6.   �� 5   
   $��1��6   �� 5   
   $��2��6   $��50q�6!    �� Padding$ 10q�6-   
�������._�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$    5!      �� 5"      $
��auto �6'   �� 5#      .+�5&      �� $��Imię i Nazwisko��6   $��0,0,10,0q�63   �� 5'      -   5        $��_textblock_imie_nazwisko��5'      $��1��6<   �� 5)      $��PESEL��6   $��1��6)   $��0,0,10,0q�66   �� 5*      -   5        $��_textblock_pesel��5*      $��1��64   $��1��6E   �� 5,      $��Ilość punktów��6   $��2��61   $��0,0,10,0q�6>   �� 5-      -   5        $��_textblock_punkty��5-      $��1��65   $��2��6F   �� 5/      $��Oceny��6   $��3��6)   $��0��66   R� 50      -   5        $��_treeView_oceny��50      $��3��62   $��1��6?   
�������6O   �� 52      -   5        $��Dodaj Punkty��52      $��4��60   $��0,5,0,0q�6=   $��1��6N   $	��100��6^   $��30��6j   $
��Left=�6v   6�   �� 54      -   5        $��Dodaj Ocene��54      $��4��6/   $��0,5,0,0q�6<   $��1��6M   $	��100��6]   $��30��6i   $��Center=�6u   6�   �� 56      -   5        $��Dodaj Ucznia��56      $��4��60   $��0,5,0,0q�6=   $��1��6N   $	��100��6^   $��30��6j   $��Right=�6v   6�   58      59      5:      5;      