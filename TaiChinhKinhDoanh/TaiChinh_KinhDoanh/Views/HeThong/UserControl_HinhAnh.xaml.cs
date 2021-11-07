using Microsoft.Win32;
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
using TaiChinh_KinhDoanh.Views.PhuTro;

namespace TaiChinh_KinhDoanh.Views.HeThong
{
    /// <summary>
    /// Interaction logic for UserControl_HinhAnh.xaml
    /// </summary>
    public partial class UserControl_HinhAnh : UserControl
    {
        public UserControl_HinhAnh()
        {
            InitializeComponent();


            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

            KetNoiCSDl_HinhNen();

            if(KetNoiCSDL_On_Off().Rows[0]["mode"].ToString() == "on") 
            {
                CheckBox_Su_Dung_Hinh_Nen.IsChecked = true;

                groupBox_HinhNen.Background = Brushes.Transparent;

            }
               
            if (KetNoiCSDL_On_Off().Rows[0]["mode"].ToString() == "off") 
            {
                CheckBox_Su_Dung_Hinh_Nen.IsChecked = false;

                ComboBox_DoiTuong.IsEnabled = false;
                ComboBox_Nguon.IsEnabled = false;
                ComboBox_ImageDemo.IsEnabled = false;
                Button_Thay_Doi.IsEnabled = false;
                groupBox_HinhNen.Background = Brushes.DarkSlateGray;



            }



        }


        string chuoiketnoi;
        string Source;
        OpenFileDialog openFile;
        message_Thuc_Thi_Chon_Anh message_Thuc_Thi_Chon_Anh;
        messageBox_Thuan_Tuy_Thong_Bao nhac_Nho_Chon_Doi_Tuong;
        



        public DataTable KetNoiCSDl_HinhNen()
        {
            DataTable data = new DataTable();
            string truyvan = "select * from hinh_nen";
            SqlConnection connect = new SqlConnection(chuoiketnoi);
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(truyvan,connect);
            adapter.Fill(data);
            connect.Close();
            ComboBox_DoiTuong.ItemsSource = data.DefaultView;
            ComboBox_DoiTuong.DisplayMemberPath = "doi_tuong";
            ComboBox_Nguon.ItemsSource = data.DefaultView;
            ComboBox_Nguon.DisplayMemberPath = "nguon";



            return data;
        
        }



        public DataTable KetNoiCSDL_On_Off() 
        {

            DataTable data = new DataTable();
            string truyvan = "select * from dieu_khien_checkbox_su_dung_hinh_nen";
            SqlConnection connect = new SqlConnection(chuoiketnoi);
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
            adapter.Fill(data);
            connect.Close();
          
            return data;
        }


        public void On_Mode() 
        {
            DataTable data = new DataTable();
            string truyvan = "update dieu_khien_checkbox_su_dung_hinh_nen set mode='on'";
            SqlConnection connect = new SqlConnection(chuoiketnoi);
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
            adapter.Fill(data);
            connect.Close();

        }


        public void Off_Mode()
        {
            DataTable data = new DataTable();
            string truyvan = "update dieu_khien_checkbox_su_dung_hinh_nen set mode='off'";
            SqlConnection connect = new SqlConnection(chuoiketnoi);
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
            adapter.Fill(data);
            connect.Close();

        }

        public void vo_hieu_hoa_che_do_su_dung_hinh_nen() 
        {

            DataTable data = new DataTable();
            string truyvan = "update hinh_nen set nguon = N'Không sử dụng hình nền'";
            SqlConnection connect = new SqlConnection(chuoiketnoi);
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
            adapter.Fill(data);
            connect.Close();


        }


        public void cai_hinh_nen() 
        {
           


        }





        private void ComboBox_DoiTuong_GotFocus(object sender, RoutedEventArgs e)
        {
            int index = ComboBox_DoiTuong.Items.IndexOf(ComboBox_DoiTuong.SelectedValue);
            ComboBox_Nguon.SelectedIndex = index;
        }

        private void ComboBox_DoiTuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox_ImageDemo.IsDropDownOpen = true;
            
            
        }


       

        private void Button_Thay_Doi_Click(object sender, RoutedEventArgs e)
        {

            openFile = new OpenFileDialog();
            openFile.ShowDialog();
            Source = openFile.FileName;

            message_Thuc_Thi_Chon_Anh = new message_Thuc_Thi_Chon_Anh();
            nhac_Nho_Chon_Doi_Tuong = new messageBox_Thuan_Tuy_Thong_Bao();
            if (ComboBox_DoiTuong.SelectedValue != null) 
            {
                message_Thuc_Thi_Chon_Anh.Show_Message("Bạn có muốn chọn '" + openFile.SafeFileName + "' làm hình nền cho " + ComboBox_DoiTuong.Text + " không ?");
            }
            else 
            {

                nhac_Nho_Chon_Doi_Tuong.Show_Message("Hãy chọn đối tượng cho hình nền ở mục 'Đối tượng' !");
            }

            message_Thuc_Thi_Chon_Anh.nut_Co += Message_Thuc_Thi_Chon_Anh_nut_Co;
            message_Thuc_Thi_Chon_Anh.nut_Khong += Message_Thuc_Thi_Chon_Anh_nut_Khong;
            
            

            

            





            //Tạo thư mục
            ///string path = @"C:\Users\user\OneDrive\Desktop\ok";
            //if (!Directory.Exists(path))
            //{
            // Directory.CreateDirectory(path);
            // }

        }

        private void Message_Thuc_Thi_Chon_Anh_nut_Khong(bool parameter)
        {
            message_Thuc_Thi_Chon_Anh.Close();
        }

        private void Message_Thuc_Thi_Chon_Anh_nut_Co(bool parameter)
        {
            DataTable data = new DataTable();
            string truyvan = "update hinh_nen set nguon = N'" + Source + "' where doi_tuong = N'" + ComboBox_DoiTuong.Text + "' ";
            SqlConnection connect = new SqlConnection(chuoiketnoi);
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
            adapter.Fill(data);
            connect.Close();
            message_Thuc_Thi_Chon_Anh.Close();
        }

       






        private void CheckBox_Su_Dung_Hinh_Nen_Checked(object sender, RoutedEventArgs e)
        {

            On_Mode();

            ComboBox_DoiTuong.IsEnabled = true;
            ComboBox_Nguon.IsEnabled = true;
            ComboBox_ImageDemo.IsEnabled = true;
            Button_Thay_Doi.IsEnabled = true;

            groupBox_HinhNen.Background = Brushes.Transparent;
        }

        private void CheckBox_Su_Dung_Hinh_Nen_Unchecked(object sender, RoutedEventArgs e)
        {
            Off_Mode();
            vo_hieu_hoa_che_do_su_dung_hinh_nen();
            ComboBox_DoiTuong.IsEnabled = false;
            ComboBox_Nguon.IsEnabled = false;
            ComboBox_ImageDemo.IsEnabled = false;
            Button_Thay_Doi.IsEnabled = false;
            groupBox_HinhNen.Background = Brushes.DarkSlateGray;
            
        }

      
    }
}
