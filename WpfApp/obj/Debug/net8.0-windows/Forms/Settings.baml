   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp.FormsWpfApp.Forms  5   	   5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	       WpfApp.Forms.Settings   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp.Forms     5   	   6
propertiesclr-namespace:WpfApp.Properties     5   	   !   WpfApp.Properties.Resources    settingsTitle � Title# Z  5	   	   $	��550��5
   	   $	��800��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��225* �6   �� 5      $	��45* �6   �� 5      $
��225* �6   �� 5      $
��267* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $
��1.5* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ gbTournamentType��5   	   $��0��5   	   $��0��5   	   $��10q�5   	   $��2��6      tournamentType#��Z 5    	   ��5!      �� 5"      -   5         ��Name$ PnlTournamentType��5"      $��0 15 0 0q�68   .+�5#      	�  	� 	GroupName$ tournamentType��6"   	 d� 	IsChecked$
	 TrueY�6=   

 � Tag$

 male��6N   $��5q�6Y      male#��Z 6d   	� 5$      $ tournamentType��6"   $
 female��6=   $��5q�6J      female#��Z 6U   5%      5'      �� 5*   
   -   5        $ 
GbLanguage��5-   	   $��2��5+   	   $��0��5,   	   $��10q�5.   	   $��2��6      language#��Z 5/   	   ��50      �� 51      -   5        $ PnlLanguage��51      $��0 15 0 0q�62   .+�52      	� $ language��6"   $
	 TrueY�67   $
 EN��6H   $��5q�6Q      english#��Z 6\   	� 53      $ language��6"   $
 HR��67   $��5q�6@      croatian#��Z 6K   54      56      �� 59   
   $��4��5:   	   $��0��5;   	   $��10q�5<   	      appSize#��Z 5=   	   ��5>      �� 5?      -   5        $ 
PnlAppSize��5?      $��0 15 0 0q�61   .+�5@      	� $ appSize��6"   $
	 TrueY�66   $
 small��6G   $��5q�6S      small#��Z 6^   	� 5A      $ appSize��6"   $
 medium��66   $��5q�6C      medium#��Z 6N   	� 5B      $ appSize��6"   $
 
fullscreen��66   $��5q�6G      
fullScreen#��Z 6R   5C      5E      �� 5H   
   $��1��5I   	   $��1��5J      $��3��5K      $��
10,0,10,10q�5L         
dataSource#��Z 5M      ��5N      �� 5O      -   5        $ PnlDataSource��5O      $��0 10 0 0q�64   .+�5P      	� $ 
dataSource��6"   $
	 TrueY�69   $	
 API��6J   $��5q�6T   $	��API��6_   	� 5Q      $ 
dataSource��6"   $

 JSON��69   $��5q�6D   $
��JSON��6O   5R      5T      �� 5W   
   -   5        $��2��5X   	   $��2��5Y   	   $��20,10,20,20q�5Z   	   $	��150��5[   	   $��Center=�5\   	      btnSettingsSave#��Z 5^   	   $��2��6C   5_      5`      