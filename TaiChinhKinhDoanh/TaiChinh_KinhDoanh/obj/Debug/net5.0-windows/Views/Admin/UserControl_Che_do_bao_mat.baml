   M S B A M L   `   `   `  ����M  ITaiChinh_KinhDoanh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:TaiChinh_KinhDoanh.Views.AdminTaiChinh_KinhDoanh.Views.Admin  5      ?    9TaiChinh_KinhDoanh.Views.Admin.UserControl_Che_do_bao_mat   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:TaiChinh_KinhDoanh.Views.Admin     5      .��5	      � ��5
   
   �� 5        �� EndPoint$  0.4,1&�6"    �� 
StartPoint$ 0.4,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FF270D46��6    � Offset$ 1Q�61   5      .+�5      � 
������ $��Center=�5      $��Center=�5      .+�5      �� $
��1000��5       $	��300��5!      
����� �$��3q�5#       �� CornerRadius$ 5��5$      ._�5'      �� $��Center=�5(      $	��250��5)      $	��950��5*      .+�5/      �� $��Center=�50      $
��Left=�51      
����� �$��25(�53      42Hỏi mật khẩu khi khởi động ứng dụng57      �� 5;      -   5         ��Name$. (checkBox_Mat_khau_khoi_dong_ung_dung_Bat��5<      $
��Left=�5=      $��Center=�5>      
����� �$��18(�5@      $��0,0,0,10q�5A      .��5D      Bật5F      �� 5H      -   5        $. (checkBox_Mat_khau_khoi_dong_ung_dung_Tat��5I      $
��Left=�5J      $��Center=�5K      
����� �$��0,0,0,10q�5M      $��18(�5N      .��5O      Tắt5Q      �� 5T      $��Center=�5U      $
��Left=�5V      
����� �$��25(�5X      nlHỏi mật khẩu khi truy cập vào mục 'Thông tin người dùng' và mục 'Chế độ bảo mật'5\      �� 5_      -   5        $4 .checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Bat��5`      $
��Left=�5a      $��Center=�5b      
����� �$��18(�5d      $��0,0,0,10q�5e      .��5h      Bật5j      �� 5l      -   5        $4 .checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat��5m      $
��Left=�5n      $��Center=�5o      
����� �$��0,0,0,10q�5q      $��18(�5r      .��5s      Tắt5u      5�      5�      5�      � 5�   
   -   5         �Name$ grid_Dang_nhap��5�      
���   �.+�5�      �� -   5         ��Name$ border_Dang_nhap��5�      $��Center=�5�      $��Center=�5�      $	��400��5�      $	��200��5�      $��3q�5�      
����� �$ 5��5�      ._�5�      �� -   5         ��Name$ stackpanel_Dang_nhap��5�      .+�5�      �� $��Center=�5�      $��Center=�5�      
����� �$��10q�5�      RPĐăng nhập bằng tài khoản Admin để truy cập chế độ bảo mật5�      �� 5�      $ 5��5�      $��2q�5�      
����·�$��Center=�5�      $	��340��5�      $��40��5�      $��1��5�      $��0,5,0,0q�5�      ._�5�      �� 	 �� Orientation$	 
Horizontal=�5�   !   $��Center=�5�   !   $��Right=�5�   !   .+�5�      �� $��0,0,12,0q�5�   %   $��Center=�5�   %   
����� �$��20��5�   !   Tài khoản Admin5�      �� 5�      -   5        
 ��Name$!
 textbox_ten_dang_nhap_Admin��5�      $��0,0,10,0q�5�   %   $��Center=�5�   $   $	��209��5�   %   $��25��5�   $   $��15(�5�   %   
������ 
������ 
������ �� 
CaretBrush
 ����.��5�   &   5�      5�      5�      �� 5�      $ 5��5�      $��2q�5�      
����·�$��Center=�5�      $	��340��5�      $��40��5�      $��1��5�      $��0,10,0,0q�5�      ._�5�      �� $	 
Horizontal=�5�   !   $��Center=�5�   !   $��Right=�5�   !   .+�5�      �� $��0,0,12,0q�5�   %   $��Center=�5�   %   
����� �$��20��5�   !   Mật khẩu Admin5�      G� 5�      -	   5         G�Name$  passwordBox_mat_khau_Admin��5�      $��0,0,10,0q�5�   %   $��Center=�5�   $   $	��209��5�   %   $��25��5�   $   $��15(�5�   %   
������ 
������ 
������ G� 
CaretBrush
 ����5     5     5     �� 5     -
   5        $��Center=�5     $	��100��5     $��30��5     $��20q�5     
����� �$��3q�5     
����� � �� 	IsDefault$
 True��5     .��5     Đăng nhập5     5"     5#     5%     5/     50     