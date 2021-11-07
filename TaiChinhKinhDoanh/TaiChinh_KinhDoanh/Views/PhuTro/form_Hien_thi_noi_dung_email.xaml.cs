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

namespace TaiChinh_KinhDoanh.Views.PhuTro
{
    /// <summary>
    /// Interaction logic for form_Hien_thi_noi_dung_email.xaml
    /// </summary>
    public partial class form_Hien_thi_noi_dung_email : Window
    {
        public form_Hien_thi_noi_dung_email()
        {
            InitializeComponent();
        }



        public void hien_thi_tin_nhan_den(string tin_nhan,string tieu_de) 
        {
            string sua_tin_nhan1 = tin_nhan.Replace("--------", "\n\n");
            string sua_tin_nhan2 = sua_tin_nhan1.Replace(">","");
            string sua_tin_nhan3 = sua_tin_nhan2.Replace("<", "");

            textblock_tin_nhan.Text = sua_tin_nhan3;
            textblock_TieuDe.Text = tieu_de;
        
        
        
        }



        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void button_Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
