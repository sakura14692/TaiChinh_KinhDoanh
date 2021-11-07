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
    /// Interaction logic for form_Gui_bao_cao_Bang_email.xaml
    /// </summary>
    public partial class form_Gui_bao_cao_Bang_email : Window
    {
        public form_Gui_bao_cao_Bang_email()
        {
            InitializeComponent();

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            this.Cursor = Cursors.Arrow;

            



        }

        string tieuDe;


        public void hien_thi_thong_tin_can_gui(string textblock1 = null, string textblock2 = null, string textblock3 = null, string textblock4 = null, string textblock5 = null, string textblock6 = null, string textblock7 = null, string textblock8 = null, string textblock9 = null, string textblock10 = null, string textblock11 = null, string tieude = null) 
        {

            textblock_1.Text = textblock1  + "\n" + " -------- ";
            textblock_2.Text = textblock2 +  "\n" + " -------- ";
            textblock_3.Text = textblock3 +  "\n" + " -------- ";
            textblock_4.Text = textblock4 +  "\n" + " -------- ";
            textblock_5.Text = textblock5 +  "\n" + " -------- ";
            textblock_6.Text = textblock6 +  "\n" + " -------- ";
            textblock_7.Text = textblock7 +  "\n" + " -------- ";
            textblock_8.Text = textblock8 +  "\n" + " -------- ";
            textblock_9.Text = textblock9 + "\n" + " -------- ";
            textblock_10.Text = textblock10 + "\n" + " -------- ";
            textblock_11.Text = textblock11 + "\n" + " -------- ";


            tieuDe = tieude;
            textblock_TieuDe.Text = tieude;

        }




        public bool textIsnotNull()
        {

            if (string.IsNullOrEmpty(textbox_ten_Nguoi_gui.Text))
            {
                MessageBox.Show("'Người gửi' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_ten_Nguoi_gui.Focus();

                return false;
            }
            else
            if (string.IsNullOrEmpty(password_box_Mat_khau.Password))
            {
                MessageBox.Show("'Mật khẩu' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                password_box_Mat_khau.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_nguoi_nhan.Text))
            {

                MessageBox.Show("'Người nhận' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_nguoi_nhan.Focus();
                return false;
            }
           

            return true;
           }








        private void button_Gui_Click(object sender, RoutedEventArgs e)
        {

            if (textIsnotNull()) 
            {
                try
                {
                    var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
                    {

                        Credentials = new System.Net.NetworkCredential(textbox_ten_Nguoi_gui.Text, password_box_Mat_khau.Password),
                        EnableSsl = true


                    };

                    var message = new System.Net.Mail.MailMessage(textbox_ten_Nguoi_gui.Text, textbox_nguoi_nhan.Text, tieuDe,
                    textblock_1.Text +textblock_2.Text + textblock_3.Text + textblock_4.Text + textblock_5.Text  + textblock_6.Text + textblock_7.Text + textblock_8.Text + textblock_9.Text + textblock_10.Text + textblock_11.Text + string.Format("{0}  {1} ",textblock_GhiChu.Text,textbox_GhiChu.Text));

                    message.IsBodyHtml = true;
                    client.Host = "smtp.gmail.com";
                    client.Send(message);

                    MessageBox.Show("Gửi mail thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    client.Dispose();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }


           

           

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
