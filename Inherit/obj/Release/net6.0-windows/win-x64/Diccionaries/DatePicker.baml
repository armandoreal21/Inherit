   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089(   "System.Windows.Controls.DatePicker  �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset �� 
TargetType �� Padding'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard g� Duration	 W� To �� TargetProperty �� 
TargetName �Name � 	Resources   Key �� Color   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To � Cursor � ColumnDefinitions ��Name  DropDownButtonTemplate:  4System.Windows.Controls.Primitives.DatePickerTextBox  Name J� IsHitTestVisible J� Opacity �� RadiusY �� RadiusX �Name � AllowsTransparency  � 	StaysOpen! � PlacementTarget" �� ElementName# �� Triggers$ �� Value% �� Binding& �� Source' �� 
TargetName( �� RelativeSource) ��Name* ��Name+ ��Name�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      %�
  '         7  '  �    �� "    .���  � �� �	#FF333333��  �@  IsTodayHighlighted$
 True����  �@  SelectedDateFormat$ Short=���  � ��
 ���� ��  � ��$ 32����  � �� �� $
 .5,0&�$
 .5,1&�.��� $ 	#FFA3AEB9��$ 0Q�� $ 	#FF8399A9��$ 0.375Q�� $ 	#FF718597��$ 0.375Q�� $ 	#FF617584��$ 1Q���  � ��$ 0q���  � ��$ Stretch=���  � �� �� "   .R��� #��z��#��z��#��z��# z��	   CommonStates��.
   
Normal��  Disabled��. �� .��W� $ 0D� 1$ Opacity�$ PART_DisabledVisual��._�� $ 	PART_Root��#��z��#��z�� ���� DisabledBrush  $ 	#A5FFFFFF���� DropDownButtonTemplate  " ��.R�� 	   CommonStates��   $ 0D�  $ 0:0:0.1D�$ 	MouseOver��  $ 0:0:0.1D�$ Pressed��.
   
Normal��  Pressed��  Disabled��.+�� ���	#11FFFFFF$��LeftToRight=�$��Center=�$��25��$��0q�$��Center=�$��25��.+��� $#��/Resources/Icons/calendar.png��$
 Hand�� �� $��* ��� $
��Auto �.+��� $ PART_Button��$��1��#��z��$|�False��$
��Left=�$��3,0,3,0q�$��0��8��  $	��Top=�$��20��  $ PART_TextBox��$��0��#|�z|�$��Stretch=�$��0��$��Stretch=�� $ PART_DisabledVisual��$��2��$��0��$ False��$ 0Q�$��0�� �� $��* ��� $
��Auto �.+��� $��0�����	#A5FFFFFF$ 1��$��0��$ 1���� $��1�����	#A5FFFFFF$��18��$��3,0,3,0q�$ 1��$��0��$ 1��$��19��� $ 
PART_Popup��$
 True��$��Bottom=�$  False��! �� $" PART_TextBox��# �� $$ false��% �� #& Zr�.a��� $' PART_TextBox�� �� *
Foreground+( �� *TemplatedParent+ � ���� "   .���  � ��$ 25����  � ��$ Stretch=���  � ��$ Center=���  � ��$ Center=���  � ��$ Center=���  � ��
 �������  � ��$ 1q���  � ��$ 14(���  � ��$	 1.5q���  � �� �� "  .R��  ���� WatermarkBrush  $ 	#FFAAAAAA��	   CommonStates��   $ 0D�  $ 0:0:0.1D�$ 	MouseOver��.
   
Normal��  	MouseOver��  WatermarkStates��   $ 0D�.
   Unwatermarked��  Watermarked��. �� .��W� $ 0D� 0$ Opacity�$ ContentElement��W� $ 0D� 1$ Opacity�$ PART_Watermark��  FocusStates��   $ 0D�.
   	Unfocused��  Focused��.+��� $) Border��#��z��#��z��#��z��$ 1Q�# z��._�� $ WatermarkContent��#��z��#��z��.+��� $) ContentElement�����	#FFFFFFFF$��1q��� $) watermark_decorator�����	#FFFFFFFF$��1q�._��� $* PART_Watermark��$|�False��$ False��$ 0Q�$��2q��� $+ PART_ContentHost��#��z��$��0q�#��z��