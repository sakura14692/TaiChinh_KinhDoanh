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
    /// Interaction logic for UserControl_Thong_tin_nguoi_dung.xaml
    /// </summary>
    public partial class UserControl_Thong_tin_nguoi_dung : UserControl
    {
        public UserControl_Thong_tin_nguoi_dung()
        {
            InitializeComponent();


            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

            if (ket_noi_den_tat_bat_che_do_bao_mat_voi_CheckBox().Rows[0]["hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung"].ToString() == "on")
                grid_Dang_nhap.Visibility = Visibility.Visible;
            if (ket_noi_den_tat_bat_che_do_bao_mat_voi_CheckBox().Rows[0]["hoi_mat_khau_Admin_khi_xem_thong_tin_nguoi_dung"].ToString() == "off")
                grid_Dang_nhap.Visibility = Visibility.Collapsed;

        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            button_thong_tin_nguoi_dung_Luu.Background = Brushes.DarkSlateGray;
            button_thong_tin_nguoi_dung_Huy.Background = Brushes.DarkSlateGray;
            button_thong_tin_nguoi_dung_Luu.IsEnabled = false;
            button_thong_tin_nguoi_dung_Huy.IsEnabled = false;
            button_thong_tin_nguoi_dung_Luu.Opacity = 0.5;
            button_thong_tin_nguoi_dung_Huy.Opacity = 0.5;










            thong_tin_nguoi_dung();
        }





        messageBox_Thuan_Tuy_Thong_Bao messageBox_nhac_nho_hoac_canh_bao = new messageBox_Thuan_Tuy_Thong_Bao();

        string chuoiketnoi;
        string flag = "";


        public DataTable thong_tin_nguoi_dung()
        {


            DataTable data = new DataTable();
            try
            {
                string truyvan = "select * from dang_nhap";
                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();


                }
                listview_thong_tin_nguoi_dung.ItemsSource = data.DefaultView;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
            return data;
        }




        public DataTable Them_thong_tin_nguoi_dung()
        {
          

            DataTable data = new DataTable();
            try
            {
                string truyvan = "insert dang_nhap(ten_dang_nhap,mat_khau,xac_nhan_mat_khau,ho_ten,so_dien_thoai,email) values ('" + textbox_ten_dang_nhap.Text + "','" + textbox_mat_khau.Text + "','" + textbox_mat_khau.Text + "',N'" + textbox_ho_ten.Text + "','" + textbox_so_dien_thoai.Text + "','" + textbox_email.Text + "') ";

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



        public DataTable Sua_thong_tin_nguoi_dung()
        {


            DataTable data = new DataTable();

            try
            {
                string truyvan = "update dang_nhap set ten_dang_nhap = '" + textbox_ten_dang_nhap.Text + "'," +
               "mat_khau = '" + textbox_mat_khau.Text + "'," +
               "ho_ten = N'" + textbox_ho_ten.Text + "'," +
               "so_dien_thoai = '" + textbox_so_dien_thoai.Text + "'," +
               "email = '" + textbox_email.Text + "' where id = " + int.Parse(textbox_id.Text) + " ";

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




        public DataTable Xoa_thong_tin_nguoi_dung()
        {


            DataTable data = new DataTable();

            try
            {
                string truyvan = "delete dang_nhap where ten_dang_nhap = '" + textbox_ten_dang_nhap.Text + "'";

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



        public DataTable timkiem_thong_tin_nguoi_dung()
        {


            DataTable data = new DataTable();


            try
            {
                string truyvan = "select *from  dang_nhap  where ten_dang_nhap like '%" + textbox_tim_kiem.Text + "%' or ho_ten like N'%" + textbox_tim_kiem.Text + "%' ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_thong_tin_nguoi_dung.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;


        }









        public void mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_nguoi_dung()
        {

            textbox_ten_dang_nhap.IsReadOnly = false;
            textbox_mat_khau.IsReadOnly = false;
            textbox_ho_ten.IsReadOnly = false;
            textbox_so_dien_thoai.IsReadOnly = false;
            textbox_email.IsReadOnly = false;

            button_thong_tin_nguoi_dung_Luu.Background = Brushes.Transparent;
            button_thong_tin_nguoi_dung_Huy.Background = Brushes.Transparent;

            button_thong_tin_nguoi_dung_Luu.IsEnabled = true;
            button_thong_tin_nguoi_dung_Huy.IsEnabled = true;

            button_thong_tin_nguoi_dung_Luu.Opacity = 1;
            button_thong_tin_nguoi_dung_Huy.Opacity = 1;

            button_thong_tin_nguoi_dung_Them.Background = Brushes.DarkSlateGray;
            button_thong_tin_nguoi_dung_Sua.Background = Brushes.DarkSlateGray;
            button_thong_tin_nguoi_dung_Xoa.Background = Brushes.DarkSlateGray;

            button_thong_tin_nguoi_dung_Them.IsEnabled = false;
            button_thong_tin_nguoi_dung_Sua.IsEnabled = false;
            button_thong_tin_nguoi_dung_Xoa.IsEnabled = false;

            button_thong_tin_nguoi_dung_Them.Opacity = 0.5;
            button_thong_tin_nguoi_dung_Sua.Opacity = 0.5;
            button_thong_tin_nguoi_dung_Xoa.Opacity = 0.5;

        }





        public void dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_nguoi_dung()
        {


            textbox_ten_dang_nhap.IsReadOnly = true;
            textbox_mat_khau.IsReadOnly = true;
            textbox_ho_ten.IsReadOnly = true;
            textbox_so_dien_thoai.IsReadOnly = true;
            textbox_email.IsReadOnly = true;
            

            button_thong_tin_nguoi_dung_Luu.Background = Brushes.DarkSlateGray;
            button_thong_tin_nguoi_dung_Huy.Background = Brushes.DarkSlateGray;

            button_thong_tin_nguoi_dung_Luu.IsEnabled = false;
            button_thong_tin_nguoi_dung_Huy.IsEnabled = false;

            button_thong_tin_nguoi_dung_Luu.Opacity = 0.5;
            button_thong_tin_nguoi_dung_Huy.Opacity = 0.5;

            button_thong_tin_nguoi_dung_Them.Background = Brushes.Transparent;
            button_thong_tin_nguoi_dung_Sua.Background = Brushes.Transparent;
            button_thong_tin_nguoi_dung_Xoa.Background = Brushes.Transparent;

            button_thong_tin_nguoi_dung_Them.IsEnabled = true;
            button_thong_tin_nguoi_dung_Sua.IsEnabled = true;
            button_thong_tin_nguoi_dung_Xoa.IsEnabled = true;

            button_thong_tin_nguoi_dung_Them.Opacity = 1;
            button_thong_tin_nguoi_dung_Sua.Opacity = 1;
            button_thong_tin_nguoi_dung_Xoa.Opacity = 1;


        }




        public bool textIsnotNull_thong_tin_nguoi_dung()
        {

            if (string.IsNullOrEmpty(textbox_ten_dang_nhap.Text))
            {
                MessageBox.Show("'Tên đăng nhập' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_ten_dang_nhap.Focus();

                return false;
            }
            else
          
            if (string.IsNullOrEmpty(textbox_mat_khau.Text))
            {

                MessageBox.Show("'Mật khẩu' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_mat_khau.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_ho_ten.Text))
            {

                MessageBox.Show("'Họ tên' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_ho_ten.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_so_dien_thoai.Text))
            {
                MessageBox.Show("'Số điện thoại' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_so_dien_thoai.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_email.Text))
            {

                MessageBox.Show("'Email' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_email.Focus();

                return false;
            }

          

            return true;
        }



        public void thong_tin_nguoi_dung_Lam_trang_text_box() 
        {

            textbox_ten_dang_nhap.Text = null;
            textbox_mat_khau.Text = null;
            textbox_ho_ten.Text = null;
            textbox_so_dien_thoai.Text = null;
            textbox_email.Text = null;
            textbox_id.Text = null;
        
        
        
        }




        public void binding_to_textbox_thong_tin_nguoi_dung()
        {

            Binding ten_dang_nhap = new Binding();
            ten_dang_nhap.Mode = BindingMode.OneWay;
            Binding mat_khau = new Binding();
            mat_khau.Mode = BindingMode.OneWay;
            Binding ho_ten = new Binding();
            ho_ten.Mode = BindingMode.OneWay;
            Binding so_dien_thoai = new Binding();
            so_dien_thoai.Mode = BindingMode.OneWay;
            Binding email = new Binding();
            email.Mode = BindingMode.OneWay;
            Binding id = new Binding();
            id.Mode = BindingMode.OneWay;

            // The source
            ten_dang_nhap.Path = new PropertyPath("SelectedValue.[ ten_dang_nhap]");
            ten_dang_nhap.ElementName = "listview_thong_tin_nguoi_dung";
            mat_khau.Path = new PropertyPath("SelectedValue.[mat_khau]");
            mat_khau.ElementName = "listview_thong_tin_nguoi_dung";
            ho_ten.Path = new PropertyPath("SelectedValue.[ho_ten]");
            ho_ten.ElementName = "listview_thong_tin_nguoi_dung";
            so_dien_thoai.Path = new PropertyPath("SelectedValue.[ so_dien_thoai]");
            so_dien_thoai.ElementName = "listview_thong_tin_nguoi_dung";
            email.Path = new PropertyPath("SelectedValue.[email]");
            email.ElementName = "listview_thong_tin_nguoi_dung";
            id.Path = new PropertyPath("SelectedValue.[id]");
            id.ElementName = "listview_thong_tin_nguoi_dung";

            // The target
            textbox_ten_dang_nhap.SetBinding(TextBox.TextProperty, ten_dang_nhap);
            textbox_mat_khau.SetBinding(TextBox.TextProperty, mat_khau);
            textbox_ho_ten.SetBinding(TextBox.TextProperty, ho_ten);
            textbox_so_dien_thoai.SetBinding(TextBox.TextProperty, so_dien_thoai);
            textbox_email.SetBinding(TextBox.TextProperty, email);
            textbox_id.SetBinding(TextBox.TextProperty, id);



        }






        private void button_thong_tin_nguoi_dung_Them_Click(object sender, RoutedEventArgs e)
        {
            mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_nguoi_dung();

            thong_tin_nguoi_dung_Lam_trang_text_box();

            button_thong_tin_nguoi_dung_Them.BorderBrush = Brushes.DarkGoldenrod;
            button_thong_tin_nguoi_dung_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Huy.BorderBrush = Brushes.LightSkyBlue;


            flag = "Thêm";
        }

        private void button_thong_tin_nguoi_dung_Sua_Click(object sender, RoutedEventArgs e)
        {
            button_thong_tin_nguoi_dung_Them.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Sua.BorderBrush = Brushes.DarkGoldenrod;
            button_thong_tin_nguoi_dung_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Huy.BorderBrush = Brushes.LightSkyBlue;

            flag = "Sửa";
        }

        private void button_thong_tin_nguoi_dung_Xoa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_id.Text))
                MessageBox.Show("Hãy chọn đối tượng để xóa !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {

                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {



                    Xoa_thong_tin_nguoi_dung();
                    thong_tin_nguoi_dung();

                    button_thong_tin_nguoi_dung_Them.BorderBrush = Brushes.LightSkyBlue;
                    button_thong_tin_nguoi_dung_Sua.BorderBrush = Brushes.LightSkyBlue;
                    button_thong_tin_nguoi_dung_Xoa.BorderBrush = Brushes.DarkGoldenrod;
                    button_thong_tin_nguoi_dung_Luu.BorderBrush = Brushes.LightSkyBlue;
                    button_thong_tin_nguoi_dung_Huy.BorderBrush = Brushes.LightSkyBlue;
                }

            }


       
        }








        private void button_thong_tin_nguoi_dung_Luu_Click(object sender, RoutedEventArgs e)
        {

            if (textIsnotNull_thong_tin_nguoi_dung())
            {

                if (flag == "Thêm")
                {

                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_nguoi_dung();
                    Them_thong_tin_nguoi_dung();
                }




                if (flag == "Sửa")
                {

                    Sua_thong_tin_nguoi_dung();
                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_nguoi_dung();
                }

                thong_tin_nguoi_dung();



                button_thong_tin_nguoi_dung_Them.BorderBrush = Brushes.LightSkyBlue;
                button_thong_tin_nguoi_dung_Sua.BorderBrush = Brushes.LightSkyBlue;
                button_thong_tin_nguoi_dung_Xoa.BorderBrush = Brushes.LightSkyBlue;
                button_thong_tin_nguoi_dung_Luu.BorderBrush = Brushes.DarkGoldenrod;
                button_thong_tin_nguoi_dung_Huy.BorderBrush = Brushes.LightSkyBlue;

                binding_to_textbox_thong_tin_nguoi_dung();
            }

        }

        private void button_thong_tin_nguoi_dung_Huy_Click(object sender, RoutedEventArgs e)
        {
            dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_nguoi_dung();


            binding_to_textbox_thong_tin_nguoi_dung();


            button_thong_tin_nguoi_dung_Them.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_nguoi_dung_Huy.BorderBrush = Brushes.DarkGoldenrod;

            flag = "Hủy";


        }


















        //****Khu vực chức năng đặc biệt**************************************************


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

       

        private void button_Dang_nhap_Click(object sender, RoutedEventArgs e)
        {
            if(text_Box_isNotNull()) dang_nhap();

        }



        private void listview_thong_tin_nguoi_dung_MouseEnter(object sender, MouseEventArgs e)
        {
            listview_thong_tin_nguoi_dung.Foreground = Brushes.DarkBlue;
        }


        private void listview_thong_tin_nguoi_dung_MouseLeave(object sender, MouseEventArgs e)
        {
            listview_thong_tin_nguoi_dung.Foreground = Brushes.DarkGoldenrod;
        }

        private void listview_thong_tin_nguoi_dung_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == "Sửa") mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_nguoi_dung();
        }

        private void textbox_tim_kiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timkiem_thong_tin_nguoi_dung();
        }
    }
}
