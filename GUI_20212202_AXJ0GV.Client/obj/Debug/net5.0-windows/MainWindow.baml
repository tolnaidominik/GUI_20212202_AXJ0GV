   M S B A M L   `   `   `  ����U  QGUI_20212202_AXJ0GV.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GUI_20212202_AXJ0GV.ClientGUI_20212202_AXJ0GV.Client  5   	   S.clr-namespace:GUI_20212202_AXJ0GV.Client.Logic GUI_20212202_AXJ0GV.Client.Logic  5   	   [2clr-namespace:GUI_20212202_AXJ0GV.Client.Converter$GUI_20212202_AXJ0GV.Client.Converter  5   	   Y1clr-namespace:GUI_20212202_AXJ0GV.Client.Renderer#GUI_20212202_AXJ0GV.Client.Renderer  5	   	   +    %GUI_20212202_AXJ0GV.Client.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:GUI_20212202_AXJ0GV.Client     5   	   >asd.clr-namespace:GUI_20212202_AXJ0GV.Client.Logic     5   	   Casd22clr-namespace:GUI_20212202_AXJ0GV.Client.Converter     5   	   Frenderer1clr-namespace:GUI_20212202_AXJ0GV.Client.Renderer     5	   	   -   5          �Name$  Client_window��5   	    � Title$ 	Lasteroid��5   	   $	��600��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   $	��600��5   	   $	��800��6    � DataContext 5      0   *GUI_20212202_AXJ0GV.Client.Logic.GameLogic  5   
    � 	Resources 5      I   CGUI_20212202_AXJ0GV.Client.Converter.HealthBarValueToColorConverter   healthbarConverter��%   &	          5   
   6.   5      ��5      
� 5   
   .��5      �  � Color$ Black��6   � 5      $ 	#FF180A3C��6    � Offset$ 1Q�6-   5      .��5      � -   5         �Name$
 grid��5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��1* �6   .+�5   
   1   +GUI_20212202_AXJ0GV.Client.Renderer.Display  -   5        	  Name$	 display��5      $��3��6,   A� 5    
   
 A� Columns$
 3��6    A� Rows$ 2��6"   .+�5!      �� $��Center=�6   
�������$��Health:��6D   $��
ExtraBlack"�6V   �� 5"      $��Center=�6   
�������$��Time:��6D   $��
ExtraBlack"�6T   �� 5#      $��Center=�6   
�������$��Player name:��6D   $��
ExtraBlack"�6[   � 5$      -   5         �Name$ 	healthBar��5$      $��5 0 5 5q�6-   ��6>   ��  �� 	Converter# [  �� 5%      -   5         ��Name$
 Cock��5%      $��Center=�6"   
�������$��15(�6R   $��5 0 5 0q�6`   $��
ExtraBlack"�6q   �� 5&      -   5        $ 
PlayerName��5&      $��Center=�6(   
�������$��15(�6X   $��5 0 5 0q�6f   $��
ExtraBlack"�6w   5'      A� 5(   
   $��2��6   $
 2��6#   .+�5)      ]� .+�5*      �� $��Asteroid��6   
�������$��15(�6>   �� 5+       �� Orientation$ 
Horizontal=�6!   .+�5,      �� $��Level:��6    
�������$��15(�6D   �� 5-      -   5        $ Asteroid_Level��5-       
�������$��15(�6K   �� 5.      $��Health:��6    
�������$��15(�6E   �� 5/      -   5        $ Asteroid_Health��5/       
�������$��15(�6L   �� 50      $��Damage:��6    
�������$��15(�6E   �� 51      -	   5        $ Asteroid_Damage��51       
�������$��15(�6L   52      54      ]� 55      .+�56      �� $��Player��6   
�������$��15(�6<   �� 57      $ 
Horizontal=�6!   .+�58      �� $��Level:��6    
�������$��15(�6D   �� 59      -
   5        $ Player_Level��59       
�������$��15(�6I   �� 5:      $	��XP:��6    
�������$��15(�6A   �� 5;      -   5        $ 	Player_XP��5;       
�������$��15(�6F   �� 5<      $��Damage:��6    
�������$��15(�6E   �� 5=      -   5        $ Player_Damage��5=       
�������$��15(�6J   5>      5@      5A      5B      5D      