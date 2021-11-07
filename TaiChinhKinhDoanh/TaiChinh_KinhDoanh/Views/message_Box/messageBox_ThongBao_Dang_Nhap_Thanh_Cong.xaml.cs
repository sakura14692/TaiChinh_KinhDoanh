using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaiChinh_KinhDoanh.Views.message_Box
{
    /// <summary>
    /// Interaction logic for messageBox_ThongBao_Dang_Nhap_Thanh_Cong.xaml
    /// </summary>
    public partial class messageBox_ThongBao_Dang_Nhap_Thanh_Cong : Window
    {
        public messageBox_ThongBao_Dang_Nhap_Thanh_Cong()
        {
            InitializeComponent();
        }


        public delegate void truyen_gia_tri_giua_cac_window(bool parameter);
        public event truyen_gia_tri_giua_cac_window nut_Dong;











        public void Show_Message(string message, string TieuDe = null, string Color = null)
        {
            this.Show();

            textblock_ThongBao.Text = message;
            textBlock_TieuDe.Text = TieuDe;

            if (Color == "red")
            {
                textblock_ThongBao.Foreground =
                textBlock_TieuDe.Foreground =
                textblock_Dong.Foreground =
                border_form.BorderBrush =
                border_image.BorderBrush =
                button_Dong.BorderBrush

                     = Brushes.Red;


            }
            else

             if (Color == "gold")
            {
                textblock_ThongBao.Foreground =
                textBlock_TieuDe.Foreground =
                textblock_Dong.Foreground =
                border_form.BorderBrush =
                border_image.BorderBrush =
                button_Dong.BorderBrush

                     = Brushes.Gold;


            }








        }

        private void button_Dong_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            nut_Dong(true);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }





    }
}
