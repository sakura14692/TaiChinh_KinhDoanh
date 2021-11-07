using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using TaiChinh_KinhDoanh.Views.message_Box;

namespace TaiChinh_KinhDoanh.Views.PhuTro
{
    /// <summary>
    /// Interaction logic for form_DangNhap.xaml
    /// </summary>
    public partial class form_DangNhap : Window
    {
        public form_DangNhap()
        {
            InitializeComponent();

            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath)) 
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }




        }


        messageBox_ThongBao_Dang_Nhap_Thanh_Cong messageBox_ThongBao_DangNhap_ThanhCong;
        messageBox_Thuan_Tuy_Thong_Bao messageBox_nhac_nho_hoac_canh_bao = new messageBox_Thuan_Tuy_Thong_Bao();

        string chuoiketnoi;


        public DataTable tai_khoan_nguoi_dung() 
        {

            
            DataTable data = new DataTable();

            try
            {


                string truyvan = "select * from dang_nhap where ten_dang_nhap ='" + textBox_Ten_Dang_Nhap.Text + "' and mat_khau ='" + passwordBox_Mat_Khau.Password + "'";
                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();


                }


            }
            catch (Exception ex)
            {

                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            

            return data;
        }




        public DataTable tai_khoan_Admin()
        {


            DataTable data = new DataTable();

            try
            {

                string truyvan = "select * from ho_so_admin where ten_dang_nhap  = '" + textBox_Ten_Dang_Nhap.Text + "' and mat_khau ='" + passwordBox_Mat_Khau.Password + "'";
                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();


                }



            }
            catch (Exception ex)
            {

                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);


            }

            

            return data;
        }



        public void dang_nhap() 
        {

            if (tai_khoan_nguoi_dung().Rows.Count > 0 || tai_khoan_Admin().Rows.Count > 0)
            {

                messageBox_ThongBao_DangNhap_ThanhCong = new messageBox_ThongBao_Dang_Nhap_Thanh_Cong();
                messageBox_ThongBao_DangNhap_ThanhCong.Show_Message("Bạn đã đăng nhập thành công !", "Thông báo", "gold");
                messageBox_ThongBao_DangNhap_ThanhCong.nut_Dong += MessageBox_ThongBao_nut_Dong;



            }
            else
            {

             
                messageBox_nhac_nho_hoac_canh_bao.Show_Message("Mật khẩu hoặc tên đăng nhập không đúng,Xin hãy thử lại !", "Cảnh báo", "red");

                textBox_Ten_Dang_Nhap.Text = "Tên đăng nhập";
                passwordBox_Mat_Khau.Password = "Mật khẩu";
            }



        }



        public bool text_Box_isNotNull()
        {

            if (string.IsNullOrEmpty(textBox_Ten_Dang_Nhap.Text))
            {

                messageBox_nhac_nho_hoac_canh_bao.Show_Message("Bạn phải điền 'Tên đăng nhập' !");
                textBox_Ten_Dang_Nhap.Focus();
                return false;
            }
            else

             if (string.IsNullOrEmpty(passwordBox_Mat_Khau.Password))
            {
                messageBox_nhac_nho_hoac_canh_bao.Show_Message("Bạn phải nhập 'Mật khẩu' !");
                passwordBox_Mat_Khau.Focus();
                return false;
            }
           


            return true;
        }

        private void MessageBox_ThongBao_nut_Dong(bool parameter)
        {
            this.Hide();
            
            
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }


        private void Button_Thoat_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            if (tai_khoan_nguoi_dung().Rows.Count ==0 || tai_khoan_Admin().Rows.Count==0) App.Current.Shutdown();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }


        private void Button_Dang_NHap_Click(object sender, RoutedEventArgs e)
        {
            if (text_Box_isNotNull() == true) dang_nhap();
            
        }


        private void textBox_Ten_Dang_Nhap_GotFocus(object sender, RoutedEventArgs e)
        {
           
            textBox_Ten_Dang_Nhap.Text = null;
            textBox_Ten_Dang_Nhap.Foreground = Brushes.Gold;
            textBox_Ten_Dang_Nhap.Opacity = 1;
        }


        private void textBox_Mat_Khau_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox_Mat_Khau.Password = null;
            passwordBox_Mat_Khau.Foreground = Brushes.Gold;
            passwordBox_Mat_Khau.Opacity = 1;
        }

        private void Button_Dang_Ki_Click(object sender, RoutedEventArgs e)
        {
            form_dang_ki dang_Ki = new form_dang_ki();
            dang_Ki.Show();

        }

        
    }
}
