   M S B A M L   `   `   `  ����  Inherit    Inherit.UsuarioFormView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   9i+http://schemas.microsoft.com/xaml/behaviors     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  window��5   	    � Title$ Add User��5	   	   $	��550��6   $	��500��6'    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   ���#454544$��1q�6W    � WindowState 5   	   �� *CurWindowState+ �� Mode$ TwoWay=�'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�5   	   	   ResizeBorderThickness$	 5q�5   	   .��5      � ��5   
   �� 5      
 �� ImageSource$#
 /Assets/Icons/background2.jpg��6    �� Opacity$	 0.4Q�6E    � RowDefinitions 5   
   �� 5      $��26 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5    
   ]� -   5        $��
barraTitle��5       $��0��6&   ���#454544$��False��6H   $	��Top=�6^   $	��Top=�6v   $��26��6�   .+�5!      �� -   5        $��Center=�5!      $��/Assets/Icons/close.png��6/   $��30��6P   $��15��6[   $��Right=�6g    � Cursor$
 Hand��6~   6�   5"      � 5$   
   $��1��6   .+�5%      � $��Center=�6    5&      �� 5'      $��* �6'    5)      �� 5*      $
��Auto �6$   �� 5+      $
��Auto �6$   �� 5,      $
��Auto �6$   .+�5.      �� $��18(�6   $��0��6&   $
��Bold"�63   $��Center=�6E   ���#454544$��5q�6w   .��6�   	PERSONA6�   �� 50      $��1��6   $	��Top=�6*   $��Center=�6B   $��0,10,0,0q�6_   .+�52      ��  �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $y�	Collapsed=�6V   .+�53      �� $��14(�6    $��SemiBold"�6.   .��6D   ID6H   �� 55      .+�56      �� -   5         ��Name$
 tbID��56   &   $	��200��64    �� 
IsReadOnly$
 True��6@   ���#F0F0F06i   57      58      �� 5:      $ 
Horizontal=�6!   $��Right=�6:   .+�5;      �� $��14(�6    $��SemiBold"�6.   .��6D   Nombre Completo6U   �� 5=      .+�5>      �� -   5        $ tbNombre��5>   &   $	��200��68   6F   5?      5A      5R      �� 5U      $��2��6   $ 
Horizontal=�6+   $	��Top=�6D   $��Center=�6\   $��20q�6y   .+�5W      �� -   5           MyButton#��[  5W      $��2q�6?   $
{�True��6J   .��6v   	Guardar6   5X      5Y      5\      5_      5`      