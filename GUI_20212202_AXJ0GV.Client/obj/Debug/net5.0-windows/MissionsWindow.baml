   M S B A M L   `   `   `  ����U  QGUI_20212202_AXJ0GV.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GUI_20212202_AXJ0GV.ClientGUI_20212202_AXJ0GV.Client  5   	   Y1clr-namespace:GUI_20212202_AXJ0GV.Client.Renderer#GUI_20212202_AXJ0GV.Client.Renderer  5   	   S.clr-namespace:GUI_20212202_AXJ0GV.Client.Logic GUI_20212202_AXJ0GV.Client.Logic  5   	   [2clr-namespace:GUI_20212202_AXJ0GV.Client.Converter$GUI_20212202_AXJ0GV.Client.Converter  5	   	   /    )GUI_20212202_AXJ0GV.Client.MissionsWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:GUI_20212202_AXJ0GV.Client     5   	   Frenderer1clr-namespace:GUI_20212202_AXJ0GV.Client.Renderer     5   	   >asd.clr-namespace:GUI_20212202_AXJ0GV.Client.Logic     5   	   Casd22clr-namespace:GUI_20212202_AXJ0GV.Client.Converter     5	   	   -   5          � Title$  Missions��5   	   $	��600��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�63   $	��600��5   	   $	��800��6    � DataContext 5      0   *GUI_20212202_AXJ0GV.Client.Logic.GameLogic  5   
    � 	Resources 5      ��%    5      ��5      
� 5   
   .��5      �  � Color$ Black��6   � 5      $ 	#FF180A3C��6    � Offset$ 1Q�6-   5      .��5      � -   5         �Name$
 grid��5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��9* �6   .+�5   
   9  3GUI_20212202_AXJ0GV.Client.Renderer.DisplayMissions  -   5          Name$ displayMission��5   #   $��2��6;   A� 5   
   	 A� Columns$	 2��6   
 A� Rows$
 2��6"   .+�5       �� $��Center=�6   
�������$��	Controls:��6D   $��
ExtraBlack"�6X   �� 5!      $��Center=�6   
�������$
��Goal��6D   $��
ExtraBlack"�6S   �� 5"      $��Center=�6   
�������$3��-Arrows to turn, RAlt to shoot, RCtrl to 180°��6D   $��
ExtraBlack"�6{   �� 5#      $��Center=�6   
�������$!��To clear out the satellites��6D   $��
ExtraBlack"�6j   5$      5%      5&      