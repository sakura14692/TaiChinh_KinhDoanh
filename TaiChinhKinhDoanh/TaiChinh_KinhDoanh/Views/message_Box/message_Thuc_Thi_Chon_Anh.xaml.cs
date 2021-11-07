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
    /// Interaction logic for message_Thuc_Thi_Chon_Anh.xaml
    /// </summary>
    public partial class message_Thuc_Thi_Chon_Anh : Window
    {
        public message_Thuc_Thi_Chon_Anh()
        {
            InitializeComponent();
        }


        public delegate void truyen_gia_tri_giua_cac_window(bool parameter);
        public event truyen_gia_tri_giua_cac_window nut_Co, nut_Khong;

        private void button_Co_Click(object sender, RoutedEventArgs e)
        {
            nut_Co(true);
        }

        private void button_Khong_Click(object sender, RoutedEventArgs e)
        {
            nut_Khong(true);

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        public void Show_Message(string message)
        {
            this.Show();

            textblock_ThongBao.Text = message;


        }






    }
}
