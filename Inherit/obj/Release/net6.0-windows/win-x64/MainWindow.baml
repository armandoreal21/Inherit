   M S B A M L   `   `   `  ���� B  >Inherit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:InheritInherit      Inherit.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Inherit       � Title$   ��$	��500��$	��850��.��� ����  �� ImageSource$! /Resources/imagen_fondo.jpg�� �� Opacity$
 0.05Q� � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0��$��Center=�$��Center=�.+���  �� Orientation$ 
Horizontal=�$��0��$��Center=�$
��0,10q�.+��� -   $��Personas��$��5q�   TabHeaderStyle#��[  �� -   $��Componentes��$��5q�#��[  �� -   $��	Relación��$��5q�#��[  �� -   $��Resumen��$��5q�#��[  �� -   $��Configuracion��$��5q�#��[  �� $��0��$��Center=�$��Right=�$��0 0 10 0q�.+��� $��Total: ��$��12(�$��Center=��� -   $��txtCountTotal��$��0��$��12(�$��Center=��� $��0��$��Center=�$
��Left=�$��10 0 0 0q�.+��� $��
Asignado: ��$��10(�$��Center=��� -   $��txtCountTotalAsignado��$��0��$��12(�$��Center=�� -   $��grdPersonas��$y�	Collapsed=�$��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��	20 0 20 0q�.+�� -	    �Name$ 	Contenido�� �� $
��Auto ��� $
��Auto ��� $��* �.+��� $ 
Horizontal=�$��Right=�$��1��.+��� -
     AppGrayButton#���  $��Crear��$��93��� $��2�� � 	Resources  �� 
TargetType  TableTextBlock �� BasedOn��%   '��       7  �� " ��8    �� $
��Auto ��� $��* �.+��� $��0��  Gray#��[ .+�� $��0,0,0,0q�	 � ColumnDefinitions	 �� $��8* ��� $	��15* ��� $��8* ��� $	��15* ��� $��9* � �� $��28 �.+��� $��0��$��Id��#��[ �� $��0��$��0,0,1,0q�
��������� $��1��$��Nombre Completo��#��[ �� $��1��$��0,0,1,0q�
��������� $��2��$��Id��#��[ �� $��2��$��0,0,1,0q�
��������� $��3��$��Nombre Completo��#��[ �� $��3��$��0,0,1,0q�
��������� $��6��$��Acciones��#��[ �� $��6��$��0,0,1,0q�
��������� -   
 ��Name$
 UsuariosListView��$��1��
������ $��Stretch=�$��Stretch=�$
��Auto=�$��0q����� .R�� 	 �� $��8* ��� $	��15* ��� $��8* ��� $	��15* ��� $��9* � �� $��30��.+��� $��0�� �� TextAlignment$ Center=�$��Center=�$��Center=����� *ID+�� $��1��$ Center=�$��Center=�$��Center=����� *NombreCompleto+�� $��2��$ Center=�$��Center=�$��Center=����� *ID+�� $��3��$ Center=�$��Center=�$��Center=����� *NombreCompleto+�� $��4��$ 
Horizontal=�$��Center=�.+��� -    � Cursor$
 Hand��$!��/Assets/Icons/edit-icon.png��$��2q�$��25���� -   $
 Hand��$#��/Assets/Icons/delete-icon.png��$��2q�$��22��� -   $��grdComponentes��$y�	Collapsed=�$��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��	20 0 20 0q�.+�� -   $ ContenidoComponentes�� �� $
��Auto ��� $
��Auto ��� $��* �.+��� $ 
Horizontal=�$��Right=�$��1��.+��� -   #���  $��Crear��$��93��� $��2�� ��%   '��       7  �� " ��8    �� $
��Auto ��� $��* �.+��� $��0��#��[ .+�� $��0,0,0,0q�	 �� $��8* ��� $	��15* ��� $	��15* ��� $��9* � �� $��28 �.+��� $��0��$��Id��#��[ �� $��0��$��0,0,1,0q�
��������� $��1��$
��Tipo��#��[ �� $��1��$��0,0,1,0q�
��������� $��2��$��Cantidad (€)��#��[ �� $��2��$��0,0,1,0q�
��������� $��6��$��Acciones��#��[ �� $��6��$��0,0,1,0q�
��������� -   $
 ComponentesListView��$��1��
������ $��Stretch=�$��Stretch=�$
��Auto=�$��0q����� .R�� 	 �� $��8* ��� $	��15* ��� $	��15* ��� $��9* � �� $��30��.+��� $��0��$ Center=�$��Center=�$��Center=����� *ID+�� $��1��$ Center=�$��Center=�$��Center=����� *Tipo+�� $��2��$ Center=�$��Center=�$��Center=����� *
Cantidad+�� $��3��$ 
Horizontal=�$��Center=�.+��� -   $
 Hand��$!��/Assets/Icons/edit-icon.png��$��2q�$��25���� -   $
 Hand��$#��/Assets/Icons/delete-icon.png��$��2q�$��22��� -   $"��grdRelacionComponentePersona��$y�	Collapsed=�$��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��	20 0 20 0q�.+�� -   $ ContenidoRelacion�� �� $
��Auto ��� $
��Auto ��� $��* �.+��� $ 
Horizontal=�$
��left=�$��1��.+��� $��14(�$��SemiBold"�.��
Componente�� .+��� -    ��Name$ cbComponente��$	��250��$��28�� �� 
IsEditable$
 True�� �� 
IsReadOnly$
 True�� �� Text$ Seleccionar...���� -    ��Name$ lbCantidadComponente��$��14(�$��SemiBold"�$��10 0 0 0q��� -   $ lbPorcentajeComponente��$��14(�$��SemiBold"�$��10 0 0 0q��� $ 
Horizontal=�$��Right=�$��1��.+��� -   #���  $��
Repartir %��$	��110���� -   #���  $��Modificar Usuarios��$	��110��� $��2�� ��%   '��       7  �� " ��8    �� $
��Auto ��� $��* �.+��� $��0��#��[ .+�� $��0,0,0,0q�	 �� $��8* ��� $	��15* ��� $��8* ��� $��9* � �� $��28 �.+��� $��0��$��Id��#��[ �� $��0��$��0,0,1,0q�
��������� $��1��$��Nombre��#��[ �� $��1��$��0,0,1,0q�
��������� $��2��$��Cantidad (€)��#��[ �� $��2��$��0,0,1,0q�
��������� $��3��$��Porcentaje (%)��#��[ �� $��3��$��0,0,1,0q�
��������� -   $
 RelacionListView��$��1��
������ $��Stretch=�$��Stretch=�$
��Auto=�$��0q����� *RelacionList+���� .R�� 	 �� $��8* ��� $	��15* ��� $��8* ��� $��9* � �� $��30��.+��� $��0��$ Center=�$��Center=�$��Center=����� *ID+�� $��1��$ Center=�$��Center=�$��Center=����� *NombrePersona+�� -   $��2�� �� TextAlignment$ Center=�$��Center=�$��Center=����� *
Cantidad+ �� StringFormat$ F2�� �� Mode$ TwoWay=��� -   $��3��$ Center=�$��Center=�$��Center=����� *
Porcentaje+$ F2��$ TwoWay=��� $��3��$ 
Horizontal=�$	��Top=�$��Center=�$��20q�.+��� -     MyButton#��[ $��2q�$
{�True��.��	Guardar� -   $��
grdResumen��$y�	Collapsed=�$��1��.+��� $
��Auto=�.���� -     ��Name$ ListBoxItems������ .R��� $��5q� �� Padding$ 5q����� " �� �� Triggers ��  �� Binding �� *Entidad.Nombre+ �� Value 
Componente.a���  �� Property � �� �� Value
 �������  �� *Entidad.Nombre+ Persona.a���  � ��
 �����._��� $ 
Horizontal=�.+��� $
��Bold"�$��5q����� *Nombre+�� $	�� - ��$��5q��� $��5q����� *
Cantidad+�� $	�� - ��$��5q��� $��5q����� *
Porcentaje+� -!   $��grdConfiguracion��$y�	Collapsed=�$��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��	20 0 20 0q�.+�� -"   $ ContenidoResumen�� �� $
��Auto ��� $
��Auto ��� $��* ��� $��0��$ 
Horizontal=�$	��Top=�$��Center=�$��20q�.+��� -#   #��[ $��5q�$	��160��$
{�True��.��Eliminar Personas�� -$   #��[ $��5q�$	��160��$
{�True��.��Eliminar Componentes�� -%   #��[ $��5q�$	��160��$
{�True��.��Eliminar Relacion�� $��1��$ 
Horizontal=�$	��Top=�$��Center=�$��20q�.+��� -&   #��[ 
���  ��$��2q�$
{�True��.��EliminarTodo