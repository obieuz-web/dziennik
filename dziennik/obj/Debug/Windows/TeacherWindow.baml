   M S B A M L   `   `   `  ����C  ?dziennik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:dziennik.Windowsdziennik.Windows  5   	   $    dziennik.Windows.TeacherWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:dziennik.Windows     5   	   
����İ�  � Title$   Witamy Szanownego magistra��5	   	   $	��450��6,   $	��800��69   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5 �6   �� 5      $��8* �6   .+�5   
   �� -   5        $��_listBox_uczniowie��5      
����İ�6,   �� 5   
   $��1��6   �� 5   
   $��50q�6   $��2��6    �� Padding$ 10q�6-   
�������._�5      � $��2��6    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$    5      �� 5       $
��auto �6'   �� 5!      .+�5$      �� $��Imię i Nazwisko��6   $��0,0,10,0q�63   �� 5%      -   5        $��_textblock_imie_nazwisko��5%      $��1��6<   �� 5'      $��PESEL��6   $��1��6)   $��0,0,10,0q�66   �� 5(      -   5        $��_textblock_pesel��5(      $��1��64   $��1��6E   �� 5*      $��Ilość punktów��6   $��2��61   $��0,0,10,0q�6>   �� 5+      -   5        $��_textblock_punkty��5+      $��1��65   $��2��6F   �� 5-      $��Oceny��6   $��3��6)   $��0��66   R� 5.      -   5        $��_treeView_oceny��5.      $��3��62   $��1��6?   
�������6O   �� 50      -   5        $��Dodaj Punkty��50      $��4��60   $��1��6=   $	��100��6M   $��30��6Y   $
��Left=�6e   $��0,5,0,0q�6�   �� 52      -   5        $��Dodaj Ocene��52      $��4��6/   $��1��6<   $	��100��6L   $��30��6X   $��Right=�6d   $��0,5,0,0q�6�   55      56      57      58      