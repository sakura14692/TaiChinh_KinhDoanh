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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaiChinh_KinhDoanh.Views.message_Box;

namespace TaiChinh_KinhDoanh.Views.Admin
{
    /// <summary>
    /// Interaction logic for UserControl_Che_do_bao_mat.xaml
    /// </summary>
    public partial class UserControl_Che_do_bao_mat : UserControl
    {
        public UserControl_Che_do_bao_mat()
        {
            InitializeComponent();


            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }


            is_checked();

            if (ket_noi_den_tat_bat_che_do_bao_mat_voi_CheckBox().Rows[0]["hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung"].ToString() == "on")
                grid_Dang_nhap.Visibility = Visibility.Visible;
            if (ket_noi_den_tat_bat_che_do_bao_mat_voi_CheckBox().Rows[0]["hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung"].ToString() == "off")
                grid_Dang_nhap.Visibility = Visibility.Collapsed;




        }










        messageBox_Thuc_thi_Tat_mat_khau_khi_xem_thong_tin_nguoi_dung message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung 
            = new messageBox_Thuc_thi_Tat_mat_khau_khi_xem_thong_tin_nguoi_dung();

        string chuoiketnoi;



        messageBox_Thuan_Tuy_Thong_Bao messageBox_nhac_nho_hoac_canh_bao = new messageBox_Thuan_Tuy_Thong_Bao();

        







        public DataTable ket_noi_den_tat_bat_che_do_bao_mat_voi_CheckBox()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "select * from tat_bat_che_do_bao_mat_voi_CheckBox ";
                SqlConnection connect = new SqlConnection(chuoiketnoi);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
                adapter.Fill(data);
                connect.Close();
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
                string truyvan = "select * from ho_so_admin where ten_dang_nhap  = '" + textbox_ten_dang_nhap_Admin.Text + "' and mat_khau ='" + passwordBox_mat_khau_Admin.Password + "'";
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

            if (tai_khoan_Admin().Rows.Count > 0)
            {

                grid_Dang_nhap.Visibility = Visibility.Collapsed;



            }
            else
            {


                messageBox_nhac_nho_hoac_canh_bao.Show_Message("Mật khẩu hoặc tên đăng nhập không đúng,Xin hãy thử lại !", "Cảnh báo", "red");

                
            }



        }



        public bool text_Box_isNotNull()
        {

            if (string.IsNullOrEmpty(textbox_ten_dang_nhap_Admin.Text))
            {

                messageBox_nhac_nho_hoac_canh_bao.Show_Message("Bạn phải điền 'Tên đăng nhập' !");
                textbox_ten_dang_nhap_Admin.Focus();
                return false;
            }
            else

             if (string.IsNullOrEmpty(passwordBox_mat_khau_Admin.Password))
            {
                messageBox_nhac_nho_hoac_canh_bao.Show_Message("Bạn phải nhập 'Mật khẩu' !");
                passwordBox_mat_khau_Admin.Focus();
                return false;
            }



            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(text_Box_isNotNull()) dang_nhap();

        }
















        public DataTable ket_noi_den_tat_bat_che_do_bao_mat()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "select * from tat_bat_che_do_bao_mat_voi_CheckBox";
                SqlConnection connect = new SqlConnection(chuoiketnoi);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
                adapter.Fill(data);
                connect.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

            return data;







        }


        public void update_Bat_mat_khau_ung_dung()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "update tat_bat_che_do_bao_mat_voi_CheckBox set hoi_mat_khau_ung_dung = 'on' ";
                SqlConnection connect = new SqlConnection(chuoiketnoi);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
                adapter.Fill(data);
                connect.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           


        }

        public void update_Tat_mat_khau_ung_dung()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "update tat_bat_che_do_bao_mat_voi_CheckBox set hoi_mat_khau_ung_dung = 'off' ";
                SqlConnection connect = new SqlConnection(chuoiketnoi);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
                adapter.Fill(data);
                connect.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }



        public void update_Bat_mat_khau_khi_xem_tin_nguoi_dung()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "update tat_bat_che_do_bao_mat_voi_CheckBox set hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung = 'on' ";
                SqlConnection connect = new SqlConnection(chuoiketnoi);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
                adapter.Fill(data);
                connect.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }




        public void update_Tat_mat_khau_khi_xem_thong_tin_nguoi_dung()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "update tat_bat_che_do_bao_mat_voi_CheckBox set hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung = 'off' ";
                SqlConnection connect = new SqlConnection(chuoiketnoi);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
                adapter.Fill(data);
                connect.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }













        public void is_checked() 
        {

            if (ket_noi_den_tat_bat_che_do_bao_mat().Rows[0]["hoi_mat_khau_ung_dung"].ToString() == "on")
            {
                checkBox_Mat_khau_khoi_dong_ung_dung_Bat.IsChecked = true;

            }
           
               if (ket_noi_den_tat_bat_che_do_bao_mat().Rows[0]["hoi_mat_khau_ung_dung"].ToString() == "off")
            {
                checkBox_Mat_khau_khoi_dong_ung_dung_Tat.IsChecked = true;

            }

            if (ket_noi_den_tat_bat_che_do_bao_mat().Rows[0]["hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung"].ToString() == "on")
            {
                checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Bat.IsChecked = true;

            }

            if (ket_noi_den_tat_bat_che_do_bao_mat().Rows[0]["hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung"].ToString() == "off")
            {
                checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat.IsChecked = true;

            }




        }












        private void checkBox_Mat_khau_khoi_dong_ung_dung_Bat_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Mat_khau_khoi_dong_ung_dung_Tat.IsChecked = false;
            checkBox_Mat_khau_khoi_dong_ung_dung_Bat.IsEnabled = false;
            checkBox_Mat_khau_khoi_dong_ung_dung_Tat.IsEnabled = true;
            update_Bat_mat_khau_ung_dung();
            

        }

        private void checkBox_Mat_khau_khoi_dong_ung_dung_Tat_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Mat_khau_khoi_dong_ung_dung_Bat.IsChecked = false;
            checkBox_Mat_khau_khoi_dong_ung_dung_Tat.IsEnabled = false;
            checkBox_Mat_khau_khoi_dong_ung_dung_Bat.IsEnabled = true;
            update_Tat_mat_khau_ung_dung();
        }

        private void checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Bat_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat.IsChecked = false;
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Bat.IsEnabled = false;
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat.IsEnabled = true;
            update_Bat_mat_khau_khi_xem_tin_nguoi_dung();
        }

        private void checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Bat.IsChecked = false;
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat.IsEnabled = false;
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Bat.IsEnabled = true;
           
           
        }




        private void checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat_Click(object sender, RoutedEventArgs e)
        {
            message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung.Show_Message

                  ("Nếu thực hiện thao tác này sẽ mang đến rủi ro bảo mật rất lớn,bạn có muốn tiếp tục không ?");
            message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung.nut_Co += Message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung_nut_Co;
            message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung.nut_Khong += Message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung_nut_Khong;

        }




        private void Message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung_nut_Khong(bool parameter)
        {
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Tat.IsChecked = false;
            checkBox_Mat_khau_xem_thong_tin_nguoi_dung_Bat.IsChecked = true;

            message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung.Hide();
        }

        private void Message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung_nut_Co(bool parameter)
        {
            update_Tat_mat_khau_khi_xem_thong_tin_nguoi_dung();
            message_Thuc_Thi_Tat_Mat_Khau_Khi_Xem_Thong_Tin_Nguoi_Dung.Hide();
        }















       
    }
}
