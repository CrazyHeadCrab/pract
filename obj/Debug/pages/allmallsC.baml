   M S B A M L   `   `   `  ����C  ?rentmall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:rentmall.pagesrentmall.pages  5          rentmall.pages.allmallsC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:rentmall.pages     5        N� Title$  	allmallsC��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��5* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $
��ТЦ��6   $��26(�6   $��Heavy"�6-   $��Center=�6@   $��Center=�6]   $��0��6x   $��2��6�   $��0��6�   �� 5   
   -   5         ��Name$ malllist��5      $��Center=�6$   $��0��6A   $��1��6Q   $��2��6^   $��Disabled=�6r   ��5      �� 5      .R�5      �� -   5        
����� �
�������$��2q�5   J   $��5q�6^   $	��200��6i   $	��200��6u   ._�5      ��  �� Orientation$ Vertical=�6%   .+�5      �� $��Center=�6C   ��6(   ��  �� Path$
 name�6C   �� 5      $	��150��6@   $	��100��6L   ��6$   �� $	 pic�6L   �� 5      ��6(   �� $ state��� 5       ��6(   �� $
 town��� 5!      ��6(   �� $ price��� 5"      ��6(   �� $ 	count_lvl��� 5#      ��6(   �� $
 coef�5$      5%      5&      ��5(      �� 5)      .R�5*      �  � Orientation$ 
Horizontal=�6    $��Center=�69   5+      5.      �� 5/   
   -   5         ��Name$ stat_but��5/      $��Статус��6#   $��0��64   $��2��6D   $	��100��6Q   $��30��6]   6i   �� 50   
   -   5        $ town_but��50      $��
город��6#   $��1��63   $��2��6C   $	��100��6P   $��30��6\   6h   � 51   
   -   5         �Name$ stats��51      $��
MousePoint=�6    	 � 	StaysOpen	 . .��52      �� -   5        $ 
stats_list��52      ��53      �� 54      .R�55      �� $	��100��6?   ��6$   �� $
 name�6?   56      58      59      � 5:   
   -   5        $ townspop��5:      $��
MousePoint=�6#   	 . .��5;      �� -   5        $ 
towns_list��5;      ��5<      �� 5=      .R�5>      �� $	��100��6?   ��6$   �� $
 name�6?   5?      5A      5B      � 5C   
   -	   5        $ popdel��5C      $��
MousePoint=�6!   	 . .��5D      �� -
   5        $ del_but��5D      $��удалить��6&   69   5E      �� 5F   
   -   5        $ new_mallbut��5F      $��0��6'   $��2��67   $��2��6D   $��Новый ТЦ��6X   $	��100��6k   $��30��6w   6�   5G      5H      