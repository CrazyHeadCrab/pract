   M S B A M L   `   `   `  ����C  ?rentmall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:rentmall.pages.admrentmall.pages.adm  5           rentmall.pages.adm.allempA   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:rentmall.pages.adm     5        N� Title$  allempA��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��5* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Сотрудники��6   $��26(�6'   $��Heavy"�65   $��Center=�6H   $��Center=�6e   $��0��6�   $��2��6�   $��0��6�   �� 5   
   -   5         ��Name$ emplist��5      $��Center=�6#   $��0��6@   $��1��6P   $��2��6]   $��Disabled=�6q   ��5      �� 5      .R�5      �� -   5        
����� �
�������$��2q�5   J   $��5q�6^   $	��200��6i   $	��250��6u   ._�5      ��  �� Orientation$ Vertical=�6%   .+�5      �� $	��150��6@   $	��100��6L   ��6$   ��  �� Path$	 pic�6L   �� 5      ��6(   �� $
 name��� 5       ��6(   �� $	 fam��� 5!      ��6(   �� $	 pat��� 5"      ��6(   �� $	 log��� 5#      ��6(   �� $ phonr��� 5$      ��6(   �� $ gender��� 5%      ��6(   �� $
 role�5&      5'      5(      ��5*      �� 5+      .R�5,      �  � Orientation$ 
Horizontal=�6    $��Center=�69   5-      50      �� 51   
   $ Vertical=�6   $��Center=�6,   $��0��6J   $��2��6Z   .+�52      �� $��Фамилия��6   $��Center=�6'   �� 53      -   5         ��Name$ fam_box��53      $	��100��6'   $��30��63   6?   54      � 55   
   -   5         �Name$ popdel��55      $��
MousePoint=�6!   	 � 	StaysOpen	 . .��56      �� -   5        
 ��Name$
 del_but��56      $��удалить��6&   69   57      �� 58   
   -   5        $
 
new_empbut��58      $��0��6&   $��2��66   $��2��6C   $#��Новый сотрудник��6W   $	��100��6q   $��30��6}   6�   59      5:      