   M S B A M L   `   `   `  ����   Inherit    Inherit.RelacionFormView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     9i+http://schemas.microsoft.com/xaml/behaviors     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  window�� � Title$ Add User��$	��550��$	��500�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=����#454544$��1q� � WindowState �� *CurWindowState+ �� Mode$ TwoWay=�'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�	   ResizeBorderThickness$	 5q�.��� ���� 
 �� ImageSource$#
 /Assets/Icons/background2.jpg�� �� Opacity$	 0.4Q� � RowDefinitions �� $��26 ��� $��* � � ColumnDefinitions �� $��* �.+�]� -   $��
barraTitle��$��0�����#454544$��False��$	��Top=�$	��Top=�$��26��.+��� -   $��Center=�$��/Assets/Icons/close.png��$��30��$��15��$��Right=� � Cursor$
 Hand��� $��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��	20 0 20 0q�.+�� -    �Name$ 	Contenido�� �� $
��Auto ��� $
��Auto ��� $��* �.+�� $��2��$��0 10 0 0q� � 	Resources  �� 
TargetType   TableTextBlock �� BasedOn��%   '��       7   �� " ��8    �� $
��Auto ��� $��* �.+��� $��0��  Gray#��[ .+�� $��0,0,0,0q� �� $��8* ��� $��8* ��� $	��15* � �� $��28 �.+��� $��0��$�� ��#��[ �� $��0��$��0,0,1,0q�
��������� $��1��$��Id��#��[ �� $��1��$��0,0,1,0q�
��������� $��2��$��Nombre Completo��#��[ �� $��2��$��0,0,1,0q�
��������� -    ��Name$ UsuariosListView��$��1��
������ $��Stretch=�$��Stretch=�$
��Auto=�$��0q����� .R��  �� $��8* ��� $��8* ��� $	��15* � �� $��30��.+��� $��0�� d� 	IsChecked �� *
IsSelected+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��1�� �� TextAlignment$ Center=�$��Center=�$��Center=����� *ID+�� $��2��$ Center=�$��Center=�$��Center=����� *NombreCompleto+�� $��3�� �� Orientation$ 
Horizontal=�$	��Top=�$��Center=�$��20q�.+��� -     MyButton#��[ $��2q�$
{�True��.��	Guardar