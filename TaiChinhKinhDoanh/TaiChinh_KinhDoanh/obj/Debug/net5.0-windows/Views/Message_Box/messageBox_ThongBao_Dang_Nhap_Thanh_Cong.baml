   M S B A M L   `   `   `  ����M  ITaiChinh_KinhDoanh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:TaiChinh_KinhDoanh.Views.message_Box$TaiChinh_KinhDoanh.Views.message_Box  5   	   S    MTaiChinh_KinhDoanh.Views.message_Box.messageBox_ThongBao_Dang_Nhap_Thanh_Cong   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:TaiChinh_KinhDoanh.Views.message_Box     5   	   -   5          � Title$.  (messageBox_ThongBao_Dang_Nhap_Thanh_Cong��5   	   $	��300��5	      $	��500��6    � WindowStyle$
 None=�5
   	   
���OO/� � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ border_form��5      
����� �$��3q�5       �� CornerRadius$ 3��5      5      � 5   
   -   5         �Name$ grid_message_image��5      $	��Top=�5       � ColumnDefinitions 5"      �� 5#      6%   �� 5$      6%   .+�5(      �� -   5        $ border_image��5)      $	��Top=�5*      $��Right=�5+      $	��180��5,      $	��200��5-      $��10q�5.      $ 3��5/      $��3q�50      
����� �$��1��53      ._�55      �� $��Center=�56      $��Center=�57      $6��0/Views/PhuTro/anh-gai-xinh-2k-de-thuong-cute.jpg��58      $��UniformToFill=�6M   5;      5>      �� 5B      -   5         ��Name$ textblock_ThongBao��5C      $��Center=�5D      $��Center=�5E      $��20,0,0,0q�5F      
����� �$��20(�5H      $
��Wrap=�5I      ok5N      �� 5Q      -   5        $ textBlock_TieuDe��5R      $	��Top=�5S      $��Center=�5T      $��30(�5U      
����� �$��20q�5W      Thông Báo5Z      5\      �� 5_   
   -   5        	 ��Name$	 button_Dong��5`      
 �� 	IsDefault$

 True��5a      $��Bottom=�5b      $��Center=�5c      $��30��5d      $��70��5e      $��20q�5f      
����� �
����� �$��3q�5i      .��5l      �� -   5        $ textblock_Dong��5m      $��Center=�5n      $��Center=�5o      $��16(�5p      Đóng5s      5t      5y      5z      