   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp.FormsWpfApp.Forms  5   	   5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	   "    WpfApp.Forms.TeamInformation   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp.Forms     5   	   6
propertiesclr-namespace:WpfApp.Properties     5   	   !   WpfApp.Properties.Resources    teamInfoTitle � Title# Z  5	   	   $	��450��6?   $	��800��6L    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 30 15 10 15q�6'   �� 5       � ��$ Center=�62   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Wrap=�6-   5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$
 Left�5      	 W� From	 19205      	
 W� To
 706!    g� Duration$ 0:0:0.5D�5       g� AccelerationRatio$	 0.1Q�5      5      5      5      .��5      � $��20q�6    � ColumnDefinitions 5    
   �� 5!      $
��1.2* �6   �� 5"      $
��1.3* �6    � RowDefinitions 5$   
   �� 5%      $��1* �6   �� 5&      $��1* �6   �� 5'      $��1* �6   �� 5(      $��1* �6   .+�5+   
   �� -   5         ��Name$ TxtName��5,   	   $��0��5-   	   $��0��5.   	    �� Padding$ 10q�5/   	   �� 50   
      txtTeamName#�Z 6   $
��Bold"�6A    �� 51   
   $�: ��6    �� 52   
   �6   �� *
TeamName+53      �� 55   
   -   5        $ TxtFifaCode��56   	   $��0��57   	   $��1��58   	   $ 10q�59   	   �� 5:   
      txtFifaCode#�Z 6   $
��Bold"�6A    �� 5;   
   $�: ��6    �� 5<   
   �6   �� *
FifaCode+5=      �� 5?   
   -   5        $ TxtMatchesPlayed��5@   	   $��1��5A   	   $��0��5B   	   $ 10q�5C   	   �� 5D   
      txtMatchesPlayed#�Z 6   $
��Bold"�6F    �� 5E   
   $�: ��6    �� 5F   
   �6   �� *MatchesPlayed+5G      �� 5I   
   -   5        $ TxtMatchesWon��5J   	   $��1��5K   	   $��1��5L   	   $ 10q�5M   	   �� 5N   
      txtMatchesWon#�Z 6   $
��Bold"�6C    �� 5O   
   $�: ��6    �� 5P   
   �6   �� *
MatchesWon+5Q      �� 5S   
   -   5        $ TxtMatchesLost��5T   	   $��2��5U   	   $��0��5V   	   $ 10q�5W   	   �� 5X   
      txtMatchesLost#�Z 6   $
��Bold"�6D    �� 5Y   
   $�: ��6    �� 5Z   
   �6   �� *MatchesLost+5[      �� 5]   
   -   5        $ TxtMatchesDraw��5^   	   $��2��5_   	   $��1��5`   	   $ 10q�5a   	   �� 5b   
      txtMatchesDraw#�Z 6   $
��Bold"�6D    �� 5c   
   $�: ��6    �� 5d   
   �6   �� *MatchesDraw+5e      �� 5g   
   -   5        $ TxtGoalsScored��5h   	   $��3��5i   	   $��0��5j   	   $ 10q�5k   	   �� 5l   
      txtGoalsScored#�Z 6   $
��Bold"�6D    �� 5m   
   $�: ��6    �� 5n   
   �6   �� *GoalsScored+5o      �� 5q   
   -   5        $ TxtGoalsReceived��5r   	   $��3��5s   	   $��1��5t   	   $ 10q�5u   	   �� 5v   
      txtGoalsReceived#�Z 6   $
��Bold"�6F    �� 5w   
   $�: ��6    �� 5x   
   �6   �� *GoalsReceived+5y      5z      5{      