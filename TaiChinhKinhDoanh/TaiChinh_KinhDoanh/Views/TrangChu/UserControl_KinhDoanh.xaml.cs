

using Limilabs.Client.IMAP;
using Limilabs.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TaiChinh_KinhDoanh.Views.PhuTro;



namespace TaiChinh_KinhDoanh.Views.TrangChu
{
    /// <summary>
    /// Interaction logic for UserControl_KinhDoanh.xaml
    /// </summary>
    public partial class UserControl_KinhDoanh : UserControl
    {
        public UserControl_KinhDoanh()
        {
            InitializeComponent();

            var fullpath = Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

            Tong_so_tien_thu_vao();
            Tong_so_tien_chi_ra();
            Tong_loi_nhuan_du_kien_Ke_hoach_du_an_moi();
            Tong_so_von_du_kien_Ke_hoach_du_an_moi();
            Tong_loi_nhuan_du_an_da_trien_khai();
            Tong_so_von_du_an_da_trien_khai();
            textbox_thong_ke_du_an_da_trien_khai_Tong_doanh_thu.Text = (Tong_so_von_du_an_da_trien_khai() + Tong_loi_nhuan_du_an_da_trien_khai()).ToString();
            textbox_quan_ly_quy_dau_tu_So_du_hien_tai.Text = (Tong_so_tien_thu_vao() - Tong_so_tien_chi_ra()).ToString();





        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            button_du_an_da_trien_khai_Luu.Background = Brushes.DarkSlateGray;
            button_du_an_da_trien_khai_Huy.Background = Brushes.DarkSlateGray;
            button_du_an_da_trien_khai_Luu.IsEnabled = false;
            button_du_an_da_trien_khai_Huy.IsEnabled = false;
            button_du_an_da_trien_khai_Luu.Opacity = 0.5;
            button_du_an_da_trien_khai_Huy.Opacity = 0.5;



            button_ke_hoach_cho_du_an_moi_Luu.Background = Brushes.DarkSlateGray;
            button_ke_hoach_cho_du_an_moi_Huy.Background = Brushes.DarkSlateGray;
            button_ke_hoach_cho_du_an_moi_Luu.IsEnabled = false;
            button_ke_hoach_cho_du_an_moi_Huy.IsEnabled = false;
            button_ke_hoach_cho_du_an_moi_Luu.Opacity = 0.5;
            button_ke_hoach_cho_du_an_moi_Huy.Opacity = 0.5;


            button_quan_ly_thong_tin_doi_tac_Luu.Background = Brushes.DarkSlateGray;
            button_thong_tin_doi_tac_Huy.Background = Brushes.DarkSlateGray;
            button_quan_ly_thong_tin_doi_tac_Luu.IsEnabled = false;
            button_thong_tin_doi_tac_Huy.IsEnabled = false;
            button_quan_ly_thong_tin_doi_tac_Luu.Opacity = 0.5;
            button_thong_tin_doi_tac_Huy.Opacity = 0.5;


            button_Giam_sat_du_an_Luu.Background = Brushes.DarkSlateGray;
            button_Giam_sat_du_an_Huy.Background = Brushes.DarkSlateGray;
            button_Giam_sat_du_an_Luu.IsEnabled = false;
            button_Giam_sat_du_an_Huy.IsEnabled = false;
            button_Giam_sat_du_an_Luu.Opacity = 0.5;
            button_Giam_sat_du_an_Huy.Opacity = 0.5;



            thong_tin_doi_dac();
            thong_tin_du_an_da_trien_khai();
            xay_dung_ke_hoach_cho_du_an_moi();
            danh_sach_du_an_can_Giam_sat();
            tong_so_du_an_da_va_dang_cho_duoc_trien_khai();








        }







        string chuoiketnoi;
        string flag = "";














        //******** Khu vực của Thông tin dự án đã triển khai***********************************************



        public DataTable thong_tin_du_an_da_trien_khai()
        {


            DataTable data = new DataTable();
            try
            {
                string truyvan = "select * from thong_tin_du_an_da_trien_khai";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return data;
        }




        public DataTable Them_thong_tin_du_an_da_trien_khai()
        {
           

            DataTable data = new DataTable();

            try
            {

                string truyvan = "exec them_du_an @ma_du_an =''," +
               "@ten_du_an=N'" + textbox_du_an_da_trien_khai_Ten_du_an.Text + "'," +
               "@ngay_khoi_cong = '" + textbox_du_an_da_trien_khai_Ngay_khoi_cong.Text + "'," +
               "@ngay_hoan_tat = N'" + textbox_du_an_da_trien_khai_ngay_Hoan_tat.Text + "',  " +
               "@so_san_pham = " + UInt64.Parse(textbox_du_an_da_trien_khai_So_san_pham.Text) + "," +
               "@ten_san_pham = N'" + textbox_du_an_da_trien_khai_Ten_san_pham.Text + "'," +
               "@so_von = " + UInt64.Parse(textbox_du_an_da_trien_khai_So_von.Text) + "," +
               "@loi_nhuan = " + UInt64.Parse(textbox_du_an_da_trien_khai_Loi_nhuan.Text) + "," +
               "@doanh_thu = " + UInt64.Parse(textbox_du_an_da_trien_khai_Doanh_thu.Text) + " ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return data;

        }



        public DataTable Sua_thong_tin_du_an_da_trien_khai()
        {


           

            DataTable data = new DataTable();

            try
            {

                string truyvan = "update thong_tin_du_an_da_trien_khai set  ten_du_an = N'" + textbox_du_an_da_trien_khai_Ten_du_an.Text + "'," +
               "ngay_khoi_cong = '" + textbox_du_an_da_trien_khai_Ngay_khoi_cong.Text + "'," +
               "ngay_hoan_tat = N'" + textbox_du_an_da_trien_khai_ngay_Hoan_tat.Text + "', " +
               "so_san_pham = " + UInt64.Parse(textbox_du_an_da_trien_khai_So_san_pham.Text) + "," +
               "ten_san_pham = N'" + textbox_du_an_da_trien_khai_Ten_san_pham.Text + "'," +
               "so_von = " + UInt64.Parse(textbox_du_an_da_trien_khai_So_von.Text) + "," +
               "loi_nhuan = " + UInt64.Parse(textbox_du_an_da_trien_khai_Loi_nhuan.Text) + "," +
               "doanh_thu = " + UInt64.Parse(textbox_du_an_da_trien_khai_Doanh_thu.Text) + " where ma_du_an = '" + textbox_du_an_da_trien_khai_Ma_du_an.Text + "' ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;
        }




        public DataTable Xoa_thong_tin_du_an_da_trien_khai()
        {



            DataTable data = new DataTable();


            try
            {
                string truyvan = "delete thong_tin_du_an_da_trien_khai where ma_du_an = '" + textbox_du_an_da_trien_khai_Ma_du_an.Text + "' ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;
        }


        public DataTable timkiem_du_an_da_trien_khai()
        {


            DataTable data = new DataTable();


            try
            {
                string truyvan = "select * from thong_tin_du_an_da_trien_khai where ma_du_an like '%" + textbox_du_an_da_trien_khai_Tim_kiem.Text + "%' or ten_du_an like N'%" + textbox_du_an_da_trien_khai_Tim_kiem.Text + "%' or ngay_hoan_tat like N'%" + textbox_du_an_da_trien_khai_Tim_kiem.Text + "%' ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;


        }








        public void mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_du_an_da_trien_khai()
        {




            textbox_du_an_da_trien_khai_Ten_du_an.IsReadOnly = false;
            textbox_du_an_da_trien_khai_Ngay_khoi_cong.IsReadOnly = false;
            textbox_du_an_da_trien_khai_ngay_Hoan_tat.IsReadOnly = false;
            textbox_du_an_da_trien_khai_So_san_pham.IsReadOnly = false;
            textbox_du_an_da_trien_khai_Ten_san_pham.IsReadOnly = false;
            textbox_du_an_da_trien_khai_So_von.IsReadOnly = false;
            textbox_du_an_da_trien_khai_Loi_nhuan.IsReadOnly = false;
            textbox_du_an_da_trien_khai_Doanh_thu.IsReadOnly = false;

            button_du_an_da_trien_khai_Luu.Background = Brushes.Transparent;
            button_du_an_da_trien_khai_Huy.Background = Brushes.Transparent;

            button_du_an_da_trien_khai_Luu.IsEnabled = true;
            button_du_an_da_trien_khai_Huy.IsEnabled = true;

            button_du_an_da_trien_khai_Luu.Opacity = 1;
            button_du_an_da_trien_khai_Huy.Opacity = 1;

            button_du_an_da_trien_khai_Them.Background = Brushes.DarkSlateGray;
            button_du_an_da_trien_khai_Sua.Background = Brushes.DarkSlateGray;
            button_thong_tin_du_an_da_trien_khai_Xoa.Background = Brushes.DarkSlateGray;

            button_du_an_da_trien_khai_Them.IsEnabled = false;
            button_du_an_da_trien_khai_Sua.IsEnabled = false;
            button_thong_tin_du_an_da_trien_khai_Xoa.IsEnabled = false;

            button_du_an_da_trien_khai_Them.Opacity = 0.5;
            button_du_an_da_trien_khai_Sua.Opacity = 0.5;
            button_thong_tin_du_an_da_trien_khai_Xoa.Opacity = 0.5;

        }





        public void dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_du_an_da_trien_khai()
        {



            textbox_du_an_da_trien_khai_Ten_du_an.IsReadOnly = true;
            textbox_du_an_da_trien_khai_Ngay_khoi_cong.IsReadOnly = true;
            
            textbox_du_an_da_trien_khai_ngay_Hoan_tat.IsReadOnly = true;
            textbox_du_an_da_trien_khai_So_san_pham.IsReadOnly = true;
            textbox_du_an_da_trien_khai_Ten_san_pham.IsReadOnly = true;
            textbox_du_an_da_trien_khai_So_von.IsReadOnly = true;
            textbox_du_an_da_trien_khai_Loi_nhuan.IsReadOnly = true;
            textbox_du_an_da_trien_khai_Doanh_thu.IsReadOnly = true;

            button_du_an_da_trien_khai_Luu.Background = Brushes.DarkSlateGray;
            button_du_an_da_trien_khai_Huy.Background = Brushes.DarkSlateGray;

            button_du_an_da_trien_khai_Luu.IsEnabled = false;
            button_du_an_da_trien_khai_Huy.IsEnabled = false;

            button_du_an_da_trien_khai_Luu.Opacity = 0.5;
            button_du_an_da_trien_khai_Huy.Opacity = 0.5;

            button_du_an_da_trien_khai_Them.Background = Brushes.Transparent;
            button_du_an_da_trien_khai_Sua.Background = Brushes.Transparent;
            button_thong_tin_du_an_da_trien_khai_Xoa.Background = Brushes.Transparent;

            button_du_an_da_trien_khai_Them.IsEnabled = true;
            button_du_an_da_trien_khai_Sua.IsEnabled = true;
            button_thong_tin_du_an_da_trien_khai_Xoa.IsEnabled = true;

            button_du_an_da_trien_khai_Them.Opacity = 1;
            button_du_an_da_trien_khai_Sua.Opacity = 1;
            button_thong_tin_du_an_da_trien_khai_Xoa.Opacity = 1;


        }


        public bool textIsnotNull_thong_tin_du_an_da_trien_khai()
        {

            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_Ten_du_an.Text))
            {
                MessageBox.Show("'Tên dự án' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_du_an_da_trien_khai_Ten_du_an.Focus();

                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_Ngay_khoi_cong.Text))
            {
                MessageBox.Show("'Ngày khởi công' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            else
            
            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_ngay_Hoan_tat.Text))
            {
                MessageBox.Show("'Ngày hoàn tất' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            else



            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_So_san_pham.Text))
            {

                MessageBox.Show("'Số sản phẩm' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_du_an_da_trien_khai_So_san_pham.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_Ten_san_pham.Text))
            {

                MessageBox.Show("'Tên sản phẩm' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_du_an_da_trien_khai_Ten_san_pham.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_So_von.Text))
            {
                MessageBox.Show("'Số vốn' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_du_an_da_trien_khai_So_von.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_Loi_nhuan.Text))
            {

                MessageBox.Show("'Lợi nhuận' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_du_an_da_trien_khai_Loi_nhuan.Focus();

                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_Doanh_thu.Text))
            {
                MessageBox.Show("'Doanh thu' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_du_an_da_trien_khai_Doanh_thu.Focus();
                return false;
            }

            return true;
        }


        public void thong_tin_du_an_da_trien_khai_Lam_trang_textbox()
        {

            textbox_du_an_da_trien_khai_Ma_du_an.Text = null;
            textbox_du_an_da_trien_khai_Ten_du_an.Text = null;
           textbox_du_an_da_trien_khai_Ngay_khoi_cong.Text = null;
            textbox_du_an_da_trien_khai_ngay_Hoan_tat.Text = null;
            textbox_du_an_da_trien_khai_So_san_pham.Text = null;
            textbox_du_an_da_trien_khai_Ten_san_pham.Text = null;
            textbox_du_an_da_trien_khai_So_von.Text = null;
            textbox_du_an_da_trien_khai_Loi_nhuan.Text = null;
            textbox_du_an_da_trien_khai_Doanh_thu.Text = null;



        }


        public void binding_to_textbox()
        {

            Binding ma_du_an = new Binding();
            ma_du_an.Mode = BindingMode.OneWay;
            Binding ten_du_an = new Binding();
            ten_du_an.Mode = BindingMode.OneWay;
            Binding so_san_pham = new Binding();
            so_san_pham.Mode = BindingMode.OneWay;
            Binding ten_san_pham = new Binding();
            ten_san_pham.Mode = BindingMode.OneWay;
            Binding so_von = new Binding();
            so_von.Mode = BindingMode.OneWay;
            Binding loi_nhuan = new Binding();
            loi_nhuan.Mode = BindingMode.OneWay;
            Binding doanh_thu = new Binding();
            doanh_thu.Mode = BindingMode.OneWay;
            Binding ngay_khoi_cong = new Binding();
            ngay_khoi_cong.Mode = BindingMode.OneWay;
            Binding ngay_hoan_tat = new Binding();
            ngay_hoan_tat.Mode = BindingMode.OneWay;

            // The source
            ma_du_an.Path = new PropertyPath("SelectedValue.[ma_du_an]");
            ma_du_an.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            ten_du_an.Path = new PropertyPath("SelectedValue.[ten_du_an]");
            ten_du_an.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            so_san_pham.Path = new PropertyPath("SelectedValue.[so_san_pham]");
            so_san_pham.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            ten_san_pham.Path = new PropertyPath("SelectedValue.[ten_san_pham]");
            ten_san_pham.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            so_von.Path = new PropertyPath("SelectedValue.[so_von]");
            so_von.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            loi_nhuan.Path = new PropertyPath("SelectedValue.[loi_nhuan]");
            loi_nhuan.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            doanh_thu.Path = new PropertyPath("SelectedValue.[doanh_thu]");
            doanh_thu.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            ngay_khoi_cong.Path = new PropertyPath("SelectedValue.[ngay_khoi_cong]");
            ngay_khoi_cong.ElementName = "listview_Thong_tin_du_an_da_trien_khai";
            ngay_hoan_tat.Path = new PropertyPath("SelectedValue.[ ngay_hoan_tat]");
            ngay_hoan_tat.ElementName = "listview_Thong_tin_du_an_da_trien_khai";


            // The target
            textbox_du_an_da_trien_khai_Ma_du_an.SetBinding(TextBox.TextProperty, ma_du_an);
            textbox_du_an_da_trien_khai_Ten_du_an.SetBinding(TextBox.TextProperty, ten_du_an);
            textbox_du_an_da_trien_khai_So_san_pham.SetBinding(TextBox.TextProperty, so_san_pham);
            textbox_du_an_da_trien_khai_Ten_san_pham.SetBinding(TextBox.TextProperty, ten_san_pham);
            textbox_du_an_da_trien_khai_So_von.SetBinding(TextBox.TextProperty, so_von);
            textbox_du_an_da_trien_khai_Loi_nhuan.SetBinding(TextBox.TextProperty, loi_nhuan);
            textbox_du_an_da_trien_khai_Doanh_thu.SetBinding(TextBox.TextProperty, doanh_thu);
            textbox_du_an_da_trien_khai_Ngay_khoi_cong.SetBinding(TextBox.TextProperty, ngay_khoi_cong);
            textbox_du_an_da_trien_khai_ngay_Hoan_tat.SetBinding(TextBox.TextProperty, ngay_hoan_tat);



        }






















        //Listview dự án đã triển khai
        private void listview_Thong_tin_du_an_da_trien_khai_MouseEnter(object sender, MouseEventArgs e)
        {
            listview_Thong_tin_du_an_da_trien_khai.Foreground = Brushes.DarkGoldenrod;


        }

        private void listview_Thong_tin_du_an_da_trien_khai_MouseLeave(object sender, MouseEventArgs e)
        {
            listview_Thong_tin_du_an_da_trien_khai.Foreground = Brushes.DarkBlue;
        }








        //Chức năng của button dự án đã triển khai
        private void button_du_an_da_trien_khai_Them_Click(object sender, RoutedEventArgs e)
        {

            mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_du_an_da_trien_khai();

            thong_tin_du_an_da_trien_khai_Lam_trang_textbox();
            flag = "Thêm";



            button_du_an_da_trien_khai_Them.BorderBrush = Brushes.DarkGoldenrod;
            button_du_an_da_trien_khai_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_du_an_da_trien_khai_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Huy.BorderBrush = Brushes.LightSkyBlue;


        }

        private void button_du_an_da_trien_khai_Sua_Click(object sender, RoutedEventArgs e)
        {



            // binding_to_textbox();

           
            flag = "Sửa";

            button_du_an_da_trien_khai_Them.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Sua.BorderBrush = Brushes.DarkGoldenrod;
            button_thong_tin_du_an_da_trien_khai_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Huy.BorderBrush = Brushes.LightSkyBlue;



        }





        private void button_thong_tin_du_an_da_trien_khai_Xoa_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrEmpty(textbox_du_an_da_trien_khai_Ma_du_an.Text))
                MessageBox.Show("Hãy chọn đối tượng để xóa !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    Xoa_thong_tin_du_an_da_trien_khai();
                    thong_tin_du_an_da_trien_khai();

                    button_du_an_da_trien_khai_Them.BorderBrush = Brushes.LightSkyBlue;
                    button_du_an_da_trien_khai_Sua.BorderBrush = Brushes.LightSkyBlue;
                    button_thong_tin_du_an_da_trien_khai_Xoa.BorderBrush = Brushes.DarkGoldenrod;
                    button_du_an_da_trien_khai_Luu.BorderBrush = Brushes.LightSkyBlue;
                    button_du_an_da_trien_khai_Huy.BorderBrush = Brushes.LightSkyBlue;
                }

            }






        }











        private void button_du_an_da_trien_khai_Luu_Click(object sender, RoutedEventArgs e)
        {



            if (textIsnotNull_thong_tin_du_an_da_trien_khai())
            {

                if (flag == "Thêm")
                {

                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_du_an_da_trien_khai();
                    Them_thong_tin_du_an_da_trien_khai();

                }




                if (flag == "Sửa")
                {

                    Sua_thong_tin_du_an_da_trien_khai();
                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_du_an_da_trien_khai();
                }



                button_du_an_da_trien_khai_Them.BorderBrush = Brushes.LightSkyBlue;
                button_du_an_da_trien_khai_Sua.BorderBrush = Brushes.LightSkyBlue;
                button_thong_tin_du_an_da_trien_khai_Xoa.BorderBrush = Brushes.LightSkyBlue;
                button_du_an_da_trien_khai_Luu.BorderBrush = Brushes.DarkGoldenrod;
                button_du_an_da_trien_khai_Huy.BorderBrush = Brushes.LightSkyBlue;

            }









            thong_tin_du_an_da_trien_khai();
            binding_to_textbox();

            //flag = "Lưu";
        }







        private void button_du_an_da_trien_khai_Huy_Click(object sender, RoutedEventArgs e)
        {
            dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_du_an_da_trien_khai();

            textbox_du_an_da_trien_khai_Ngay_khoi_cong.Text = "";
            binding_to_textbox();
            flag = "Hủy";

            button_du_an_da_trien_khai_Them.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_du_an_da_trien_khai_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_du_an_da_trien_khai_Huy.BorderBrush = Brushes.DarkGoldenrod;

        }

        private void listview_Thong_tin_du_an_da_trien_khai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flag == "Thêm" & flag != "Lưu")
            {

                thong_tin_du_an_da_trien_khai_Lam_trang_textbox();


            }


            binding_to_textbox();



        }

        private void listview_Thong_tin_du_an_da_trien_khai_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == "Sửa") mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_du_an_da_trien_khai();
            textbox_du_an_da_trien_khai_Ten_du_an.Focus();
        }










        //*****************************************************************************************************************








        //*****Khu vực kế hoạch cho dự án mới**********************************************************************


        public DataTable xay_dung_ke_hoach_cho_du_an_moi()
        {


            DataTable data = new DataTable();

            try
            {

                string truyvan = "select * from xay_dung_ke_hoach_cho_du_an_moi";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_xay_dung_ke_hoach_cho_du_an_moi.ItemsSource = data.DefaultView;


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            return data;
        }





        public DataTable Them_ke_hoach_cho_du_an_moi()
        {
            

            DataTable data = new DataTable();

            try
            {

                string truyvan = "exec them_ke_hoach @ma_du_an=''," +
                "@ten_du_an=N'" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.Text + "'," +
                "@ngay_khoi_cong_du_kien = '" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.Text+ "'," +
                "@so_san_pham_du_tinh = " + UInt64.Parse(textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.Text) + "," +
                "@ten_san_pham=N'" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.Text + "'," +
                "@so_von_du_kien = " + UInt64.Parse(textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.Text) + "," +
                "@loi_nhuan_du_kien = " + textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.Text + " ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;

        }






        public DataTable Sua_ke_hoach_cho_du_an_moi()
        {



            DataTable data = new DataTable();

            try
            {

                string truyvan = "update xay_dung_ke_hoach_cho_du_an_moi set " +
                "ten_du_an=N'" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.Text + "'," +
                "ngay_khoi_cong_du_kien = '" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.Text + "'," +
                "so_san_pham_du_tinh = " + UInt64.Parse(textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.Text) + "," +
                "ten_san_pham=N'" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.Text + "'," +
                "so_von_du_kien = " + UInt64.Parse(textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.Text) + "," +
                "loi_nhuan_du_kien = " + textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.Text + " where ma_du_an = '" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.Text + "' ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }





            return data;
        }




        public DataTable Xoa_ke_hoach_cho_du_an_moi()
        {



            DataTable data = new DataTable();

            try
            {

                string truyvan = "delete xay_dung_ke_hoach_cho_du_an_moi where ma_du_an = '" + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.Text + "' ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Thong_tin_du_an_da_trien_khai.ItemsSource = data.DefaultView;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }





            return data;
        }





        public DataTable timkiem_ke_hoach_du_an_moi()
        {


            DataTable data = new DataTable();


            try
            {
                string truyvan = "select * from xay_dung_ke_hoach_cho_du_an_moi where ma_du_an like '%" + textbox_Xay_dung_ke_hoach_du_an_moi_Tim_kiem.Text + "%' or ten_du_an like N'%" + textbox_Xay_dung_ke_hoach_du_an_moi_Tim_kiem.Text + "%' or ngay_khoi_cong_du_kien like N'%" + textbox_Xay_dung_ke_hoach_du_an_moi_Tim_kiem.Text + "%'  ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_xay_dung_ke_hoach_cho_du_an_moi.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;


        }





        public void mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_ke_hoach_cho_du_an_moi()
        {

            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.IsReadOnly = true;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.IsReadOnly = false;
         
           
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.IsReadOnly = false;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.IsReadOnly = false;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.IsReadOnly = false;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.IsReadOnly = false;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.IsReadOnly = false;


            button_ke_hoach_cho_du_an_moi_Luu.Background = Brushes.Transparent;
            button_ke_hoach_cho_du_an_moi_Huy.Background = Brushes.Transparent;

            button_ke_hoach_cho_du_an_moi_Luu.IsEnabled = true;
            button_ke_hoach_cho_du_an_moi_Huy.IsEnabled = true;

            button_ke_hoach_cho_du_an_moi_Luu.Opacity = 1;
            button_ke_hoach_cho_du_an_moi_Huy.Opacity = 1;

            button_ke_hoach_cho_du_an_moi_Them.Background = Brushes.DarkSlateGray;
            button_ke_hoach_cho_du_an_moi_Sua.Background = Brushes.DarkSlateGray;
            button_ke_hoach_cho_du_an_moi_Xoa.Background = Brushes.DarkSlateGray;

            button_ke_hoach_cho_du_an_moi_Them.IsEnabled = false;
            button_ke_hoach_cho_du_an_moi_Sua.IsEnabled = false;
            button_ke_hoach_cho_du_an_moi_Xoa.IsEnabled = false;

            button_ke_hoach_cho_du_an_moi_Them.Opacity = 0.5;
            button_ke_hoach_cho_du_an_moi_Sua.Opacity = 0.5;
            button_ke_hoach_cho_du_an_moi_Xoa.Opacity = 0.5;

        }





        public void dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_ke_hoach_cho_du_an_moi()
        {

            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.IsReadOnly = true;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.IsReadOnly = true;
           
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.IsReadOnly = true;

            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.IsReadOnly = true;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.IsReadOnly = true;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.IsReadOnly = true;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.IsReadOnly = true;


            button_ke_hoach_cho_du_an_moi_Luu.Background = Brushes.DarkSlateGray;
            button_ke_hoach_cho_du_an_moi_Huy.Background = Brushes.DarkSlateGray;

            button_ke_hoach_cho_du_an_moi_Luu.IsEnabled = false;
            button_ke_hoach_cho_du_an_moi_Huy.IsEnabled = false;

            button_ke_hoach_cho_du_an_moi_Luu.Opacity = 0.5;
            button_ke_hoach_cho_du_an_moi_Huy.Opacity = 0.5;

            button_ke_hoach_cho_du_an_moi_Them.Background = Brushes.Transparent;
            button_ke_hoach_cho_du_an_moi_Sua.Background = Brushes.Transparent;
            button_ke_hoach_cho_du_an_moi_Xoa.Background = Brushes.Transparent;

            button_ke_hoach_cho_du_an_moi_Them.IsEnabled = true;
            button_ke_hoach_cho_du_an_moi_Sua.IsEnabled = true;
            button_ke_hoach_cho_du_an_moi_Xoa.IsEnabled = true;

            button_ke_hoach_cho_du_an_moi_Them.Opacity = 1;
            button_ke_hoach_cho_du_an_moi_Sua.Opacity = 1;
            button_ke_hoach_cho_du_an_moi_Xoa.Opacity = 1;


        }




        public void ke_hoach_cho_du_an_moi_Lam_trang_textbox()
        {

            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.Text = null;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.Text = null;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.Text = null;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.Text = null;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.Text = null;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.Text = null;
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.Text = null;




        }



        public bool textIsnotNull_ke_hoach_cho_du_an_moi()
        {

            if (string.IsNullOrEmpty(textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.Text))
            {

                MessageBox.Show("'Tên dự án' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.Focus();

                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.Text))
            {

                MessageBox.Show("'Ngày khởi công dự kiến' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.Text))
            {

                MessageBox.Show("'Số sản phẩm' không được để trống !", "", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.Text))
            {

                MessageBox.Show("Tên sản phẩm không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.Text))
            {

                MessageBox.Show("Số vốn dự kiến không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.Text))
            {

                MessageBox.Show("'Lợi nhuận' không được để trống !", "Nhăc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.Focus();

                return false;
            }



            return true;
        }




        public void binding_to_textbox_ke_hoach_du_an_moi()
        {

            Binding ma_du_an = new Binding();
            ma_du_an.Mode = BindingMode.OneWay;
            Binding ten_du_an = new Binding();
            ten_du_an.Mode = BindingMode.OneWay;
            Binding so_san_pham_du_tinh = new Binding();
            so_san_pham_du_tinh.Mode = BindingMode.OneWay;
            Binding ten_san_pham = new Binding();
            ten_san_pham.Mode = BindingMode.OneWay;
            Binding so_von_du_kien = new Binding();
            so_von_du_kien.Mode = BindingMode.OneWay;
            Binding loi_nhuan_du_kien = new Binding();
            loi_nhuan_du_kien.Mode = BindingMode.OneWay;
            Binding ngay_khoi_cong_du_kien = new Binding();
            ngay_khoi_cong_du_kien.Mode = BindingMode.OneWay;



            // The source
            ma_du_an.Path = new PropertyPath("SelectedValue.[ma_du_an]");
            ma_du_an.ElementName = "listview_xay_dung_ke_hoach_cho_du_an_moi";
            ten_du_an.Path = new PropertyPath("SelectedValue.[ten_du_an]");
            ten_du_an.ElementName = "listview_xay_dung_ke_hoach_cho_du_an_moi";
            so_san_pham_du_tinh.Path = new PropertyPath("SelectedValue.[so_san_pham_du_tinh]");
            so_san_pham_du_tinh.ElementName = "listview_xay_dung_ke_hoach_cho_du_an_moi";
            ten_san_pham.Path = new PropertyPath("SelectedValue.[ten_san_pham]");
            ten_san_pham.ElementName = "listview_xay_dung_ke_hoach_cho_du_an_moi";
            so_von_du_kien.Path = new PropertyPath("SelectedValue.[so_von_du_kien]");
            so_von_du_kien.ElementName = "listview_xay_dung_ke_hoach_cho_du_an_moi";
            loi_nhuan_du_kien.Path = new PropertyPath("SelectedValue.[loi_nhuan_du_kien]");
            loi_nhuan_du_kien.ElementName = "listview_xay_dung_ke_hoach_cho_du_an_moi";
            ngay_khoi_cong_du_kien.Path = new PropertyPath("SelectedValue.[ ngay_khoi_cong_du_kien]");
            ngay_khoi_cong_du_kien.ElementName = "listview_xay_dung_ke_hoach_cho_du_an_moi";


            // The target
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.SetBinding(TextBox.TextProperty, ma_du_an);
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.SetBinding(TextBox.TextProperty, ten_du_an);
            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.SetBinding(TextBox.TextProperty, so_san_pham_du_tinh);
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.SetBinding(TextBox.TextProperty, ten_san_pham);
            textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.SetBinding(TextBox.TextProperty, so_von_du_kien);
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.SetBinding(TextBox.TextProperty, loi_nhuan_du_kien);
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.SetBinding(TextBox.TextProperty, ngay_khoi_cong_du_kien);


        }



        private void listview_xay_dung_ke_hoach_cho_du_an_moi_MouseEnter(object sender, MouseEventArgs e)
        {
            listview_xay_dung_ke_hoach_cho_du_an_moi.Foreground = Brushes.DarkGoldenrod;
        }

        private void listview_xay_dung_ke_hoach_cho_du_an_moi_MouseLeave(object sender, MouseEventArgs e)
        {
            listview_xay_dung_ke_hoach_cho_du_an_moi.Foreground = Brushes.DarkBlue;
        }









        private void button_ke_hoach_cho_du_an_moi_Them_Click(object sender, RoutedEventArgs e)
        {
            mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_ke_hoach_cho_du_an_moi();

            ke_hoach_cho_du_an_moi_Lam_trang_textbox();

            button_ke_hoach_cho_du_an_moi_Them.BorderBrush = Brushes.DarkGoldenrod;
            button_ke_hoach_cho_du_an_moi_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Huy.BorderBrush = Brushes.LightSkyBlue;
            flag = "Thêm dự án mới";
        }

        private void button_ke_hoach_cho_du_an_moi_Sua_Click(object sender, RoutedEventArgs e)
        {



            binding_to_textbox_ke_hoach_du_an_moi();

            button_ke_hoach_cho_du_an_moi_Them.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Sua.BorderBrush = Brushes.DarkGoldenrod;
            button_ke_hoach_cho_du_an_moi_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Huy.BorderBrush = Brushes.LightSkyBlue;



            flag = "Sửa dự án mới";

        }

        private void button_ke_hoach_cho_du_an_moi_Xoa_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.Text))
                MessageBox.Show("Hãy chọn đối tượng để xóa !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {

                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {



                    Xoa_ke_hoach_cho_du_an_moi();
                    xay_dung_ke_hoach_cho_du_an_moi();

                    button_ke_hoach_cho_du_an_moi_Them.BorderBrush = Brushes.LightSkyBlue;
                    button_ke_hoach_cho_du_an_moi_Sua.BorderBrush = Brushes.LightSkyBlue;
                    button_ke_hoach_cho_du_an_moi_Xoa.BorderBrush = Brushes.DarkGoldenrod;
                    button_ke_hoach_cho_du_an_moi_Luu.BorderBrush = Brushes.LightSkyBlue;
                    button_ke_hoach_cho_du_an_moi_Huy.BorderBrush = Brushes.LightSkyBlue;
                }

            }







        }













        private void button_ke_hoach_cho_du_an_moi_Luu_Click(object sender, RoutedEventArgs e)
        {

            button_ke_hoach_cho_du_an_moi_Luu.BorderBrush = Brushes.DarkGoldenrod;

            if (textIsnotNull_ke_hoach_cho_du_an_moi() )
            {

                if(flag == "Thêm dự án mới") 
                {

                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_ke_hoach_cho_du_an_moi();
                    Them_ke_hoach_cho_du_an_moi();


                }

               



            

         
                if (flag == "Sửa dự án mới")
                {



                    Sua_ke_hoach_cho_du_an_moi();
                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_ke_hoach_cho_du_an_moi();

                }


               



            }


            xay_dung_ke_hoach_cho_du_an_moi();


            button_ke_hoach_cho_du_an_moi_Them.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Luu.BorderBrush = Brushes.DarkGoldenrod;
            button_ke_hoach_cho_du_an_moi_Huy.BorderBrush = Brushes.LightSkyBlue;

            binding_to_textbox_ke_hoach_du_an_moi();


        }

        private void button_ke_hoach_cho_du_an_moi_Huy_Click(object sender, RoutedEventArgs e)
        {
            binding_to_textbox_ke_hoach_du_an_moi();
            dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_ke_hoach_cho_du_an_moi();



            // textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.Text = "";

            button_ke_hoach_cho_du_an_moi_Them.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_ke_hoach_cho_du_an_moi_Huy.BorderBrush = Brushes.DarkGoldenrod;

            flag = "Hủy dự án mới";


        }




        private void listview_xay_dung_ke_hoach_cho_du_an_moi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == "Sửa dự án mới") mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_ke_hoach_cho_du_an_moi();
            textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.Focus();

        }




















        //****************************************************************************************************************







        //***Khu vực thông tin đối tác******************************************************************************************





        public DataTable thong_tin_doi_dac()
        {


            DataTable data = new DataTable();

            try
            {

                string truyvan = "select * from quan_ly_thong_tin_doi_tac";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_quan_ly_thong_tin_doi_tac.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            return data;
        }






        public DataTable Them_thong_tin_doi_dac()
        {
            

            DataTable data = new DataTable();

            try
            {

                string truyvan = "exec them_doi_tac @ma_doi_tac =''," +
                "@ten_doi_tac=N'" + textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.Text + "'," +
                "@nghe_nghiep = N'" + textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.Text + "'," +
                "@so_dien_thoai = N'" + textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.Text + "'," +
                "@ngay_sinh = N'" + textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.Text + "'," +
                "@dia_chi=N'" + textbox_quan_ly_thong_tin_doi_tac_Dia_chi.Text + "'," +
                "@ngay_bat_dau_hop_tac = N'" + textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.Text + "' ," +
                "@dong_vai_tro = N'" + textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.Text + "' ," +
                "@ti_le_gop_von = " + float.Parse(textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.Text) + " ," +
                "@ti_le_phan_phoi_co_tuc = " + float.Parse(textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.Text) + " ," +
                "@tong_so_tien_da_giao_dich = " + UInt64.Parse(textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.Text) + "            ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_quan_ly_thong_tin_doi_tac.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return data;
        }





        public DataTable Sua_thong_tin_doi_dac()
        {
           

            DataTable data = new DataTable();

            try
            {

                string truyvan = "update quan_ly_thong_tin_doi_tac set " +
                "ten_doi_tac=N'" + textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.Text + "'," +
                "nghe_nghiep = N'" + textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.Text + "'," +
                "so_dien_thoai = N'" + textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.Text + "'," +
                "ngay_sinh = N'" + textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.Text + "'," +
                "dia_chi=N'" + textbox_quan_ly_thong_tin_doi_tac_Dia_chi.Text + "'," +
                "ngay_bat_dau_hop_tac = N'" + textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.Text+ "' ," +
                "dong_vai_tro = N'" + textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.Text + "' ," +
                "ti_le_gop_von = " + float.Parse(textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.Text) + "," +
                "ti_le_phan_phoi_co_tuc = " + float.Parse(textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.Text) + " ," +
                "tong_so_tien_da_giao_dich = " + UInt64.Parse(textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.Text) + "     " +
                " where ma_doi_tac = '" + textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.Text + "' ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_quan_ly_thong_tin_doi_tac.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return data;
        }




        public DataTable Xoa_thong_tin_doi_dac()
        {


            DataTable data = new DataTable();

            try
            {

                string truyvan = "delete quan_ly_thong_tin_doi_tac where ma_doi_tac = '" + textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.Text + "' ";

                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_quan_ly_thong_tin_doi_tac.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            return data;
        }




        public DataTable timkiem_thong_tin_doi_tac()
        {


            DataTable data = new DataTable();


            try
            {
                string truyvan = "select * from quan_ly_thong_tin_doi_tac where ma_doi_tac like '%" + textbox_quan_ly_thong_tin_doi_tac_Tim_kiem.Text + "%' or ten_doi_tac like N'%" + textbox_quan_ly_thong_tin_doi_tac_Tim_kiem.Text + "%' or dong_vai_tro like N'%" + textbox_quan_ly_thong_tin_doi_tac_Tim_kiem.Text + "%'  or ngay_bat_dau_hop_tac like N'%" + textbox_quan_ly_thong_tin_doi_tac_Tim_kiem.Text + "%'   ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_quan_ly_thong_tin_doi_tac.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;


        }







        public void mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_doi_tac()
        {

            textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.IsReadOnly = false;
            textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.IsReadOnly = false;
            textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.IsReadOnly = false;
            
            textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.IsReadOnly = false;
            textbox_quan_ly_thong_tin_doi_tac_Dia_chi.IsReadOnly = false;
          
            textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.IsReadOnly = false;
            textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.IsReadOnly = false;
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.IsReadOnly = false;
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.IsReadOnly = false;
            textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.IsReadOnly = false;





            button_quan_ly_thong_tin_doi_tac_Luu.Background = Brushes.Transparent;
            button_thong_tin_doi_tac_Huy.Background = Brushes.Transparent;

            button_quan_ly_thong_tin_doi_tac_Luu.IsEnabled = true;
            button_thong_tin_doi_tac_Huy.IsEnabled = true;

            button_quan_ly_thong_tin_doi_tac_Luu.Opacity = 1;
            button_thong_tin_doi_tac_Huy.Opacity = 1;

            button_quan_ly_thong_tin_doi_tac_Them.Background = Brushes.DarkSlateGray;
            button_quan_ly_thong_tin_doi_tac_Sua.Background = Brushes.DarkSlateGray;
            button_quan_ly_thong_tin_doi_tac_Xoa.Background = Brushes.DarkSlateGray;

            button_quan_ly_thong_tin_doi_tac_Them.IsEnabled = false;
            button_quan_ly_thong_tin_doi_tac_Sua.IsEnabled = false;
            button_quan_ly_thong_tin_doi_tac_Xoa.IsEnabled = false;

            button_quan_ly_thong_tin_doi_tac_Them.Opacity = 0.5;
            button_quan_ly_thong_tin_doi_tac_Sua.Opacity = 0.5;
            button_quan_ly_thong_tin_doi_tac_Xoa.Opacity = 0.5;

        }





        public void dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_doi_tac()
        {

            textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.IsReadOnly = true;
          
            textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Dia_chi.IsReadOnly = true;
          
            textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.IsReadOnly = true;
            textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.IsReadOnly = true;




            button_quan_ly_thong_tin_doi_tac_Luu.Background = Brushes.DarkSlateGray;
            button_thong_tin_doi_tac_Huy.Background = Brushes.DarkSlateGray;

            button_quan_ly_thong_tin_doi_tac_Luu.IsEnabled = false;
            button_thong_tin_doi_tac_Huy.IsEnabled = false;

            button_quan_ly_thong_tin_doi_tac_Luu.Opacity = 0.5;
            button_thong_tin_doi_tac_Huy.Opacity = 0.5;

            button_quan_ly_thong_tin_doi_tac_Them.Background = Brushes.Transparent;
            button_quan_ly_thong_tin_doi_tac_Sua.Background = Brushes.Transparent;
            button_quan_ly_thong_tin_doi_tac_Xoa.Background = Brushes.Transparent;

            button_quan_ly_thong_tin_doi_tac_Them.IsEnabled = true;
            button_quan_ly_thong_tin_doi_tac_Sua.IsEnabled = true;
            button_quan_ly_thong_tin_doi_tac_Xoa.IsEnabled = true;

            button_quan_ly_thong_tin_doi_tac_Them.Opacity = 1;
            button_quan_ly_thong_tin_doi_tac_Sua.Opacity = 1;
            button_quan_ly_thong_tin_doi_tac_Xoa.Opacity = 1;


        }




        public bool textIsnotNull_thong_tin_doi_tac()
        {

         
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.Text))
            {

                MessageBox.Show("'Tên đối tác' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.Text))
            {

                MessageBox.Show("'Nghề nghiệp' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.Text))
            {


                MessageBox.Show("'Số điện thoại không được để trống !'", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.Focus();




                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.Text))
            {

                MessageBox.Show("'Ngày sinh' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Dia_chi.Text))
            {

                MessageBox.Show("'Địa chỉ' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_quan_ly_thong_tin_doi_tac_Dia_chi.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.Text))
            {

                MessageBox.Show("'Ngày bắt đầu hợp tác' không được để trống !", "", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.Text))
            {

                MessageBox.Show("'Đóng vai trò' không được để trống !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.Focus();

                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.Text))
            {

                MessageBox.Show("'Tỉ lệ góp vốn' không được để trống !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.Focus();

                return false;
            }


            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.Text))
            {

                MessageBox.Show("'Tỉ lệ phân phối cổ tức' không được để trống !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.Focus();

                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.Text))
            {

                MessageBox.Show("'Tổng số tiền đã giao dịch' không được để trống !", "", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.Focus();
                return false;
            }


            else

          




            return true;
        }




        public void thong_tin_doi_tac_Lam_trang_textbox()
        {

            textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Dia_chi.Text = null;
           textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.Text = null;
            textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.Text = null;




        }







        public void binding_to_textbox_thong_tin_doi_tac()
        {

            Binding ma_doi_tac = new Binding();
            ma_doi_tac.Mode = BindingMode.OneWay;
            Binding ten_doi_tac = new Binding();
            ten_doi_tac.Mode = BindingMode.OneWay;
            Binding nghe_nghiep = new Binding();
            nghe_nghiep.Mode = BindingMode.OneWay;
            Binding so_dien_thoai = new Binding();
            so_dien_thoai.Mode = BindingMode.OneWay;
            Binding dia_chi = new Binding();
            dia_chi.Mode = BindingMode.OneWay;
            Binding ngay_sinh = new Binding();
            ngay_sinh.Mode = BindingMode.OneWay;
            Binding ngay_bat_dau_hop_tac = new Binding();
            ngay_bat_dau_hop_tac.Mode = BindingMode.OneWay;
            Binding dong_vai_tro = new Binding();
            dong_vai_tro.Mode = BindingMode.OneWay;
            Binding ti_le_gop_von = new Binding();
            ti_le_gop_von.Mode = BindingMode.OneWay;
            Binding ti_le_phan_phoi_co_tuc = new Binding();
            ti_le_phan_phoi_co_tuc.Mode = BindingMode.OneWay;
            Binding tong_so_tien_da_giao_dich = new Binding();
            tong_so_tien_da_giao_dich.Mode = BindingMode.OneWay;




            // The source
            ma_doi_tac.Path = new PropertyPath("SelectedValue.[  ma_doi_tac]");
            ma_doi_tac.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            ten_doi_tac.Path = new PropertyPath("SelectedValue.[ ten_doi_tac]");
            ten_doi_tac.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            nghe_nghiep.Path = new PropertyPath("SelectedValue.[ nghe_nghiep]");
            nghe_nghiep.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            so_dien_thoai.Path = new PropertyPath("SelectedValue.[so_dien_thoai]");
            so_dien_thoai.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            dia_chi.Path = new PropertyPath("SelectedValue.[ dia_chi]");
            dia_chi.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            ngay_sinh.Path = new PropertyPath("SelectedValue.[ngay_sinh]");
            ngay_sinh.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            ngay_bat_dau_hop_tac.Path = new PropertyPath("SelectedValue.[ngay_bat_dau_hop_tac]");
            ngay_bat_dau_hop_tac.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            dong_vai_tro.Path = new PropertyPath("SelectedValue.[ dong_vai_tro]");
            dong_vai_tro.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            ti_le_gop_von.Path = new PropertyPath("SelectedValue.[  ti_le_gop_von]");
            ti_le_gop_von.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            ti_le_phan_phoi_co_tuc.Path = new PropertyPath("SelectedValue.[ ti_le_phan_phoi_co_tuc]");
            ti_le_phan_phoi_co_tuc.ElementName = "listview_quan_ly_thong_tin_doi_tac";
            tong_so_tien_da_giao_dich.Path = new PropertyPath("SelectedValue.[ tong_so_tien_da_giao_dich]");
            tong_so_tien_da_giao_dich.ElementName = "listview_quan_ly_thong_tin_doi_tac";



            // The target
            textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.SetBinding(TextBox.TextProperty, ma_doi_tac);
            textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.SetBinding(TextBox.TextProperty, ten_doi_tac);
            textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.SetBinding(TextBox.TextProperty, nghe_nghiep);
            textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.SetBinding(TextBox.TextProperty, so_dien_thoai);
            textbox_quan_ly_thong_tin_doi_tac_Dia_chi.SetBinding(TextBox.TextProperty, dia_chi);
            textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.SetBinding(TextBox.TextProperty, ngay_sinh);
            textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.SetBinding(TextBox.TextProperty, ngay_bat_dau_hop_tac);
            textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.SetBinding(TextBox.TextProperty, dong_vai_tro);
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.SetBinding(TextBox.TextProperty, ti_le_gop_von);
            textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.SetBinding(TextBox.TextProperty, ti_le_phan_phoi_co_tuc);
            textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.SetBinding(TextBox.TextProperty, tong_so_tien_da_giao_dich);
        }





        private void listview_quan_ly_thong_tin_doi_tac_MouseEnter(object sender, MouseEventArgs e)
        {
            listview_quan_ly_thong_tin_doi_tac.Foreground = Brushes.DarkGoldenrod;
        }

        private void listview_quan_ly_thong_tin_doi_tac_MouseLeave(object sender, MouseEventArgs e)
        {
            listview_quan_ly_thong_tin_doi_tac.Foreground = Brushes.DarkBlue;

        }




        private void button_quan_ly_thong_tin_doi_tac_Them_Click(object sender, RoutedEventArgs e)
        {

            mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_doi_tac();

            thong_tin_doi_tac_Lam_trang_textbox();


            button_quan_ly_thong_tin_doi_tac_Them.BorderBrush = Brushes.DarkGoldenrod;
            button_quan_ly_thong_tin_doi_tac_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_doi_tac_Huy.BorderBrush = Brushes.LightSkyBlue;

            flag = "Thêm đối tác";


        }

        private void button_quan_ly_thong_tin_doi_tac_Sua_Click(object sender, RoutedEventArgs e)
        {


            flag = "Sửa đối tác";
            binding_to_textbox_thong_tin_doi_tac();

            button_quan_ly_thong_tin_doi_tac_Them.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Sua.BorderBrush = Brushes.DarkGoldenrod;
            button_quan_ly_thong_tin_doi_tac_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_doi_tac_Huy.BorderBrush = Brushes.LightSkyBlue;


        }

        private void button_quan_ly_thong_tin_doi_tac_Xoa_Click(object sender, RoutedEventArgs e)
        {



            if (string.IsNullOrEmpty(textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.Text))
                MessageBox.Show("Hãy chọn đối tượng để xóa !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {


                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {



                    Xoa_thong_tin_doi_dac();
                    thong_tin_doi_dac();

                    button_quan_ly_thong_tin_doi_tac_Them.BorderBrush = Brushes.LightSkyBlue;
                    button_quan_ly_thong_tin_doi_tac_Sua.BorderBrush = Brushes.LightSkyBlue;
                    button_quan_ly_thong_tin_doi_tac_Xoa.BorderBrush = Brushes.DarkGoldenrod;
                    button_quan_ly_thong_tin_doi_tac_Luu.BorderBrush = Brushes.LightSkyBlue;
                    button_thong_tin_doi_tac_Huy.BorderBrush = Brushes.LightSkyBlue;
                }
            }





            binding_to_textbox_thong_tin_doi_tac();
        }

















        private void button_quan_ly_thong_tin_doi_tac_Luu_Click(object sender, RoutedEventArgs e)
        {



            if (textIsnotNull_thong_tin_doi_tac())
            {

                if(flag == "Thêm đối tác") 
                {
                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_doi_tac();
                    Them_thong_tin_doi_dac();

                }

              

              


           

                if (flag == "Sửa đối tác")
                {

                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_doi_tac();

                    Sua_thong_tin_doi_dac();


                }
               



               
            }









            thong_tin_doi_dac();
            binding_to_textbox_thong_tin_doi_tac();


            button_quan_ly_thong_tin_doi_tac_Them.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Luu.BorderBrush = Brushes.DarkGoldenrod;
            button_thong_tin_doi_tac_Huy.BorderBrush = Brushes.LightSkyBlue;


        }

        private void button_thong_tin_doi_tac_Huy_Click(object sender, RoutedEventArgs e)
        {

            dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_thong_tin_doi_tac();

            binding_to_textbox_thong_tin_doi_tac();



            button_quan_ly_thong_tin_doi_tac_Them.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_quan_ly_thong_tin_doi_tac_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_thong_tin_doi_tac_Huy.BorderBrush = Brushes.DarkGoldenrod;

            flag = "Hủy đối tác";


        }


        private void listview_quan_ly_thong_tin_doi_tac_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == "Sửa đối tác") mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_thong_tin_doi_tac();

            textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.Focus();
        }






















        //**************************************************************************************************************************




        //**********Khu vực giám sát dự án****************************





        public DataTable danh_sach_du_an_can_Giam_sat()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "select * from du_an";
                SqlConnection connect = new SqlConnection(chuoiketnoi);
                connect.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
                adapter.Fill(data);
                connect.Close();

                listview_Giam_sat_du_an.ItemsSource = data.DefaultView;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            return data;







        }










        public DataTable Them_du_an_can_giam_sat()
        {


            DataTable data = new DataTable();

            try
            {

                string truyvan = "insert du_an" +
                    "(ma_du_an," +
                    "ten_du_an,ten_san_pham," +
                    "don_vi_tinh,ngay_cap_nhat_bao_cao," +
                    "so_luong_san_pham_ban_dau," +
                    "so_luong_san_pham_hao_hut," +
                    "so_luong_san_pham_hao_hut_quy_doi_ra_tien," +
                    "nguyen_nhan_hao_hut," +
                    "so_luong_san_pham_con_lai) " +
                    "values('" + textbox_Giam_sat_Ma_du_an.Text + "'," +
                    "N'" + textbox_Giam_sat_Ten_du_an.Text + "'," +
                    "N'" + textbox_Giam_sat_Ten_san_pham.Text + "'," +
                    "N'" + textbox_Giam_sat_Don_vi_tinh.Text + "'," +
                    "N'" + textbox_Giam_sat_ngay_cap_nhat_bao_cao.Text + "'," +
                    "" + UInt64.Parse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text) + "," +
                    "" + UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text) + "," +
                    "" + UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.Text) + "," +
                    "N'" + textbox_Giam_sat_Nguyen_nhan_hao_hut.Text + "'," +
                    "" + UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_con_lai.Text) + ")";


                using (SqlConnection conection = new SqlConnection(chuoiketnoi))
                {
                    conection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                    adapter.Fill(data);

                    conection.Close();

                    listview_Giam_sat_du_an.ItemsSource = data.DefaultView;


                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return data;

        }



        public DataTable Sua_du_an_can_giam_sat()
        {




            DataTable data = new DataTable();

            try
            {

                string truyvan = "update du_an set  ma_du_an = N'" + textbox_Giam_sat_Ma_du_an.Text + "'," +
               "ten_du_an = N'" + textbox_Giam_sat_Ten_du_an.Text + "'," +
               "ten_san_pham = N'" + textbox_Giam_sat_Ten_san_pham.Text + "', " +
               "don_vi_tinh = N'" + textbox_Giam_sat_Don_vi_tinh.Text + "'," +
               "ngay_cap_nhat_bao_cao = N'" + textbox_Giam_sat_ngay_cap_nhat_bao_cao.Text + "'," +
               "so_luong_san_pham_ban_dau = " + UInt64.Parse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text) + "," +
               "so_luong_san_pham_hao_hut = " + UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text) + "," +
               "so_luong_san_pham_hao_hut_quy_doi_ra_tien = " + UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.Text) + "," +
               "nguyen_nhan_hao_hut = N'" + textbox_Giam_sat_Nguyen_nhan_hao_hut.Text + "'," +
               "so_luong_san_pham_con_lai = " + UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_con_lai.Text) + " where id = " + long.Parse(textbox_Giam_sat_ID.Text) + " ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Giam_sat_du_an.ItemsSource = data.DefaultView;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;
        }




        public DataTable Xoa_Giam_sat_du_an()
        {



            DataTable data = new DataTable();


            try
            {
                string truyvan = "delete du_an where id = "+long.Parse(textbox_Giam_sat_ID.Text)+" ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Giam_sat_du_an.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;
        }


        public DataTable timkiem_Giam_sat_du_an()
        {


            DataTable data = new DataTable();


            try
            {
                string truyvan = "select * from du_an where ma_du_an like '%" + textbox_Giam_sat_du_an_Tim_kiem.Text + "%' or ten_du_an like N'%" + textbox_Giam_sat_du_an_Tim_kiem.Text + "%' or ngay_cap_nhat_bao_cao like N'%" + textbox_Giam_sat_du_an_Tim_kiem.Text + "%' ";

                SqlConnection conection = new SqlConnection(chuoiketnoi);
                conection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(truyvan, conection);
                adapter.Fill(data);

                conection.Close();

                listview_Giam_sat_du_an.ItemsSource = data.DefaultView;



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            return data;


        }








        public void mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Giam_sat_du_an()
        {


            textbox_Giam_sat_Ma_du_an.IsReadOnly = false;


            textbox_Giam_sat_Ten_du_an.IsReadOnly = false;
            textbox_Giam_sat_Ten_san_pham.IsReadOnly = false;
            textbox_Giam_sat_Don_vi_tinh.IsReadOnly = false;
            textbox_Giam_sat_ngay_cap_nhat_bao_cao.IsReadOnly = false;
            textbox_Giam_sat_So_luong_san_pham_ban_dau.IsReadOnly = false;
            textbox_Giam_sat_so_luong_san_pham_hao_hut.IsReadOnly = false;
            textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.IsReadOnly = false;
            textbox_Giam_sat_Nguyen_nhan_hao_hut.IsReadOnly = false;
            textbox_Giam_sat_so_luong_san_pham_con_lai.IsReadOnly = false;

            button_Giam_sat_du_an_Luu.Background = Brushes.Transparent;
            button_Giam_sat_du_an_Huy.Background = Brushes.Transparent;

            button_Giam_sat_du_an_Luu.IsEnabled = true;
            button_Giam_sat_du_an_Huy.IsEnabled = true;

            button_Giam_sat_du_an_Luu.Opacity = 1;
            button_Giam_sat_du_an_Huy.Opacity = 1;

            button_Giam_sat_du_an_Them.Background = Brushes.DarkSlateGray;
            button_Giam_sat_du_an_Sua.Background = Brushes.DarkSlateGray;
            button_Giam_sat_du_an_Xoa.Background = Brushes.DarkSlateGray;

            button_Giam_sat_du_an_Them.IsEnabled = false;
            button_Giam_sat_du_an_Sua.IsEnabled = false;
            button_Giam_sat_du_an_Xoa.IsEnabled = false;

            button_Giam_sat_du_an_Them.Opacity = 0.5;
            button_Giam_sat_du_an_Sua.Opacity = 0.5;
            button_Giam_sat_du_an_Xoa.Opacity = 0.5;

        }





        public void dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Giam_sat_du_an()
        {


            textbox_Giam_sat_Ma_du_an.IsReadOnly = true;
            textbox_Giam_sat_Ten_du_an.IsReadOnly = true;
            textbox_Giam_sat_Ten_san_pham.IsReadOnly = true;
            textbox_Giam_sat_Don_vi_tinh.IsReadOnly = true;
            textbox_Giam_sat_ngay_cap_nhat_bao_cao.IsReadOnly = true;
            textbox_Giam_sat_So_luong_san_pham_ban_dau.IsReadOnly = true;
            textbox_Giam_sat_so_luong_san_pham_hao_hut.IsReadOnly = true;
            textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.IsReadOnly = true;
            textbox_Giam_sat_Nguyen_nhan_hao_hut.IsReadOnly = true;
            textbox_Giam_sat_so_luong_san_pham_con_lai.IsReadOnly = true;

            button_Giam_sat_du_an_Luu.Background = Brushes.DarkSlateGray;
            button_Giam_sat_du_an_Huy.Background = Brushes.DarkSlateGray;

            button_Giam_sat_du_an_Luu.IsEnabled = false;
            button_Giam_sat_du_an_Huy.IsEnabled = false;

            button_Giam_sat_du_an_Luu.Opacity = 0.5;
            button_Giam_sat_du_an_Huy.Opacity = 0.5;

            button_Giam_sat_du_an_Them.Background = Brushes.Transparent;
            button_Giam_sat_du_an_Sua.Background = Brushes.Transparent;
            button_Giam_sat_du_an_Xoa.Background = Brushes.Transparent;

            button_Giam_sat_du_an_Them.IsEnabled = true;
            button_Giam_sat_du_an_Sua.IsEnabled = true;
            button_Giam_sat_du_an_Xoa.IsEnabled = true;

            button_Giam_sat_du_an_Them.Opacity = 1;
            button_Giam_sat_du_an_Sua.Opacity = 1;
            button_Giam_sat_du_an_Xoa.Opacity = 1;


        }


        public bool textIsnotNull_Giam_sat_du_an()
        {

            if (string.IsNullOrEmpty(textbox_Giam_sat_Ma_du_an.Text))
            {
                MessageBox.Show("'Mã dự án' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_Giam_sat_Ma_du_an.Focus();

                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_Giam_sat_Ten_du_an.Text))
            {
                MessageBox.Show("'Tên dự án' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_Giam_sat_Ten_du_an.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_Giam_sat_Ten_san_pham.Text))
            {

                MessageBox.Show("'Tên sản phẩm' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_Giam_sat_Ten_san_pham.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_Giam_sat_Don_vi_tinh.Text))
            {

                MessageBox.Show("'Đơn vị tính' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_Giam_sat_Don_vi_tinh.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_Giam_sat_ngay_cap_nhat_bao_cao.Text))
            {
                MessageBox.Show("'Ngày cập nhật báo cáo' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_Giam_sat_ngay_cap_nhat_bao_cao.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text))
            {

                MessageBox.Show("'Số lượng sản phẩm ban đầu' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);
                textbox_Giam_sat_So_luong_san_pham_ban_dau.Focus();

                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text))
            {
                MessageBox.Show("'Số lượng sản phẩm hao hụt' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_Giam_sat_so_luong_san_pham_hao_hut.Focus();
                return false;
            }
            else

            if (string.IsNullOrEmpty(textbox_Giam_sat_Nguyen_nhan_hao_hut.Text))
            {
                MessageBox.Show("'Nguyên nhân hao hụt' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_Giam_sat_so_luong_san_pham_hao_hut.Focus();
                return false;
            }

            else
            if (string.IsNullOrEmpty(textbox_Giam_sat_so_luong_san_pham_con_lai.Text))
            {
                MessageBox.Show("'Số lượng sản phẩm còn lại' không được để trống !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Warning);

                textbox_Giam_sat_so_luong_san_pham_con_lai.Focus();
                return false;
            }

            return true;
        }


        public void Giam_sat_du_an_Lam_trang_textbox()
        {

            textbox_Giam_sat_Ma_du_an.Text = null;
            textbox_Giam_sat_Ten_du_an.Text = null;
            textbox_Giam_sat_Ten_san_pham.Text = null;
            textbox_Giam_sat_Don_vi_tinh.Text = null;
            textbox_Giam_sat_ngay_cap_nhat_bao_cao.Text = null;
            textbox_Giam_sat_so_luong_san_pham_hao_hut.Text = null;
            textbox_Giam_sat_So_luong_san_pham_ban_dau.Text = null;
            textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.Text = null;
            textbox_Giam_sat_Nguyen_nhan_hao_hut.Text = null;
            textbox_Giam_sat_so_luong_san_pham_con_lai.Text = null;
            textbox_Giam_sat_ID.Text = null;


        }


        public void binding_to_textbox_giam_sat_du_an()
        {

            Binding ma_du_an = new Binding();
            ma_du_an.Mode = BindingMode.OneWay;
            Binding ten_du_an = new Binding();
            ten_du_an.Mode = BindingMode.OneWay;
            Binding ten_san_pham = new Binding();
            ten_san_pham.Mode = BindingMode.OneWay;
            Binding don_vi_tinh = new Binding();
            don_vi_tinh.Mode = BindingMode.OneWay;
            Binding ngay_cap_nhat_bao_cao = new Binding();
            ngay_cap_nhat_bao_cao.Mode = BindingMode.OneWay;
            Binding so_luong_san_pham_ban_dau = new Binding();
            so_luong_san_pham_ban_dau.Mode = BindingMode.OneWay;
            Binding so_luong_san_pham_hao_hut = new Binding();
            so_luong_san_pham_hao_hut.Mode = BindingMode.OneWay;
            Binding so_luong_san_pham_hao_hut_quy_doi_ra_tien = new Binding();
            so_luong_san_pham_hao_hut_quy_doi_ra_tien.Mode = BindingMode.OneWay;
            Binding nguyen_nhan_hao_hut = new Binding();
            nguyen_nhan_hao_hut.Mode = BindingMode.OneWay;
            Binding so_luong_san_pham_con_lai = new Binding();
            so_luong_san_pham_con_lai.Mode = BindingMode.OneWay;
            Binding id = new Binding();
            id.Mode = BindingMode.OneWay;


            // The source
            ma_du_an.Path = new PropertyPath("SelectedValue.[ma_du_an]");
            ma_du_an.ElementName = "listview_Giam_sat_du_an";
            ten_du_an.Path = new PropertyPath("SelectedValue.[ten_du_an]");
            ten_du_an.ElementName = "listview_Giam_sat_du_an";
            ten_san_pham.Path = new PropertyPath("SelectedValue.[ ten_san_pham]");
            ten_san_pham.ElementName = "listview_Giam_sat_du_an";
            don_vi_tinh.Path = new PropertyPath("SelectedValue.[don_vi_tinh]");
            don_vi_tinh.ElementName = "listview_Giam_sat_du_an";
            ngay_cap_nhat_bao_cao.Path = new PropertyPath("SelectedValue.[ngay_cap_nhat_bao_cao]");
            ngay_cap_nhat_bao_cao.ElementName = "listview_Giam_sat_du_an";
            so_luong_san_pham_ban_dau.Path = new PropertyPath("SelectedValue.[ so_luong_san_pham_ban_dau]");
            so_luong_san_pham_ban_dau.ElementName = "listview_Giam_sat_du_an";
            so_luong_san_pham_hao_hut.Path = new PropertyPath("SelectedValue.[so_luong_san_pham_hao_hut]");
            so_luong_san_pham_hao_hut.ElementName = "listview_Giam_sat_du_an";
            so_luong_san_pham_hao_hut_quy_doi_ra_tien.Path = new PropertyPath("SelectedValue.[so_luong_san_pham_hao_hut_quy_doi_ra_tien]");
            so_luong_san_pham_hao_hut_quy_doi_ra_tien.ElementName = "listview_Giam_sat_du_an";
            nguyen_nhan_hao_hut.Path = new PropertyPath("SelectedValue.[nguyen_nhan_hao_hut]");
            nguyen_nhan_hao_hut.ElementName = "listview_Giam_sat_du_an";
            so_luong_san_pham_con_lai.Path = new PropertyPath("SelectedValue.[so_luong_san_pham_con_lai]");
            so_luong_san_pham_con_lai.ElementName = "listview_Giam_sat_du_an";
            id.Path = new PropertyPath("SelectedValue.[id]");
            id.ElementName = "listview_Giam_sat_du_an";


            // The target
            textbox_Giam_sat_Ma_du_an.SetBinding(TextBox.TextProperty, ma_du_an);
            textbox_Giam_sat_Ten_du_an.SetBinding(TextBox.TextProperty, ten_du_an);
            textbox_Giam_sat_Ten_san_pham.SetBinding(TextBox.TextProperty, ten_du_an);
            textbox_Giam_sat_Don_vi_tinh.SetBinding(TextBox.TextProperty, don_vi_tinh);
            textbox_Giam_sat_ngay_cap_nhat_bao_cao.SetBinding(TextBox.TextProperty, ngay_cap_nhat_bao_cao);
            textbox_Giam_sat_So_luong_san_pham_ban_dau.SetBinding(TextBox.TextProperty, so_luong_san_pham_ban_dau);
            textbox_Giam_sat_so_luong_san_pham_hao_hut.SetBinding(TextBox.TextProperty, so_luong_san_pham_hao_hut);
            textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.SetBinding(TextBox.TextProperty, so_luong_san_pham_hao_hut_quy_doi_ra_tien);
            textbox_Giam_sat_Nguyen_nhan_hao_hut.SetBinding(TextBox.TextProperty, nguyen_nhan_hao_hut);
            textbox_Giam_sat_so_luong_san_pham_con_lai.SetBinding(TextBox.TextProperty, so_luong_san_pham_con_lai);
            textbox_Giam_sat_ID.SetBinding(TextBox.TextProperty, id);


        }




        private void button_Giam_sat_du_an_Them_Click(object sender, RoutedEventArgs e)
        {
            mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Giam_sat_du_an();

            Giam_sat_du_an_Lam_trang_textbox();
            flag = "Thêm giám sát";



            button_Giam_sat_du_an_Them.BorderBrush = Brushes.DarkGoldenrod;
            button_Giam_sat_du_an_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Huy.BorderBrush = Brushes.LightSkyBlue;
        }

        private void button_Giam_sat_du_an_Sua_Click(object sender, RoutedEventArgs e)
        {
            flag = "Sửa giám sát";

            button_Giam_sat_du_an_Them.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Sua.BorderBrush = Brushes.DarkGoldenrod;
            button_Giam_sat_du_an_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Huy.BorderBrush = Brushes.LightSkyBlue;

           
        }

        private void button_Giam_sat_du_an_Xoa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_Giam_sat_Ma_du_an.Text))
                MessageBox.Show("Hãy chọn đối tượng để xóa !", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    Xoa_Giam_sat_du_an();
                    danh_sach_du_an_can_Giam_sat();

                    button_Giam_sat_du_an_Them.BorderBrush = Brushes.LightSkyBlue;
                    button_Giam_sat_du_an_Sua.BorderBrush = Brushes.LightSkyBlue;
                    button_Giam_sat_du_an_Xoa.BorderBrush = Brushes.DarkGoldenrod;
                    button_Giam_sat_du_an_Luu.BorderBrush = Brushes.LightSkyBlue;
                    button_Giam_sat_du_an_Huy.BorderBrush = Brushes.LightSkyBlue;

                    

                }

               





            }
        }

        private void button_Giam_sat_du_an_Luu_Click(object sender, RoutedEventArgs e)
        {

            if (textIsnotNull_Giam_sat_du_an())
            {

                if (flag == "Thêm giám sát")
                {

                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Giam_sat_du_an();
                    Them_du_an_can_giam_sat();

                }




                if (flag == "Sửa giám sát")
                {

                    Sua_du_an_can_giam_sat();
                    dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Giam_sat_du_an();
                }


                button_Giam_sat_du_an_Them.BorderBrush = Brushes.LightSkyBlue;
                button_Giam_sat_du_an_Sua.BorderBrush = Brushes.LightSkyBlue;
                button_Giam_sat_du_an_Xoa.BorderBrush = Brushes.LightSkyBlue;
                button_Giam_sat_du_an_Luu.BorderBrush = Brushes.DarkGoldenrod;
                button_Giam_sat_du_an_Huy.BorderBrush = Brushes.LightSkyBlue;

            }









            danh_sach_du_an_can_Giam_sat();
            binding_to_textbox_giam_sat_du_an();


        }

        private void button_Giam_sat_du_an_Huy_Click(object sender, RoutedEventArgs e)
        {


            dong_textbox_va_Luu_Huy_Mo_Them_Sua_Xoa_Giam_sat_du_an();


            binding_to_textbox_giam_sat_du_an();
            flag = "Hủy giám sát";

            button_Giam_sat_du_an_Them.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Sua.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Xoa.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Luu.BorderBrush = Brushes.LightSkyBlue;
            button_Giam_sat_du_an_Huy.BorderBrush = Brushes.DarkGoldenrod;


        }




        private void textbox_Giam_sat_du_an_Tim_kiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timkiem_Giam_sat_du_an();
        }




        private void listview_Giam_sat_du_an_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == "Sửa giám sát") mo_textbox_va_Luu_Huy_Dong_Them_Sua_Xoa_Giam_sat_du_an();
            textbox_Giam_sat_Ma_du_an.Focus();
        }


        private void listview_Giam_sat_du_an_MouseEnter(object sender, MouseEventArgs e)
        {
            listview_Giam_sat_du_an.Foreground = Brushes.DarkGoldenrod;
        }

        private void listview_Giam_sat_du_an_MouseLeave(object sender, MouseEventArgs e)
        {
            listview_Giam_sat_du_an.Foreground = Brushes.DarkBlue;
        }

        private void listview_Giam_sat_du_an_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            binding_to_textbox_giam_sat_du_an();
        }











        //*****************************************************************










        //************Khu vực chức năng đặc biệt*********************************





        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            form_Thu_Vao form_Thu_Vao = new form_Thu_Vao();
            form_Thu_Vao.Show();
        }

        private void textblock_Chi_Ra_MouseDown(object sender, MouseButtonEventArgs e)
        {
            form_Chi_Ra form_Chi_Ra = new form_Chi_Ra();
            form_Chi_Ra.Show();
        }




        public DataTable Thu_vao()
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

                    listview_quan_ly_thong_tin_doi_tac.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }





            return data;
        }




        public long Tong_so_tien_thu_vao()
        {

            int so_hang = Thu_vao().Rows.Count;
            int i;
            long S = 0;
            for (i = 0; i < so_hang; i++)
            {
                S = S + long.Parse(Thu_vao().Rows[i]["so_tien"].ToString());


            }

            textbox_quan_ly_quy_dau_tu_Thu_Vao.Text = S.ToString();

            return S;
        }


        public long Tong_so_tien_chi_ra()
        {
            int so_hang = chi_ra().Rows.Count;
            int i;
            long S = 0;
            for (i = 0; i < so_hang; i++)
            {
                S = S + long.Parse(chi_ra().Rows[i]["so_tien"].ToString());


            }

            textbox_quan_ly_quy_dau_tu_Chi_Ra.Text = S.ToString();


            return S;
        }


        public UInt64 Tong_so_von_du_an_da_trien_khai()
        {

            int so_hang = thong_tin_du_an_da_trien_khai().Rows.Count;
            int i;
            UInt64 tong_so_von = 0;


            for (i = 0; i < so_hang; i++)
            {
                tong_so_von = tong_so_von + UInt64.Parse(thong_tin_du_an_da_trien_khai().Rows[i]["so_von"].ToString());


            }

            textbox_thong_tin_du_an_da_trien_khai_Tong_So_von.Text = tong_so_von.ToString();

            return tong_so_von;

        }




        public UInt64 Tong_loi_nhuan_du_an_da_trien_khai()
        {

            int so_hang = thong_tin_du_an_da_trien_khai().Rows.Count;
            int i;

            UInt64 tong_loi_nhuan = 0;

            for (i = 0; i < so_hang; i++)
            {

                tong_loi_nhuan = tong_loi_nhuan + UInt64.Parse(thong_tin_du_an_da_trien_khai().Rows[i]["loi_nhuan"].ToString());

            }


            textbox_thong_tin_du_an_da_trien_khai_Tong_loi_nhuan.Text = tong_loi_nhuan.ToString();
            return tong_loi_nhuan;

        }



        public UInt64 Tong_so_von_du_kien_Ke_hoach_du_an_moi()
        {

            int so_hang = xay_dung_ke_hoach_cho_du_an_moi().Rows.Count;
            int i;

            UInt64 tong_so_von_du_kien = 0;

            for (i = 0; i < so_hang; i++)
            {

                tong_so_von_du_kien = tong_so_von_du_kien + UInt64.Parse(xay_dung_ke_hoach_cho_du_an_moi().Rows[i]["so_von_du_kien"].ToString());

            }


            textbox_Ke_hoach_du_an_moi_Tong_So_von_du_kien.Text = tong_so_von_du_kien.ToString();
            return tong_so_von_du_kien;

        }




        public UInt64 Tong_loi_nhuan_du_kien_Ke_hoach_du_an_moi()
        {

            int so_hang = xay_dung_ke_hoach_cho_du_an_moi().Rows.Count;
            int i;

            UInt64 tong_loi_nhuan_du_kien = 0;

            for (i = 0; i < so_hang; i++)
            {

                tong_loi_nhuan_du_kien = tong_loi_nhuan_du_kien + UInt64.Parse(xay_dung_ke_hoach_cho_du_an_moi().Rows[i]["loi_nhuan_du_kien"].ToString());

            }


            textbox_Ke_hoach_du_an_moi_Tong_loi_nhuan_du_kien.Text = tong_loi_nhuan_du_kien.ToString();
            return tong_loi_nhuan_du_kien;

        }


        

        public void tong_so_du_an_da_va_dang_cho_duoc_trien_khai() 
        {
            textbox_thong_ke_du_an_da_trien_khai_Tong_so_du_an_da_trien_khai.Text = thong_tin_du_an_da_trien_khai().Rows.Count.ToString();
            textbox_Ke_hoach_du_an_moi_Tong_so_du_an_dang_cho_trien_khai.Text = xay_dung_ke_hoach_cho_du_an_moi().Rows.Count.ToString(); 




        }












        public DataTable chi_ra()
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

                    listview_quan_ly_thong_tin_doi_tac.ItemsSource = data.DefaultView;


                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }





            return data;
        }






        private void textbox_du_an_da_trien_khai_Doanh_thu_TextChanged(object sender, TextChangedEventArgs e)
        {
            UInt64 ketqua;

            if (UInt64.TryParse(textbox_du_an_da_trien_khai_Loi_nhuan.Text, out ketqua) == true & UInt64.TryParse(textbox_du_an_da_trien_khai_So_von.Text, out ketqua) == true & flag == "Thêm")
            {
              
                    textbox_du_an_da_trien_khai_Doanh_thu.Text = (UInt64.Parse(textbox_du_an_da_trien_khai_Loi_nhuan.Text) + UInt64.Parse(textbox_du_an_da_trien_khai_So_von.Text)).ToString();
                
                
                
            }

            if (UInt64.TryParse(textbox_du_an_da_trien_khai_Loi_nhuan.Text, out ketqua) == true & UInt64.TryParse(textbox_du_an_da_trien_khai_So_von.Text, out ketqua) == true & flag == "Sửa")
            {
              
                
                    textbox_du_an_da_trien_khai_Doanh_thu.Text = (UInt64.Parse(textbox_du_an_da_trien_khai_Loi_nhuan.Text) + UInt64.Parse(textbox_du_an_da_trien_khai_So_von.Text)).ToString();
                
            }


        }



        private void textbox_Giam_sat_so_luong_san_pham_con_lai_TextChanged(object sender, TextChangedEventArgs e)
        {
            UInt64 ketqua;
            if (UInt64.TryParse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text, out ketqua) == true & UInt64.TryParse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text, out ketqua) == true & flag=="Thêm giám sát")
            {
                if (UInt64.Parse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text) < UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text)) 
                {

                    MessageBox.Show("số sản phẩm còn lại không thể là số âm ! Hãy xem lại mục 'Số lượng sản phẩm hao hụt' ", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    textbox_Giam_sat_so_luong_san_pham_con_lai.Text = null;
                }
                else 
                {
                    textbox_Giam_sat_so_luong_san_pham_con_lai.Text = (UInt64.Parse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text) - UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text)).ToString();
                }

                



            };



           
            if (UInt64.TryParse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text, out ketqua) == true & UInt64.TryParse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text, out ketqua) == true & flag == "Sửa giám sát")
            {
                if (UInt64.Parse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text) < UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text))
                {

                    MessageBox.Show("số sản phẩm còn lại không thể là số âm ! Hãy xem lại mục 'Số lượng sản phẩm hao hụt' ", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    textbox_Giam_sat_so_luong_san_pham_con_lai.Text = null;
                }
                else
                {
                    textbox_Giam_sat_so_luong_san_pham_con_lai.Text = (UInt64.Parse(textbox_Giam_sat_So_luong_san_pham_ban_dau.Text) - UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut.Text)).ToString();
                }



            };



        }











        private void textbox_du_an_da_trien_khai_So_von_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {
                UInt64 du_an_da_trien_khai_so_von = UInt64.Parse(textbox_du_an_da_trien_khai_So_von.Text);

                string formatted_du_an_da_trien_khai_so_von = string.Format(CultureInfo.InvariantCulture, "{0:N0}", du_an_da_trien_khai_so_von);
                textbox_du_an_da_trien_khai_So_von.ToolTip = formatted_du_an_da_trien_khai_so_von;

            }
            catch (Exception)
            {


            }


        }




        private void textbox_du_an_da_trien_khai_Loi_nhuan_MouseEnter(object sender, MouseEventArgs e)
        {


            try
            {
                UInt64 du_an_da_trien_khai_loi_nhuan = UInt64.Parse(textbox_du_an_da_trien_khai_Loi_nhuan.Text);
                string formatted_du_an_da_trien_khai_loi_nhuan = string.Format(CultureInfo.InvariantCulture, "{0:N0}", du_an_da_trien_khai_loi_nhuan);
                textbox_du_an_da_trien_khai_Loi_nhuan.ToolTip = formatted_du_an_da_trien_khai_loi_nhuan;


            }
            catch (Exception)
            {


            }




        }

        private void textbox_du_an_da_trien_khai_Doanh_thu_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {
                UInt64 du_an_da_trien_khai_doanh_thu = UInt64.Parse(textbox_du_an_da_trien_khai_Doanh_thu.Text);
                string formatted_du_an_da_trien_khai_doanh_thu = string.Format(CultureInfo.InvariantCulture, "{0:N0}", du_an_da_trien_khai_doanh_thu);
                textbox_du_an_da_trien_khai_Doanh_thu.ToolTip = formatted_du_an_da_trien_khai_doanh_thu;


            }
            catch (Exception)
            {


            }


        }

        private void textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 du_an_moi_so_von_du_kien = UInt64.Parse(textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.Text);
                string formatted_du_an_moi_so_von_du_kien = string.Format(CultureInfo.InvariantCulture, "{0:N0}", du_an_moi_so_von_du_kien);
                textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.ToolTip = formatted_du_an_moi_so_von_du_kien;

            }
            catch (Exception)
            {


            }



        }

        private void textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 du_an_moi_loi_nhuan_du_kien = UInt64.Parse(textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.Text);
                string formatted_du_an_moi_loi_nhuan_du_kien = string.Format(CultureInfo.InvariantCulture, "{0:N0}", du_an_moi_loi_nhuan_du_kien);
                textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.ToolTip = formatted_du_an_moi_loi_nhuan_du_kien;
            }
            catch (Exception)
            {


            }


        }

        private void textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 thong_tin_doi_tac_tong_so_tien_da_giao_dich = UInt64.Parse(textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.Text);
                string formatted_thong_tin_doi_tac_tong_so_tien_da_giao_dich = string.Format(CultureInfo.InvariantCulture, "{0:N0}", thong_tin_doi_tac_tong_so_tien_da_giao_dich);
                textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.ToolTip = formatted_thong_tin_doi_tac_tong_so_tien_da_giao_dich;
            }
            catch (Exception)
            {


            }


        }


        private void textbox_quan_ly_quy_dau_tu_Thu_Vao_MouseEnter(object sender, MouseEventArgs e)
        {





            try
            {

                UInt64 quy_dau_tu_thu_vao = UInt64.Parse(textbox_quan_ly_quy_dau_tu_Thu_Vao.Text);
                string formatted_quy_dau_tu_thu_vao = string.Format(CultureInfo.InvariantCulture, "{0:N0}", quy_dau_tu_thu_vao);
                textbox_quan_ly_quy_dau_tu_Thu_Vao.ToolTip = formatted_quy_dau_tu_thu_vao;
            }
            catch (Exception)
            {


            }


        }

        private void textbox_quan_ly_quy_dau_tu_Chi_Ra_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {
                UInt64 quy_dau_tu_chi_ra = UInt64.Parse(textbox_quan_ly_quy_dau_tu_Chi_Ra.Text);
                string formatted_quy_dau_tu_chi_ra = string.Format(CultureInfo.InvariantCulture, "{0:N0}", quy_dau_tu_chi_ra);
                textbox_quan_ly_quy_dau_tu_Chi_Ra.ToolTip = formatted_quy_dau_tu_chi_ra;

            }
            catch (Exception)
            {


            }

        }



        private void textbox_quan_ly_quy_dau_tu_So_du_hien_tai_MouseEnter(object sender, MouseEventArgs e)
        {


            try
            {

                UInt64 quy_dau_tu_so_du_hien_tai = UInt64.Parse(textbox_quan_ly_quy_dau_tu_So_du_hien_tai.Text);
                string formatted_quy_dau_tu_so_du_hien_tai = string.Format(CultureInfo.InvariantCulture, "{0:N0}", quy_dau_tu_so_du_hien_tai);
                textbox_quan_ly_quy_dau_tu_So_du_hien_tai.ToolTip = formatted_quy_dau_tu_so_du_hien_tai;

            }
            catch (Exception)
            {


            }

        }






        private void textbox_thong_tin_du_an_da_trien_khai_Tong_So_von_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 tong_So_von = UInt64.Parse(textbox_thong_tin_du_an_da_trien_khai_Tong_So_von.Text);
                string formatted_Tong_so_von = string.Format(CultureInfo.InvariantCulture, "{0:N0}", tong_So_von);
                textbox_thong_tin_du_an_da_trien_khai_Tong_So_von.ToolTip = formatted_Tong_so_von;

            }
            catch (Exception)
            {


            }


        }

        private void textbox_thong_tin_du_an_da_trien_khai_Tong_loi_nhuan_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 tong_loi_nhuan = UInt64.Parse(textbox_thong_tin_du_an_da_trien_khai_Tong_loi_nhuan.Text);
                string formatted_Tong_loi_nhuan = string.Format(CultureInfo.InvariantCulture, "{0:N0}", tong_loi_nhuan);
                textbox_thong_tin_du_an_da_trien_khai_Tong_loi_nhuan.ToolTip = formatted_Tong_loi_nhuan;

            }
            catch (Exception)
            {


            }

        }

        private void textbox_thong_ke_du_an_da_trien_khai_Tong_doanh_thu_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 tong_doanh_thu = UInt64.Parse(textbox_thong_ke_du_an_da_trien_khai_Tong_doanh_thu.Text);
                string formatted_tong_doanh_thu = string.Format(CultureInfo.InvariantCulture, "{0:N0}", tong_doanh_thu);
                textbox_thong_ke_du_an_da_trien_khai_Tong_doanh_thu.ToolTip = formatted_tong_doanh_thu;

            }
            catch (Exception)
            {


            }

        }

        private void textbox_Ke_hoach_du_an_moi_Tong_So_von_du_kien_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 tong_so_von_du_kien = UInt64.Parse(textbox_Ke_hoach_du_an_moi_Tong_So_von_du_kien.Text);
                string formatted_tong_so_von_du_kien = string.Format(CultureInfo.InvariantCulture, "{0:N0}", tong_so_von_du_kien);
                textbox_Ke_hoach_du_an_moi_Tong_So_von_du_kien.ToolTip = formatted_tong_so_von_du_kien;

            }
            catch (Exception)
            {


            }


        }

        private void textbox_Ke_hoach_du_an_moi_Tong_loi_nhuan_du_kien_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 tong_loi_nhuan_du_kien = UInt64.Parse(textbox_Ke_hoach_du_an_moi_Tong_loi_nhuan_du_kien.Text);
                string formatted_tong_loi_nhuan_du_kien = string.Format(CultureInfo.InvariantCulture, "{0:N0}", tong_loi_nhuan_du_kien);
                textbox_Ke_hoach_du_an_moi_Tong_loi_nhuan_du_kien.ToolTip = formatted_tong_loi_nhuan_du_kien;

            }
            catch (Exception)
            {


            }

        }




        private void textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien_MouseEnter(object sender, MouseEventArgs e)
        {

            try
            {

                UInt64 So_luong_san_pham_hao_hut_doi_ra_tien = UInt64.Parse(textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.Text);
                string formatted_So_luong_san_pham_hao_hut_doi_ra_tien = string.Format(CultureInfo.InvariantCulture, "{0:N0}", So_luong_san_pham_hao_hut_doi_ra_tien);
                textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.ToolTip = formatted_So_luong_san_pham_hao_hut_doi_ra_tien;

            }
            catch (Exception)
            {


            }

        }

















        private void textbox_du_an_da_trien_khai_Tim_kiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timkiem_du_an_da_trien_khai();
        }

        private void textbox_du_an_moi_Tim_kiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timkiem_ke_hoach_du_an_moi();

        }

        private void textbox_quan_ly_thong_tin_doi_tac_Tim_kiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            timkiem_thong_tin_doi_tac();
        }































        private void gui_Bao_cao_du_an_da_trien_khai_Click(object sender, RoutedEventArgs e)
        {
            string du_an_da_Trien_khai_Ma_du_an = string.Format("[ {0} ] [ Mã dự án ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_Ma_du_an.Text;
            string du_an_da_Trien_khai_Ten_du_an = string.Format("[ {0} ] [ Tên dự án ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_Ten_du_an.Text;
            string du_an_da_Trien_khai_Ngay_khoi_cong = string.Format("[ {0} ] [ Ngày khởi công ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_Ngay_khoi_cong.Text;
            string du_an_da_Trien_khai_So_san_pham = string.Format("[ {0} ] [ Số sản phẩm ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_So_san_pham.Text;
            string du_an_da_Trien_khai_Ten_san_pham = string.Format("[ {0} ] [ Tên sản phẩm ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_Ten_san_pham.Text;
            string du_an_da_Trien_khai_So_von = string.Format("[ {0} ] [ Số vốn ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_So_von.Text;
            string du_an_da_Trien_khai_Loi_nhuan = string.Format("[ {0} ] [ Lợi nhuận ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_Loi_nhuan.Text;
            string du_an_da_Trien_khai_Doanh_thu = string.Format("[ {0} ] [ Doanh thu ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_Doanh_thu.Text;
            string du_an_da_Trien_khai_Ngay_hoan_tat = string.Format("[ {0} ] [ Ngày hoàn tất ]  :  ", tabItem_Thong_tin_du_an_da_trien_khai.Header) + textbox_du_an_da_trien_khai_ngay_Hoan_tat.Text;
            string tieuDe = tabItem_Thong_tin_du_an_da_trien_khai.Header.ToString();






            form_Gui_bao_cao_Bang_email gui_Bao_Cao_Bang_Email = new form_Gui_bao_cao_Bang_email();
            gui_Bao_Cao_Bang_Email.Show();
            gui_Bao_Cao_Bang_Email.hien_thi_thong_tin_can_gui(du_an_da_Trien_khai_Ma_du_an, du_an_da_Trien_khai_Ten_du_an, du_an_da_Trien_khai_Ngay_khoi_cong, du_an_da_Trien_khai_Ngay_hoan_tat, du_an_da_Trien_khai_So_san_pham, du_an_da_Trien_khai_Ten_san_pham, du_an_da_Trien_khai_So_von, du_an_da_Trien_khai_Loi_nhuan, du_an_da_Trien_khai_Doanh_thu, null, null, tieuDe);
        }

        private void gui_Bao_cao_ke_hoach_du_an_moi_Click(object sender, RoutedEventArgs e)
        {

            string du_an_Moi_Ma_du_an = string.Format("[ {0} ] [ Mã dự án ]  :  ", tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header) + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ma_du_an.Text;
            string du_an_Moi_Ten_du_an = string.Format("[ {0} ] [ Tên dự án ]  :  ", tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header) + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_du_an.Text;
            string du_an_Moi_Ngay_khoi_cong_du_kien = string.Format("[ {0} ] [ Ngày khởi công dự kiến ]  :  ", tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header) + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ngay_khoi_cong_du_kien.Text;
            string so_san_pham_du_tinh = string.Format("[ {0} ] [ Số sản phẩm dự tính ]  :  ", tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header) + textbox_xay_dung_ke_hoach_cho_du_an_moi_So_san_pham_du_tinh.Text;
            string ten_san_pham = string.Format("[ {0} ] [ Tên sản phẩm ]  :  ", tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header) + textbox_xay_dung_ke_hoach_cho_du_an_moi_Ten_san_pham.Text;
            string so_von_du_kien = string.Format("[ {0} ] [ Số vốn dự kiến ]  :  ", tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header) + textbox_xay_dung_ke_hoach_cho_du_an_moi_So_von_du_kien.Text;
            string loi_nhuan_du_kien = string.Format("[ {0} ] [ Lợi nhuận dự kiến ]  :  ", tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header) + textbox_xay_dung_ke_hoach_cho_du_an_moi_Loi_nhuan_du_kien.Text;
            string tieuDe = tabItem_xay_dung_ke_hoach_cho_du_an_moi.Header.ToString();







            form_Gui_bao_cao_Bang_email gui_Bao_Cao_Bang_Email = new form_Gui_bao_cao_Bang_email();
            gui_Bao_Cao_Bang_Email.Show();
            gui_Bao_Cao_Bang_Email.hien_thi_thong_tin_can_gui(du_an_Moi_Ma_du_an, du_an_Moi_Ten_du_an, du_an_Moi_Ngay_khoi_cong_du_kien, so_san_pham_du_tinh, ten_san_pham, so_von_du_kien, loi_nhuan_du_kien, null, null, null, null, tieuDe);






        }

        private void gui_Bao_cao_thong_tin_doi_tac_Click(object sender, RoutedEventArgs e)
        {

            string doi_tac_Ma_doi_tac = string.Format("[ {0} ] [ Mã đối tác ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Ma_doi_tac.Text;
            string doi_tac_ten_doi_tac = string.Format("[ {0} ] [ Tên đối tác ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Ten_doi_tac.Text;
            string doi_tac_Nghe_nghiep = string.Format("[ {0} ] [ Nghề nghiệp ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Nghe_nghiep.Text;
            string doi_tac_So_dien_thoai = string.Format("[ {0} ] [ Số điện thoại ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_So_dien_thoai.Text;
            string doi_tac_Ngay_sinh = string.Format("[ {0} ] [ Ngày sinh ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Ngay_sinh.Text;
            string doi_tac_Dia_chi = string.Format("[ {0} ] [ Địa chỉ ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Dia_chi.Text;
            string doi_tac_Ngay_bat_dau_hop_tac = string.Format("[ {0} ] [ Ngày bắt đầu hợp tác ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Ngay_bat_dau_hop_tac.Text;
            string dong_vai_tro = string.Format("[ {0} ] [ Đóng vai trò ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Dong_vai_tro.Text;
            string ti_le_gop_von = string.Format("[ {0} ] [ Tỉ lệ góp vốn(%) ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Ti_le_gop_von.Text;
            string ti_le_phan_phoi_co_tuc = string.Format("[ {0} ] [ Tỉ lệ cổ tức được phân phối(%) ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Ti_le_phan_phoi_co_tuc.Text;
            string tong_so_tien_da_giao_dich = string.Format("[ {0} ] [ Số tiền đã giao dịch ]  :  ", tabItem_quan_ly_thong_tin_doi_tac.Header) + textbox_quan_ly_thong_tin_doi_tac_Tong_so_tien_da_giao_dich.Text;






            string tieuDe = tabItem_quan_ly_thong_tin_doi_tac.Header.ToString();







            form_Gui_bao_cao_Bang_email gui_Bao_Cao_Bang_Email = new form_Gui_bao_cao_Bang_email();
            gui_Bao_Cao_Bang_Email.Show();
            gui_Bao_Cao_Bang_Email.hien_thi_thong_tin_can_gui(doi_tac_Ma_doi_tac, doi_tac_ten_doi_tac, doi_tac_Nghe_nghiep, doi_tac_So_dien_thoai, doi_tac_Ngay_sinh, doi_tac_Dia_chi, doi_tac_Ngay_bat_dau_hop_tac, dong_vai_tro, ti_le_gop_von, ti_le_phan_phoi_co_tuc, tong_so_tien_da_giao_dich, tieuDe);







        }

        private void gui_Bao_cao_Giam_sat_du_an_Click(object sender, RoutedEventArgs e)
        {
            string giam_sat_Ma_du_an = string.Format("[ {0} ] [ Mã dự án ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_Ma_du_an.Text;
            string giam_sat_Ten_du_an = string.Format("[ {0} ] [ Tên dự án ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_Ten_du_an.Text;
            string giam_sat_Ten_san_pham = string.Format("[ {0} ] [ Tên sản phẩm ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_Ten_san_pham.Text;
            string giam_sat_Don_vi_tinh = string.Format("[ {0} ] [ Đơn vị tính ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_Don_vi_tinh.Text;
            string giam_sat_So_luong_san_pham_ban_dau = string.Format("[ {0} ] [ Số lượng sản phẩm ban đầu ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_So_luong_san_pham_ban_dau.Text;
            string giam_sat_So_luong_san_pham_hao_hut = string.Format("[ {0} ] [ Số lượng sản phẩm hao hụt ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_so_luong_san_pham_hao_hut.Text;
            string giam_sat_So_luong_san_pham_hao_hut_doi_ra_tien = string.Format("[ {0} ] [ Số lượng sản phẩm hao hụt quy đổi ra tiền(VNĐ) ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_so_luong_san_pham_hao_hut_quy_doi_ra_tien.Text;
            string giam_sat_Nguyen_nhan_hao_hut = string.Format("[ {0} ] [ Nguyên nhân hao hụt ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_Nguyen_nhan_hao_hut.Text;
            string giam_sat_So_san_pham_con_lai = string.Format("[ {0} ] [ Số sản phẩm còn lại ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_so_luong_san_pham_con_lai.Text;
            string giam_sat_Ngay_cap_nhat_bao_cao = string.Format("[ {0} ] [ Ngày cập nhật báo cáo ]  :  ", tabitem_giam_sat_du_an.Header) + textbox_Giam_sat_ngay_cap_nhat_bao_cao.Text;
           






            string tieuDe = tabitem_giam_sat_du_an.Header.ToString();







            form_Gui_bao_cao_Bang_email gui_Bao_Cao_Bang_Email = new form_Gui_bao_cao_Bang_email();
            gui_Bao_Cao_Bang_Email.Show();
            gui_Bao_Cao_Bang_Email.hien_thi_thong_tin_can_gui(giam_sat_Ma_du_an, giam_sat_Ten_du_an, giam_sat_Ten_san_pham, giam_sat_Don_vi_tinh, giam_sat_So_luong_san_pham_ban_dau, giam_sat_So_luong_san_pham_hao_hut, giam_sat_So_luong_san_pham_hao_hut_doi_ra_tien, giam_sat_Nguyen_nhan_hao_hut, giam_sat_So_san_pham_con_lai, giam_sat_Ngay_cap_nhat_bao_cao,null, tieuDe);




        }

       
    }
}
