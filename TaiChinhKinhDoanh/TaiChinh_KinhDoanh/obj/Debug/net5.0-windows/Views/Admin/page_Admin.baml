   M S B A M L   `   `   `  ����M  ITaiChinh_KinhDoanh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:TaiChinh_KinhDoanh.Views.AdminTaiChinh_KinhDoanh.Views.Admin  5      /    )TaiChinh_KinhDoanh.Views.Admin.page_Admin   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:TaiChinh_KinhDoanh.Views.Admin     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a@Material1http://materialdesigninxaml.net/winfx/xaml/themes  6B     N� Title$  
page_Admin��5	      .��5      � ��5   
   �� 5       �� EndPoint$ 0.8,1&�6"    �� 
StartPoint$	 0,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FF242B3A��6    � Offset$ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $	��250 �5      5      �� 5      $��* �5      5       � RowDefinitions 5   
   �� 5       $��30 �5!      5$      �� 5%      $��* �5&      5)      .+�5,   
   � $��1��5-      $��Stretch=�5.      ��52      �� 53      $ 0.8,1&�6&   $ 0.8,0&�67   .��54      � $ Black��6#   � 55      $ 	#FF1A1029��6#   $	 0.8Q�65   56       59      �� 5:      $	��100 �6    6/   �� 5;      6"   .+�5=      �� $��Center=�6   $��Center=�5>      
�������$
��Wrap=�5@      $��20(�5A      $��Arial)�6&    J� Opacity$	 0.7Q�5B      �� 5D      .�6   Admin6   5F      �� 5H      $��1��5I      .+�5L      �� -   5         ��Name$! button_Thong_tin_nguoi_dung��5L      $��10q�5M      $��30��5N      $	��200��5O      $��2q�5P      
�������.��5S      � $	��175��5T      .+�5V      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $#��packicon_thong_tin_nguoi_dung��5W      	   Kind$	 Notebook=�5X      
�������5\      �� 5]      -   5        
 ��Name$$
 textblock_thong_tin_nguoi_dung��5^      $��Right=�5_      
�������$��16(�5a      Thông tin người dùng5d      5e      5g      �� 5j      -   5        $ button_Che_do_bao_mat��5j      $��10q�5k      $��30��5l      $	��200��5m      $��2q�5n      
�������.��5q      � $	��175��5r      .+�5t        -   5        $��packicon_che_do_bao_mat��5u      $	 Security=�5v      
�������5z      �� 5{      -   5        $
 textblock_che_do_bao_mat��5|      $��Right=�5}      
�������$��16(�5      Chế độ bảo mật5�      5�      5�      5�      5�      � 5�   
   $��2��5�      ��5�      �� 5�      $ 0.7,0&�6&   $ 0.5,0.2&�67   .��5�      � $ MediumSlateBlue��6#   $ 1Q�6;   � 5�      $ 	#FF332D56��6#   $	 0.2Q�65   5�      .+�5�      ��  �� Orientation$ 
Horizontal=�5�      $��Right=�5�      ��5�      Z� .+�5�      �� $��25��5�      $��25��5�      ��5�      Z� .��5�        $	 WindowMinimize=�5�      
�������5�      5�      �� 5�      $��25��5�      $��25��5�      ��5�      Z� .��5�        $	 WindowMaximize=�5�      
�������5�      5�      �� 5�      $��25��5�      $��25��5�      ��5�      Z� .��5�        $	 Power=�5�      
�������5�      5�      5�      5�      � 5�   
   -   5         �Name$! grid_Add_UserControls_Admin��5�      $��1��5�      $��1��5�      .+�5�      �� -   5         ��Name$ image_Admin��5�      $��Uniform=�5�      ��5�      �� *Source+5�      5�      5�      5�      