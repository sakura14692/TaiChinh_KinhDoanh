using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TaiChinh_KinhDoanh.Views.PhuTro
{
    /// <summary>
    /// Interaction logic for form_Mo_man.xaml
    /// </summary>
    public partial class form_Mo_man : Window
    {
        public form_Mo_man()
        {
            InitializeComponent();

            chay_Khau_hieu();

        }

        string[] khau_hieu = { "Phần", "mềm", "hỗ", "trợ", "quản", "lý", "Tài", "chính ", "-", " Kinh", "doanh : ", "TaiChinh_KinhDoanh1.0,", "được", "thiết", "kế", "bởi", "Trungpro", "chi", "tiết", "xin", "liên", "hệ", "Facebook : Tokyo Dũng ",
            " ", "", "", "", "", "", "", "", "","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",
        "","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",""};
        DispatcherTimer timer = new DispatcherTimer();
        public void chay_Khau_hieu() 
        {

           

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        int i = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
          
            //textblock_Mo_man.Text = textblock_Mo_man.Text + " " + khau_hieu[i];
            if (i == 10) 
            {
                timer.Stop();
                this.Close(); 

            }
            
                 i++;
        }

        private void button_tam_dung_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            button_tiep_tuc.Visibility = Visibility.Visible;
            button_tam_dung.Visibility = Visibility.Collapsed;
        }

        private void button_tiep_tuc_Click(object sender, RoutedEventArgs e)
        {
            button_tiep_tuc.Visibility = Visibility.Collapsed;
            button_tam_dung.Visibility = Visibility.Visible;
            timer.Start();
        }
    }
}
