   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp.FormsWpfApp.Forms  5   	   5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	   $    WpfApp.Forms.PlayerInformation   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp.Forms     5   	   6
propertiesclr-namespace:WpfApp.Properties     5   	   !   WpfApp.Properties.Resources    playerInfoTitle � Title# Z  5	   	   $	��450��5
   
   $	��800��6    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 20,10,20,10q�6'   �� 5       � ��$ Center=�62   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Wrap=�6-   5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� 
TargetName$ SlideTransform��5      	 �� TargetProperty$	 X�5      
 W� From
 3005      	 W� To 06     g� Duration$ 0:0:0.5D�6'    W� EasingFunction 5      .  (System.Windows.Media.Animation.CubicEase  5      7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ EaseOut=�6(   5      W� 5"      $	 Opacity�5#      
 05$       16   $ 0:0:0.5D�6%   5%      5&      5'      .��5)      �  J� RenderTransformOrigin$ 0.5,0.5&�6   $��30q�6+   z�5*   
   T� 5+      -   5        SlideTransform�� T� X$	 300Q�5+   9    � ColumnDefinitions 5-   
   �� 5.      $��1* �6   �� 5/      $��1* �6    � RowDefinitions 51   
   �� 52      $��5* �6   �� 53      $
��1.5* �6   �� 54      $
��1.5* �6   �� 55      $
��1.5* �6   .+�58   
   �� $��0��59   	   $��0��5:   	   $��2��5;   	   $��Center=�5<   	   $��Center=�5=   	   $
��0,10q�5>   	   $	��250��5?   	   $	��250��5@   	   $��Uniform=�5A   	   ��5B   	   �� *PlayerImagePath+�� 5D   
   $��1��5E   	   $��0��5F   	    �� Padding$ 10q�5G   	   �� 5H   
      txtPlayerName#�Z 6   $
��Bold"�6C    �� 5I   
   $�: ��6    �� 5J   
   �6   �� *
PlayerName+5K      �� 5M   
   $��1��5N   	   $��1��5O   	   $ 10q�5P   	   �� 5Q   
      txtShirtNumber#�Z 6   $
��Bold"�6D    �� 5R   
   $�: ��6    �� 5S   
   �6   �� *ShirtNumber+5T      �� 5V   
   $��2��5W   	   $��0��5X   	   $ 10q�5Y   	   �� 5Z   
      txtPosition#�Z 6   $
��Bold"�6A    �� 5[   
   $�: ��6    �� 5\   
   �6   �� *
Position+5]      �� 5_   
   $��2��5`   	   $��1��5a   	   $ 10q�5b   	   �� 5c   
      
txtCaptain#�Z 6   $
��Bold"�6@    �� 5d   
   $�: ��6    �� 5e   
   �6   �� *	Captain+5f      �� 5h   
   $��3��5i   	   $��0��5j   	   $ 10q�5k   	   �� 5l   
      txtGoalsScored#�Z 6   $
��Bold"�6D    �� 5m   
   $�: ��6    �� 5n   
   �6   �� *GoalsScored+5o      �� 5q   
   $��3��5r   	   $��1��5s   	   $ 10q�5t   	   �� 5u   
      txtYellowCards#�Z 6   $
��Bold"�6D    �� 5v   
   $�: ��6    �� 5w   
   �6   �� *YellowCardsReceived+5x      5y      5z      