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

namespace TaiChinh_KinhDoanh.Views.PhuTro
{
    /// <summary>
    /// Interaction logic for form_Thu_Vao.xaml
    /// </summary>
    public partial class form_Thu_Vao : Window
    {
        public form_Thu_Vao()
        {
            InitializeComponent();

            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

            khoan_thu();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            button_thu_vao_Luu.Background = Brushes.DarkSlateGray;
            button_thu_vao_Huy.Background = Brushes.DarkSlateGray;
            button_thu_vao_Luu.IsEnabled = false;
            button_thu_vao_Huy.IsEnabled = false;
            button_thu_vao_Luu.Opacity = 0.5;
            button_thu_vao_Huy.Opacity = 0.5;

        }






        string chuoiketnoi;
        string flag = "";


        public DataTable khoan_thu()
        {


            DataTable data = new DataTable();
            try
            {
                string truyvan = "select * from thu_vao";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Thu_Vao.ItemsSource = data.DefaultView;


                }



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

            return data;
        }






        public DataTable Them_khoan_thu()
        {


            DataTable data = new DataTable();
            try
            {
                string truyvan = "  exec them_khoan_thu @ma_so_khoan_thu = '',@ten_khoan_thu = N'"+textbox_ten_khoan_thu.Text+"',@so_tien = "+long.Parse(textbox_So_tien.Text)+" ,@nguon_goc = N'"+textbox_nguon_goc.Text+"',@ngay_thu_vao = N'"+textbox_Ngay_thu_vao.Text+"'  ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Thu_Vao.ItemsSource = data.DefaultView;


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return data;

        }



        public DataTable Sua_khoan_thu()
        {


            DataTable data = new DataTable();
            try
            {
                string truyvan = " update thu_vao set ten_khoan_thu = N'" + textbox_ten_khoan_thu.Text + "',so_tien = " + long.Parse(textbox_So_tien.Text) + ",nguon_goc = N'" + textbox_nguon_goc.Text + "',ngay_thu_vao = N'" + textbox_Ngay_thu_vao.Text + "' where ma_so_khoan_thu = '"+textbox_ma_so_khoan_thu.Text+"' ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Thu_Vao.ItemsSource = data.DefaultView;


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            

            return data;

        }



        public DataTable Xoa_khoan_thu()
        {


            DataTable data = new DataTable();

            try
            {
                string truyvan = " delete thu_vao where ma_so_khoan_thu = '" + textbox_ma_so_khoan_thu.Text + "' ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Thu_Vao.ItemsSource = data.DefaultView;


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

            return data;

        }


        public DataTable timkiem_khoan_thu()
        {


            DataTable data = new DataTable();


            try
            {
                string truyvan = "select *from  thu_vao  where ma_so_khoan_thu like '%" + textbox_tim_kiem.Text + "%' or ten_khoan_thu like N'%" + textbox_tim_kiem.Text + "%' or  ngay_thu_vao like N'%" + textbox_tim_kiem.Text + "%'  ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Thu_Vao.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;


        }







        public void mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Thu_vao()
        {

            textbox_ten_khoan_thu.IsReadOnly = false;
            textbox_So_tien.IsReadOnly = false;
            textbox_nguon_goc.IsReadOnly = false;
            textbox_Ngay_thu_vao.IsReadOnly = false;

            button_thu_vao_Luu.Background = Brushes.Transparent;
            button_thu_vao_Huy.Background = Brushes.Transparent;

            button_thu_vao_Luu.IsEnabled = true;
            button_thu_vao_Huy.IsEnabled = true;

            button_thu_vao_Luu.Opacity = 1;
            button_thu_vao_Huy.Opacity = 1;

            button_thu_vao_Them.Background = Brushes.DarkSlateGray;
            button_thu_vao_Sua.Background = Brushes.DarkSlateGray;
            button_thu_vao_Xoa.Background = Brushes.DarkSlateGray;

            button_thu_vao_Them.IsEnabled = false;
            button_thu_vao_Sua.IsEnabled = false;
            button_thu_vao_Xoa.IsEnabled = false;

            button_thu_vao_Them.Opacity = 0.5;
            button_thu_vao_Sua.Opacity = 0.5;
            button_thu_vao_Xoa.Opacity = 0.5;

        }



        public void dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Thu_vao()
        {



            textbox_ten_khoan_thu.IsReadOnly = true;
            textbox_So_tien.IsReadOnly = true;
            textbox_nguon_goc.IsReadOnly = true;
            textbox_Ngay_thu_vao.IsReadOnly = true;

            button_thu_vao_Luu.Background = Brushes.DarkSlateGray;
            button_thu_vao_Huy.Background = Brushes.DarkSlateGray;

            button_thu_vao_Luu.IsEnabled = false;
            button_thu_vao_Huy.IsEnabled = false;

            button_thu_vao_Luu.Opacity = 0.5;
            button_thu_vao_Huy.Opacity = 0.5;

            button_thu_vao_Them.Background = Brushes.Transparent;
            button_thu_vao_Sua.Background = Brushes.Transparent;
            button_thu_vao_Xoa.Background = Brushes.Transparent;

            button_thu_vao_Them.IsEnabled = true;
            button_thu_vao_Sua.IsEnabled = true;
            button_thu_vao_Xoa.IsEnabled = true;

            button_thu_vao_Them.Opacity = 1;
            button_thu_vao_Sua.Opacity = 1;
            button_thu_vao_Xoa.Opacity = 1;


        }




        public bool textIsnotNull_Thu_Vao()
        {

            if (string.IsNullOrEmpty(textbox_ten_khoan_thu.Text))
            {
                MessageBox.Show("'Tên khoản thu' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_ten_khoan_thu.Focus();

                return false;
            }
            else

            if (string.IsNullOrEmpty(textbox_So_tien.Text))
            {

                MessageBox.Show("'Số tiền' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_So_tien.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_nguon_goc.Text))
            {

                MessageBox.Show("'Nguồn gốc' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_nguon_goc.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_Ngay_thu_vao.Text))
            {

                MessageBox.Show("'Ngày thu vào' không được để trống", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_Ngay_thu_vao.Focus();
                return false;
            }




            return true;
        }





        public void Thu_vao_Lam_trang_text_box()
        {

            textbox_ma_so_khoan_thu.Text = null;
            textbox_ten_khoan_thu.Text = null;
            textbox_So_tien.Text = null;
            textbox_nguon_goc.Text = null;
            textbox_Ngay_thu_vao.Text = null;


        }






        public void binding_to_textbox_Thu_vao()
        {

            Binding ma_so_khoan_thu = new Binding();
            ma_so_khoan_thu.Mode = BindingMode.OneWay;
            Binding ten_khoan_thu = new Binding();
            ten_khoan_thu.Mode = BindingMode.OneWay;
            Binding so_tien = new Binding();
            so_tien.Mode = BindingMode.OneWay;
            Binding nguon_goc = new Binding();
            nguon_goc.Mode = BindingMode.OneWay;
            Binding ngay_thu_vao = new Binding();
            ngay_thu_vao.Mode = BindingMode.OneWay;


            // The source
            ma_so_khoan_thu.Path = new PropertyPath("SelectedValue.[  ma_so_khoan_thu]");
            ma_so_khoan_thu.ElementName = "listview_Thu_Vao";
            ten_khoan_thu.Path = new PropertyPath("SelectedValue.[ten_khoan_thu]");
            ten_khoan_thu.ElementName = "listview_Thu_Vao";
            so_tien.Path = new PropertyPath("SelectedValue.[so_tien]");
            so_tien.ElementName = "listview_Thu_Vao";
            nguon_goc.Path = new PropertyPath("SelectedValue.[ nguon_goc]");
            nguon_goc.ElementName = "listview_Thu_Vao";
            ngay_thu_vao.Path = new PropertyPath("SelectedValue.[ ngay_thu_vao]");
            ngay_thu_vao.ElementName = "listview_Thu_Vao";

            // The target
            textbox_ma_so_khoan_thu.SetBinding(TextBox.TextProperty, ma_so_khoan_thu);
            textbox_ten_khoan_thu.SetBinding(TextBox.TextProperty, ten_khoan_thu);
            textbox_So_tien.SetBinding(TextBox.TextProperty, so_tien);
            textbox_nguon_goc.SetBinding(TextBox.TextProperty, nguon_goc);
            textbox_Ngay_thu_vao.SetBinding(TextBox.TextProperty, ngay_thu_vao);




        }





        private void button_thu_vao_Them_Click(object sender, RoutedEventArgs e)
        {
            mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Thu_vao();
            Thu_vao_Lam_trang_text_box();

            button_thu_vao_Them.BorderBrush = Brushes.DarkGoldenrod;
            button_thu_vao_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Huy.BorderBrush = Brushes.LightSkyBlue;

            flag = "Thêm";
        }

        private void button_thu_vao_Sua_Click(object sender, RoutedEventArgs e)
        {
            flag = "Sửa";

            button_thu_vao_Them.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Sua.BorderBrush = Brushes.DarkGoldenrod;
            button_thu_vao_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Huy.BorderBrush = Brushes.LightSkyBlue;
        }

        private void button_thu_vao_Xoa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_ma_so_khoan_thu.Text))
                MessageBox.Show("Hãy chọn đối tượng để xóa !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            else 
            {

                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {



                    Xoa_khoan_thu();
                    khoan_thu();

                    button_thu_vao_Them.BorderBrush = Brushes.LightSkyBlue;
                    button_thu_vao_Sua.BorderBrush = Brushes.LightSkyBlue;
                    button_thu_vao_Xoa.BorderBrush = Brushes.DarkGoldenrod;
                    button_thu_vao_Luu.BorderBrush = Brushes.LightSkyBlue;
                    button_thu_vao_Huy.BorderBrush = Brushes.LightSkyBlue;
                }
            }
           
           

          
        }







        private void button_thu_vao_Luu_Click(object sender, RoutedEventArgs e)
        {
            if (textIsnotNull_Thu_Vao())
            {

                if (flag == "Thêm")
                {

                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Thu_vao();
                    Them_khoan_thu();
                }




                if (flag == "Sửa")
                {

                    Sua_khoan_thu();
                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Thu_vao();
                }

                khoan_thu();


            }

            button_thu_vao_Them.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Luu.BorderBrush = Brushes.DarkGoldenrod;
            button_thu_vao_Huy.BorderBrush = Brushes.LightSkyBlue;

            binding_to_textbox_Thu_vao();
        }

        private void button_thu_vao_Huy_Click(object sender, RoutedEventArgs e)
        {

            dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Thu_vao();


            binding_to_textbox_Thu_vao();


            flag = "Hủy";
            button_thu_vao_Them.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thu_vao_Huy.BorderBrush = Brushes.DarkGoldenrod;
        }














        //**Khu vực chức năng đặc biệt**************************

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void listview_Thu_Vao_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == "Sửa")
            {
                binding_to_textbox_Thu_vao();
                mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Thu_vao();

            }
        }

        private void listview_Thu_Vao_MouseEnter(object sender, MouseEventArgs e)
        {
            listview_Thu_Vao.Foreground = Brushes.DarkBlue;
        }

        private void listview_Thu_Vao_MouseLeave(object sender, MouseEventArgs e)
        {
            listview_Thu_Vao.Foreground = Brushes.DarkGoldenrod;
        }

        private void textbox_tim_kiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timkiem_khoan_thu();
        }

        private void gui_Bao_cao_du_khoan_thu_Click(object sender, RoutedEventArgs e)
        {

            string ma_so_khoan_thu = string.Format("[ {0} ] [ Mã số khoản thu ]  :  ", textblock_thu_vao.Text) + textbox_ma_so_khoan_thu.Text;
            string ten_khoan_thu = string.Format("[ {0} ] [ Tên khoản thu ]  :  ", textblock_thu_vao.Text) + textbox_ten_khoan_thu.Text;
            string so_tien = string.Format("[ {0} ] [ Số tiền ]  :  ", textblock_thu_vao.Text) + textbox_So_tien.Text;
            string nguon_goc = string.Format("[ {0} ] [ Nguồn gốc ]  :  ", textblock_thu_vao.Text) + textbox_nguon_goc.Text;
            string ngay_thu_vao = string.Format("[ {0} ] [ Ngày thu vào ]  :  ", textblock_thu_vao.Text) + textbox_Ngay_thu_vao.Text;
            string tieuDe = textblock_thu_vao.Text;





            form_Gui_bao_cao_Bang_email gui_Bao_Cao_Bang_Email = new form_Gui_bao_cao_Bang_email();
            gui_Bao_Cao_Bang_Email.Show();
            gui_Bao_Cao_Bang_Email.hien_thi_thong_tin_can_gui(ma_so_khoan_thu, ten_khoan_thu, so_tien,nguon_goc,ngay_thu_vao,null,null,null,null,null,null,tieuDe);
        }

        private void button_Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void textbox_So_tien_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                UInt64 so_tien = UInt64.Parse(textbox_So_tien.Text);
                string formatted_so_tien = string.Format(CultureInfo.InvariantCulture, "{0:N0}", so_tien);
                textbox_So_tien.ToolTip = formatted_so_tien;


            }
            catch (Exception)
            {


            }
        }
    }
}
