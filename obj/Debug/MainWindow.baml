   M S B A M L   `   `   `  ����C  ?rentmall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:rentmallrentmall  5   	       rentmall.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:rentmall     5   	     � Title$  
MainWindow��5   	   $	��550��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��2* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��3* �6   �� 5      .+�5   
   �� $��1��6   $��1��6!   
���   �$��4q�6B   
����� �._�5      ��  �� Orientation$ Vertical=�6   $��5q�60   $��Center=�6;   $	��200��6X   .+�5      �� $��Вход��6   $��Center=�6(   $��5q�6E   $��20(�6P   �� 5      $��login��6   $
��left=�6)   $��5q�6E   �� 5      -   5         ��Name$ loginbox��5      $��5q�6,   $��Adam@gmai.com��67   �� 5      $��password��6   $
��left=�6,   $��5q�6H   G� 5      -   5         G�Name$ pasbox��5      $��5q�6.    G� Password$ 7SP9CV��69    G� PasswordChar$ *��6K   �� 5      -   5         ��Name$ inbut��5      $��
Войти��6(   $��5q�68   6C   �� 5      -   5        	 ��Name$	 errblock��5      �� 5      -   5        
 ��Name$
 	capchstac��5      $ Vertical=�60   $y�Hidden=�6G   .+�5      �� -   5        $	 x��5       $��23��6+   
���z���$��21(�6M   $��Italic$�6\   $��Heavy"�6o   
���   �$��UltraCondensed&�6�   $	��100��6�   $��30��6�   �� 5      $��Введите капчу��6    $
��left=�65   �� 5       -   5        $ capchbox��5       $��10q�60   5!      5"      5#      5$      5%      