   M S B A M L   `   `   `  ����M  ITaiChinh_KinhDoanh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TaiChinh_KinhDoanhTaiChinh_KinhDoanh  5   	   #    TaiChinh_KinhDoanh.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TaiChinh_KinhDoanh     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  68   -   5          � Title$  
MainWindow��5   	   $	��750��6   $
��1500��6)    � WindowStartupLocation$ CenterScreen=�5	   	   
������� � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 	Resources 5         MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�5      $ GridMenu��5      .\�5        $ 0��5      $ 60Q�6!   5        5      $ 0:0:0.5��5       $	 200Q�6'   5#      5%      5&      �� 5)   
   .��5,      U� $ (FrameworkElement.Width)�5-      $ GridMenu��5.      .\�50        $ 0��51      $	 200Q�6!   54        56      $ 0:0:0.5��57      $ 60Q�6'   5:      5<      5=      5G      	 � Triggers	 5I      :� 5K   
   
 :� RoutedEvent$
 ButtonBase.Click��5L       :� 
SourceName$ ButtonOpenMenu��5M      .[�5Q      �� #��[  5R      5U      5V      :� 5Y   
   $
 ButtonBase.Click��5Z      $ ButtonCloseMenu��5[      .[�5_      �� #��[ 5`      5c      5d      .��5q      �  � ColumnDefinitions 5v   
   �� 5w      $
��auto �6    6/   �� 5x      6!   ��5}   
   �� 5~       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5�      $ 	#FF392843��6    � Offset$ 1Q�61   5�      .+�5�   
    � -   5          �Name$ frame_Add_Pages��5�      $��1��5�      5�      � 5�   
   $��50��5�      $	��Top=�5�      $��2��5�      ��5�      �� 5�      $ 1,0.8&�6&   $	 0,0&�67   .��5�      � $ #2E333A��6#   $	 0.5Q�63   � 5�      $ 	#FF4E177F��6#   $ 1Q�65   5�      .+�5�      �� -   5         ��Name$! textblock_tieu_de_form_Main��5�      $��Tài Chính - Kinh Doanh��5�      $��Center=�5�      $��Center=�5�      $��22(�5�      5�      �� 5�      $��Center=�5�       �� Orientation$ 
Horizontal=�5�      $��Right=�5�      .+�5�      � $��Center=�5�      $��0,0,20,0q�5�      .+�5�      �� $ 
Horizontal=�5�      $��Center=�5�      .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�5�         Kind$ Clock=�5�      
�������$��0,0,5,0q�5�      5�      �� 5�      -   5        $ textblock_dong_ho��5�      $��Center=�5�      $��14(�5�      5�      5�      5�      � 5�      $��Center=�5�      $��	0,0,100,0q�5�      .+�5�      �� $ 
Horizontal=�5�      $��Center=�5�      .+�5�        $��Center=�5�      $ Calendar=�5�      
�������$��0,0,5,0q�5�      5�      �� 5�      -   5        $ textblock_lich��5�      $��Center=�5�      $��Center=�5�      $��14(�5�      5�      5�      5�      �� 5     -   5         ��Name$ button_GoBack��5     $��Right=�5     $��20��5     $��20��5	     $��5q�5
     .��5       $ 	ArrowBack=�5     
�������5     5     �� 5     -   5        $ button_GoForward��5     $��Right=�5     $��20��5     $��20��5     $��15q�5     .��5       $ ArrowForward=�5     
�������5!     5"     '  !MaterialDesignThemes.Wpf.PopupBox  5*     $��Right=�5+     $��0,0,15,0q�5,        PlacementMode$ BottomAndAlignRightEdges=�5-        	StaysOpen$ False��5.        PopupContent. 52     �� $	��150��53     .+�55     �� 
����Zj�.��5:     �� �� 6)   .�6.   Hệ thống68   6?   5;     �� 5=     
����Zj�.��5B     �� �� 6)   .�6.   Tài khoản69   6@   5C     �� 5E     
����Zj�.��5I     �� �� 6)   .�6.   Trợ giúp68   6?   5J     �� 5L     
����Zj�5P     �� 5R     -   5        $ ButtonPopup_Dang_Xuat��5S     
����Zj�.��5X     �� �� 6)   .�6.   Thoát65   6<   5Y     5]     5^     �� 5`     -	   5        $ button_minimized��5`     $��20��5a     $��20��5b     $��10q�5c     .��5e       $ WindowMinimize=�5f     
�������5j     5k     �� 5m     -
   5        $ button_window_Normal��5n     $y�	Collapsed=�5o     $��20��5p     $��20��5q     $��2q�5r     .��5u       $ SquareMedium=�5v     
�������5z     5{     �� 5~     -   5        $ button_window_Maximizied��5~     $��20��5     $��20��5�     $��1q�5�     .��5�       $ WindowMaximize=�5�     
�������5�     5�     �� 5�     -   5        $ button_close��5�     $��20��5�     $��20��5�     $��10q�5�     .��5�       $ Power=�5�     
�������5�     5�     5�     5�     � 5�  
   -   5         �Name$ GridMenu��5�     $��60��5�     $
��Left=�5�     ���#2E333A.+�5�     �� .+�5�     � $	��150��5�     ��5�     �� 5�     $ 0.8,1&�6.   $ 0.5,0&�6?   .��5�     � $ Black��6+   � 5�     $ 	#FF667285��6+   $ 1Q�6=   5�     .+�5�     �� -   5        $ ButtonCloseMenu��5�     $��60��5�     $��60��5�     $	��Top=�5�     $��Right=�5�     
����Zj�$y�	Collapsed=�5�     ��5�     Z� .��5�       $ 	ArrowLeft=�5�     
�������$��25��5�     $��25��5�     5�     5�     �� 5�     -   5        $ ButtonOpenMenu��5�     $��60��5�     $��60��5�     $	��Top=�5�     $��Right=�5�     
����Zj���5�     Z� .��5�       $
 Menu=�5�     
�������$��25��5�     $��25��5�     5�     5�     5�     �� 5�     -   5         ��Name$ ListView_Menu��5�     ���#2E333A$��Disabled=�5�     .@�5�     �� -   5         ��Name$ ListViewItem_Trang_chu��5�  #   $��60��5�      � ToolTip$ Trang chủ��6Q   .��5�     �� $ 
Horizontal=�5      .+�5       -   5          Name$ packicon_Trang_chu��5  6   $
 Home=�5  !   
�������$��Center=�5  !   $��25��5  !   $��25��5	  !   $��10q�5
  !   �� 5     
�������$��Trang chủ��5  !   $��Center=�5  !   $��Right=�5  !   $��18q�5  !   5     5     5     �� 5     -   5        $��ListViewItem_HeThong��5      $��60��5!     $ Hệ thống��6N   .��5$     �� $ 
Horizontal=�5%     .+�5(       -   5        $��packicon_Hethong��5)  !   $ Settings=�5*  !   
�������$��Center=�5,  !   $��25��5-  !   $��25��5.  !   $��10q�5/  #   52     �� 54     
�������$��Hệ thống��56  !   $��Center=�57  !   $��Right=�58  !   $��18q�59  !   5<     5=     5?     �� 5B     -   5        $��ListViewItem_Admin��5C     $��60��5D     $ Adnin��6L   .��5G     �� $ 
Horizontal=�5H     .+�5K       -   5        $��packicon_Admin��5L  !   $
 User=�5M  !   
�������$��Center=�5O  !   $��25��5P  !   $��25��5Q  !   $��10q�5R  #   5U     �� 5W     
�������$��Admin��5Y  !   $��Center=�5Z  !   $��Right=�5[  !   $��18q�5\  !   5_     5`     5b     �� 5g     -   5        $��ListViewItem_TienIch��5h     $��60��5i     .��5l     �� $ 
Horizontal=�5m     .+�5p       $ 	Extension=�5q  !   
�������$��Center=�5s  !   $��25��5t  !   $��25��5u  !   $��10q�5v  #   5y     �� 5{     
�������$��Tiện ích��5}  !   $��Center=�5~  !   $��Right=�5  !   $��18q�5�  !   5�     5�     5�     �� 5�     -   5        $��ListViewItem_TroGiup��5�     $��60��5�     .��5�     �� $ 
Horizontal=�5�     .+�5�       $
 Help=�5�  !   
�������$��Center=�5�  !   $��25��5�  !   $��25��5�  !   $��10q�5�  #   5�     �� 5�     
�������$��Trợ giúp��5�  !   $��Center=�5�  !   $��Right=�5�  !   $��18q�5�  !   5�     5�     5�     5�     5�     5�     5�     5�     