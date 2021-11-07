using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using System.Windows.Threading;

namespace TaiChinh_KinhDoanh.Views.PhuTro
{
    /// <summary>
    /// Interaction logic for form_Chi_Ra.xaml
    /// </summary>
    public partial class form_Chi_Ra : Window
    {
        public form_Chi_Ra()
        {
            InitializeComponent();

            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

            khoan_chi();
        }





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            button_chi_ra_Luu.Background = Brushes.DarkSlateGray;
            button_chi_ra_Huy.Background = Brushes.DarkSlateGray;
            button_chi_ra_Luu.IsEnabled = false;
            button_chi_ra_Huy.IsEnabled = false;
            button_chi_ra_Luu.Opacity = 0.5;
            button_chi_ra_Huy.Opacity = 0.5;




        }





        string chuoiketnoi;
        string flag = "";
     

        public DataTable khoan_chi()
        {


            DataTable data = new DataTable();

            try
            {

                string truyvan = "select * from chi_ra";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Chi_Ra.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

            return data;
        }


        public DataTable Them_khoan_chi() 
        {


            DataTable data = new DataTable();

            try
            {
                string truyvan = " exec them_khoan_chi @ma_so_khoan_chi = '',@ten_khoan_chi = N'" + textbox_ten_khoan_chi.Text + "',@so_tien = " + long.Parse(textbox_so_tien.Text) + ",@muc_dich = N'" + textbox_muc_dich.Text + "' ,@ngay_chi_ra = N'"+textbox_Ngay_chi_ra.Text+"' ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Chi_Ra.ItemsSource = data.DefaultView;


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            

            return data;

        }



        public DataTable Sua_khoan_chi()
        {


            DataTable data = new DataTable();
            try
            {

                string truyvan = " update chi_ra set ten_khoan_chi = N'" + textbox_ten_khoan_chi.Text + "',so_tien = " + long.Parse(textbox_so_tien.Text) + ",muc_dich = N'" + textbox_muc_dich.Text + "' ,ngay_chi_ra = N'"+textbox_Ngay_chi_ra.Text+"' where ma_so_khoan_chi = '"+textbox_ma_so_khoan_chi.Text+"' ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Chi_Ra.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           

            return data;

        }



        public DataTable Xoa_khoan_chi()
        {


            DataTable data = new DataTable();

            try
            {

                string truyvan = " delete chi_ra where ma_so_khoan_chi = '" + textbox_ma_so_khoan_chi.Text + "' ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Chi_Ra.ItemsSource = data.DefaultView;


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
            return data;

        }




        public DataTable timkiem_khoan_chi()
        {


            DataTable data = new DataTable();


            try
            {
                string truyvan = "select *from  chi_ra  where ma_so_khoan_chi like '%" + textbox_tim_kiem.Text + "%' or ten_khoan_chi like N'%" + textbox_tim_kiem.Text + "%' or  ngay_chi_ra like N'%" + textbox_tim_kiem.Text + "%'  ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Chi_Ra.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;


        }




        public void mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Chi_ra()
        {

            textbox_ten_khoan_chi.IsReadOnly = false;
            textbox_so_tien.IsReadOnly = false;
            textbox_muc_dich.IsReadOnly = false;
            textbox_Ngay_chi_ra.IsReadOnly = false;

            button_chi_ra_Luu.Background = Brushes.Transparent;
            button_chi_ra_Huy.Background = Brushes.Transparent;

            button_chi_ra_Luu.IsEnabled = true;
            button_chi_ra_Huy.IsEnabled = true;

            button_chi_ra_Luu.Opacity = 1;
            button_chi_ra_Huy.Opacity = 1;

            button_chi_ra_Them.Background = Brushes.DarkSlateGray;
            button_chi_ra_Sua.Background = Brushes.DarkSlateGray;
            button_chi_ra_Xoa.Background = Brushes.DarkSlateGray;

            button_chi_ra_Them.IsEnabled = false;
            button_chi_ra_Sua.IsEnabled = false;
            button_chi_ra_Xoa.IsEnabled = false;

            button_chi_ra_Them.Opacity = 0.5;
            button_chi_ra_Sua.Opacity = 0.5;
            button_chi_ra_Xoa.Opacity = 0.5;

        }



        public void dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_chi_ra()
        {


            textbox_ten_khoan_chi.IsReadOnly = true;
            textbox_so_tien.IsReadOnly = true;
            textbox_muc_dich.IsReadOnly = true;
            textbox_Ngay_chi_ra.IsReadOnly = true;

            button_chi_ra_Luu.Background = Brushes.DarkSlateGray;
            button_chi_ra_Huy.Background = Brushes.DarkSlateGray;

            button_chi_ra_Luu.IsEnabled = false;
            button_chi_ra_Huy.IsEnabled = false;

            button_chi_ra_Luu.Opacity = 0.5;
            button_chi_ra_Huy.Opacity = 0.5;

            button_chi_ra_Them.Background = Brushes.Transparent;
            button_chi_ra_Sua.Background = Brushes.Transparent;
            button_chi_ra_Xoa.Background = Brushes.Transparent;

            button_chi_ra_Them.IsEnabled = true;
            button_chi_ra_Sua.IsEnabled = true;
            button_chi_ra_Xoa.IsEnabled = true;

            button_chi_ra_Them.Opacity = 1;
            button_chi_ra_Sua.Opacity = 1;
            button_chi_ra_Xoa.Opacity = 1;


        }




        public bool textIsnotNull_chi_ra()
        {

            if (string.IsNullOrEmpty(textbox_ten_khoan_chi.Text))
            {
                MessageBox.Show("'Tên khoản chi' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_ten_khoan_chi.Focus();

                return false;
            }
            else

            if (string.IsNullOrEmpty(textbox_so_tien.Text))
            {

                MessageBox.Show("'Số tiền' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_so_tien.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_muc_dich.Text))
            {

                MessageBox.Show("'Mục đích' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_muc_dich.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_Ngay_chi_ra.Text))
            {

                MessageBox.Show("'Ngày chi ra' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_muc_dich.Focus();
                return false;
            }




            return true;
        }





        public void Chi_ra_Lam_trang_text_box()
        {

            textbox_ma_so_khoan_chi.Text = null;
            textbox_ten_khoan_chi.Text = null;
            textbox_so_tien.Text = null;
            textbox_muc_dich.Text = null;
            textbox_Ngay_chi_ra.Text = null;


        }






        public void binding_to_textbox_Chi_ra()
        {

            Binding ma_so_khoan_chi = new Binding();
            ma_so_khoan_chi.Mode = BindingMode.OneWay;
            Binding ten_khoan_chi = new Binding();
            ten_khoan_chi.Mode = BindingMode.OneWay;
            Binding so_tien = new Binding();
            so_tien.Mode = BindingMode.OneWay;
            Binding muc_dich = new Binding();
            muc_dich.Mode = BindingMode.OneWay;
            Binding ngay_chi_ra = new Binding();
            ngay_chi_ra.Mode = BindingMode.OneWay;

            // The source
            ma_so_khoan_chi.Path = new PropertyPath("SelectedValue.[  ma_so_khoan_chi]");
            ma_so_khoan_chi.ElementName = "listview_Chi_Ra";
            ten_khoan_chi.Path = new PropertyPath("SelectedValue.[ten_khoan_chi]");
            ten_khoan_chi.ElementName = "listview_Chi_Ra";
            so_tien.Path = new PropertyPath("SelectedValue.[so_tien]");
            so_tien.ElementName = "listview_Chi_Ra";
            muc_dich.Path = new PropertyPath("SelectedValue.[ muc_dich]");
            muc_dich.ElementName = "listview_Chi_Ra";
            ngay_chi_ra.Path = new PropertyPath("SelectedValue.[  ngay_chi_ra]");
            ngay_chi_ra.ElementName = "listview_Chi_Ra";



            // The target
            textbox_ma_so_khoan_chi.SetBinding(TextBox.TextProperty, ma_so_khoan_chi);
            textbox_ten_khoan_chi.SetBinding(TextBox.TextProperty, ten_khoan_chi);
            textbox_so_tien.SetBinding(TextBox.TextProperty, so_tien);
            textbox_muc_dich.SetBinding(TextBox.TextProperty, muc_dich);
            textbox_Ngay_chi_ra.SetBinding(TextBox.TextProperty, ngay_chi_ra);




        }




        private void button_chi_ra_Them_Click(object sender, RoutedEventArgs e)
        {
            mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Chi_ra();
            Chi_ra_Lam_trang_text_box();

            button_chi_ra_Them.BorderBrush = Brushes.DarkGoldenrod;
            button_chi_ra_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Huy.BorderBrush = Brushes.LightSkyBlue;

            flag = "Thêm";



            
        }

        



        private void button_chi_ra_Sua_Click(object sender, RoutedEventArgs e)
        {

            flag = "Sửa";

            button_chi_ra_Them.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Sua.BorderBrush = Brushes.DarkGoldenrod;
            button_chi_ra_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Huy.BorderBrush = Brushes.LightSkyBlue;
        }

        private void button_chi_ra_Xoa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_ma_so_khoan_chi.Text))
                MessageBox.Show("Hãy chọn đối tượng để xóa !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            else 
            {


                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {



                    Xoa_khoan_chi();
                    khoan_chi();

                    button_chi_ra_Them.BorderBrush = Brushes.LightSkyBlue;
                    button_chi_ra_Sua.BorderBrush = Brushes.LightSkyBlue;
                    button_chi_ra_Xoa.BorderBrush = Brushes.DarkGoldenrod;
                    button_chi_ra_Luu.BorderBrush = Brushes.LightSkyBlue;
                    button_chi_ra_Huy.BorderBrush = Brushes.LightSkyBlue;
                }

            }

           

        }







        private void button_chi_ra_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (textIsnotNull_chi_ra())
            {

                if (flag == "Thêm")
                {

                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_chi_ra();
                    Them_khoan_chi();
                }




                if (flag == "Sửa")
                {

                    Sua_khoan_chi();
                  dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_chi_ra();
                }

                khoan_chi();


            }

            button_chi_ra_Them.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Luu.BorderBrush = Brushes.DarkGoldenrod;
            button_chi_ra_Huy.BorderBrush = Brushes.LightSkyBlue;
            binding_to_textbox_Chi_ra();
        }

        private void button_chi_ra_Huy_Click(object sender, RoutedEventArgs e)
        {
            dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_chi_ra();


            binding_to_textbox_Chi_ra();

            button_chi_ra_Them.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_chi_ra_Huy.BorderBrush = Brushes.DarkGoldenrod;

            flag = "Hủy";
        }















        //*****Khu vực chức năng đặc biệt ************************************************************



        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void listview_Chi_Ra_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == "Sửa") 
            {
                binding_to_textbox_Chi_ra();
                mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Chi_ra();

            }
            

        }

        private void listview_Chi_Ra_MouseEnter(object sender, MouseEventArgs e)
        {
            listview_Chi_Ra.Foreground = Brushes.DarkBlue;
        }

        private void listview_Chi_Ra_MouseLeave(object sender, MouseEventArgs e)
        {
            listview_Chi_Ra.Foreground = Brushes.DarkGoldenrod;
        }

        private void textbox_tim_kiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timkiem_khoan_chi();
        }

        private void gui_Bao_cao_khoan_chi_Click(object sender, RoutedEventArgs e)
        {
            string ma_so_khoan_chi = string.Format("[ {0} ] [ Mã số khoản chi ]  :  ", textblock_chi_ra.Text) + textbox_ma_so_khoan_chi.Text;
            string ten_khoan_chi = string.Format("[ {0} ] [ Tên khoản chi ]  :  ", textblock_chi_ra.Text) + textbox_ten_khoan_chi.Text;
            string so_tien = string.Format("[ {0} ] [ Số tiền ]  :  ", textblock_chi_ra.Text) + textbox_so_tien.Text;
            string muc_dich = string.Format("[ {0} ] [ Mục đích ]  :  ", textblock_chi_ra.Text) +textbox_muc_dich.Text;
            string ngay_chi_ra = string.Format("[ {0} ] [ Ngày chi ra ]  :  ", textblock_chi_ra.Text) +textbox_Ngay_chi_ra.Text;
            string tieuDe = textblock_chi_ra.Text;





            form_Gui_bao_cao_Bang_email gui_Bao_Cao_Bang_Email = new form_Gui_bao_cao_Bang_email();
            gui_Bao_Cao_Bang_Email.Show();
            gui_Bao_Cao_Bang_Email.hien_thi_thong_tin_can_gui(ma_so_khoan_chi, ten_khoan_chi, so_tien, muc_dich,ngay_chi_ra,null,null,null,null,null,null,tieuDe);
        }

        private void button_Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState= WindowState.Minimized;
        }

        private void textbox_so_tien_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                UInt64 so_tien = UInt64.Parse(textbox_so_tien.Text);
                string formatted_so_tien = string.Format(CultureInfo.InvariantCulture, "{0:N0}", so_tien);
                textbox_so_tien.ToolTip = formatted_so_tien;


            }
            catch (Exception)
            {


            }
        }
    }
}
