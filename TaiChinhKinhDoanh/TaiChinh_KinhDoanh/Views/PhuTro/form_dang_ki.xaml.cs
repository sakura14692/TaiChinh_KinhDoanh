using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using TaiChinh_KinhDoanh.Views.message_Box;

namespace TaiChinh_KinhDoanh.Views.PhuTro
{
    /// <summary>
    /// Interaction logic for form_dang_ki.xaml
    /// </summary>
    public partial class form_dang_ki : Window
    {
        public form_dang_ki()
        {
            InitializeComponent();

            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

        }

        string flag="";



        string chuoiketnoi;
        messageBox_Thuan_Tuy_Thong_Bao messageBox_ThongBao_CoBan_Cua_FormDangKi = new messageBox_Thuan_Tuy_Thong_Bao();
        public DataTable dang_ki() 
        {
            DataTable data = new DataTable();
            string truyvan = "insert dang_nhap(ten_dang_nhap,mat_khau,xac_nhan_mat_khau,ho_ten,so_dien_thoai,email) " +
                   "values('" + textbox_ten_dang_nhap.Text + "','" + passwordbox_mat_khau.Password + "' , '" + passwordbox_mat_khau.Password + "' , '" + textbox_ho_ten.Text + "' ,  '" + texbox_so_dien_thoai.Text + "'  , '" + textbox_email.Text + "'  ) ";


            try
            {

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




        public bool text_Box_isNotNull()
        {

            if (string.IsNullOrEmpty(textbox_ten_dang_nhap.Text))
            {
                messageBox_ThongBao_CoBan_Cua_FormDangKi.Show_Message("Bạn phải điền 'Tên đăng nhập' !","Nhắc nhở","lightgreen");
               
                textbox_ten_dang_nhap.Focus();
                return false;
            }
            else

            if (string.IsNullOrEmpty(passwordbox_mat_khau.Password))
            {
                messageBox_ThongBao_CoBan_Cua_FormDangKi.Show_Message("Bạn phải nhập 'Mật khẩu' !", "Nhắc nhở", "lightgreen");
                passwordbox_mat_khau.Focus();
                return false;
            }
            else


                if (string.IsNullOrEmpty(passwordbox_xac_nhan_mat_khau.Password))
            {
                messageBox_ThongBao_CoBan_Cua_FormDangKi.Show_Message("Bạn phải xác nhận 'Mật khẩu' !", "Nhắc nhở", "lightgreen");
                passwordbox_xac_nhan_mat_khau.Focus();
                return false;
            }
            else


                if (passwordbox_mat_khau.Password != passwordbox_xac_nhan_mat_khau.Password)
            {
                messageBox_ThongBao_CoBan_Cua_FormDangKi.Show_Message("'Mật khẩu' và 'Xác nhận mật khẩu phải giống nhau' !", "Cảnh báo", "red");
                passwordbox_xac_nhan_mat_khau.Focus();
                return false;
            }






            return true;
        }
















        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_luu_Click(object sender, RoutedEventArgs e)
        {
            if (text_Box_isNotNull()) 
            {
                dang_ki();
                if (flag != "lỗi đăng kí") messageBox_ThongBao_CoBan_Cua_FormDangKi.Show_Message("Xin chúc mừng bạn đã đăng kí thành công !");

            } 

           


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void button_Minimized_Click(object sender, RoutedEventArgs e)
        {
          
            this.WindowState = WindowState.Minimized;
        }
    }
}
