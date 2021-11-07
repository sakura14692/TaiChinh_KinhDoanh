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
using System.Windows.Threading;

namespace TaiChinh_KinhDoanh.Views.message_Box
{
    /// <summary>
    /// Interaction logic for messageBox_Thuan_Tuy_Thong_Bao.xaml
    /// </summary>
    public partial class messageBox_Thuan_Tuy_Thong_Bao : Window
    {
        public messageBox_Thuan_Tuy_Thong_Bao()
        {
            InitializeComponent();
            
        }

        public delegate void truyen_gia_tri_giua_cac_window(bool parameter);
        public event truyen_gia_tri_giua_cac_window nut_Dong;
        DispatcherTimer timer = new DispatcherTimer();







        public void Timer_nhap_nhay_canh_bao_mau_do() 
        {

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        
            timer.Start();
            
        
        
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

          
        }

        

        

        
       


      
        




        public void Show_Message(string message,string TieuDe=null,string Color = null)
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

            else

             if (Color == "lightgreen")
            {
                textblock_ThongBao.Foreground =
                textBlock_TieuDe.Foreground =
                textblock_Dong.Foreground =
                border_form.BorderBrush =
                border_image.BorderBrush =
                button_Dong.BorderBrush

                     = Brushes.LightGreen;
                Timer_nhap_nhay_canh_bao_mau_do();

            }








        }

        private void button_Dong_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

    }
}
