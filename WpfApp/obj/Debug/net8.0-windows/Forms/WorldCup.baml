   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp.FormsWpfApp.Forms  5   	   5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	       WpfApp.Forms.WorldCup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp.Forms     5   	   6
propertiesclr-namespace:WpfApp.Properties     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5        !   WpfApp.Properties.Resources    worldCupTitle � Title# Z  5
   	   $	��600��5   	   $	��800��6    � 	Resources 5       �� 
TargetType �� Property �� Value   ComboBoxStyle��%�  '�       '�� �     &	  �     �� 5   
   " �6   .�5      ��  �@�Orientation$ Vertical=�6,   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 0 15 0 0q�6'   �� 5       � ��$	 110��6&   5      �� 5   
   " K�6&   .�5      ��  � ��$ 	20 0 20 0q�6'   �� 5       � ��$ Center=�62   5      5       � Triggers 5      :� 5    
    :� RoutedEvent$ Window.Loaded��6   .[�5!      �� .��5"      �� .��5$      W�  �� 
TargetName$ PnlHomeTeamGoalie��6&   	 �� TargetProperty$	 Opacity�6P   
 W� From
 06t   	 W� To 16}    g� Duration$ 0:0:0.5D�6�   W� 5%      $ PnlHomeTeamDefender��6&   $	 Opacity�6R   
 06v    16   $ 0:0:0.7D�6�   W� 5&      $ PnlHomeTeamMidfield��6&   $	 Opacity�6R   
 06v    16   $ 0:0:0.9D�6�   W� 5'      $ PnlHomeTeamForward��6&   $	 Opacity�6Q   
 06u    16~   $ 0:0:1.1D�6�   W� 5*      $ PnlAwayTeamForward��6&   $	 Opacity�6Q   
 06u    16~   $ 0:0:1.1D�6�   W� 5+      $ PnlAwayTeamMidfield��6&   $	 Opacity�6R   
 06v    16   $ 0:0:0.9D�6�   W� 5,      $ PnlAwayTeamDefender��6&   $	 Opacity�6R   
 06v    16   $ 0:0:0.7D�6�   W� 5-      $ PnlAwayTeamGoalie��6&   $	 Opacity�6P   
 06t    16}   $ 0:0:0.5D�6�   5.      5/      50      .��53      �  � ColumnDefinitions 54   
   �� 55      $��1* �6   �� 56      $��1* �6   �� 57      $��1* �6   �� 58      $��1* �6   �� 59      $��1* �6   �� 5:      $��1* �6   �� 5;      $��1* �6   �� 5<      $��1* �6    � RowDefinitions 5>   
   �� 5?      $
��0.2* �6   �� 5@      $��1* �6   �� 5A      $��5* �6   .+�5D   
   ]� $��0��6   $��0��6!   .+�5E      o� $	��Top=�6   $
��Left=�6(   $��60��6C   .@�5F      m� -   5           settingsFormTitle#��Z 5F      6V   5G      5H      �� 5K   
   $��1��6   $��0��6"   $��4��62   #��[  6F   .+�5L      �� -   5         ��Name$ 
CbHomeTeam��5L      $��30��6+   67   �� 5M      -   5         ��Name$ BtnHomeTeamInformation��5M         btnTeamInfo#��Z 65   6k   5N      �� 5Q   
   $��1��6   $��4��6"   $��4��62   #��[  6F   .+�5R      �� -   5        $ 
CbAwayTeam��5R      $��30��6+   67   �� 5S      -   5        $ BtnAwayTeamInformation��5S      #��Z 65   6k   5T      � 5V   
   $��1��6   $��0��6   $��8��6,    J� IsHitTestVisible$ False��6@   .+�5W      �� -   5         ��Name$ TxtMatchResult��5W      $��20(�5X      $
��Bold"�6   $��Center=�5Y      $��Center=�6-    �� TextAlignment$ Center=�5Z      $��0,55,0,0q�5[      5\      �� 5_   
   $��2��6   $��0��6"   $��8��62    K� ZIndex$ 1��6F   .+�5`      "  FontAwesome.WPF.ImageAwesome  -   5          Name$ LoadingSpinner��5`         Icon$ CircleOutlineNotch=�66   $��0 10 0 0q�6P   $y�Hidden=�6b      Spin$ False��6v      SpinDuration$ 2Q�6�   $��48��6�   5a      �� 5d   
   $��2��6   $��0��6"   $��8��62   ��5e      �� 5f       �� ImageSource$6 0/WpfApp;component/ImageSource/football_pitch.jpg��6   5h      � 5j   
   -	   5         �Name$ PnlHomeTeamGoalie��5j       � Orientation$ 
Horizontal=�6/   $��0��6H   $��2��6X   � 5k   
   -
   5        $ PnlHomeTeamDefender��5k      $ 
Horizontal=�61   $��1��6J   $��2��6Z   � 5l   
   -   5        $ PnlHomeTeamMidfield��5l      $ 
Horizontal=�61   $��2��6J   $��2��6Z   � 5m   
   -   5        $ PnlHomeTeamForward��5m      $ 
Horizontal=�60   $��3��6I   $��2��6Y   � 5p   
   -   5        $ PnlAwayTeamForward��5p      $ 
Horizontal=�60   $��4��6I   $��2��6Y   � 5q   
   -   5        $ PnlAwayTeamMidfield��5q      $ 
Horizontal=�61   $��5��6J   $��2��6Z   � 5r   
   -   5        $ PnlAwayTeamDefender��5r      $ 
Horizontal=�61   $��6��6J   $��2��6Z   � 5s   
   -   5        $ PnlAwayTeamGoalie��5s      $ 
Horizontal=�6/   $��7��6H   $��2��6X   5t      5u      