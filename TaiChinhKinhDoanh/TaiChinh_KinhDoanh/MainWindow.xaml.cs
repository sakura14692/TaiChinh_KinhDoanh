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
using System.Windows.Threading;
using TaiChinh_KinhDoanh.Views;
using TaiChinh_KinhDoanh.Views.Admin;
using TaiChinh_KinhDoanh.Views.HeThong;
using TaiChinh_KinhDoanh.Views.message_Box;
using TaiChinh_KinhDoanh.Views.PhuTro;
using TaiChinh_KinhDoanh.Views.TrangChu;

namespace TaiChinh_KinhDoanh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
           

            if (!File.Exists(fullpath) )
            {
               
                MessageBox.Show("File hỗ trợ kết nối đến cơ sở dữ liệu không tồn tại ! Hệ thống sẽ tạo File mới trên Desktop,bạn hãy điền thông tin vào file theo mẫu sau : Data Source = tên Server;Initial Catalog = tên cơ sở dữ liệu; Integrated Security = True,sau đó copy đến thư mục chứa chương trình ", "Nhắc nhở",MessageBoxButton.OK,MessageBoxImage.Information);
               

                File.Create(@"C:\Users\user\OneDrive\Desktop\chuoi_ket_noi.txt");



            }
            else
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
               
               if (string.IsNullOrEmpty(doc_file)) 
                {
                    MessageBox.Show("File hỗ trợ kết nối hiện đang trống,bạn hãy tìm file có tên là 'chuoi_ket_noi.txt' và điền thông tin vào file theo mẫu sau : Data Source = tên Server;Initial Catalog = tên cơ sở dữ liệu; Integrated Security = True,sau đó copy đến thư mục chứa chương trình", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
                   

                }


              


            }



            form_DangNhap dangNhap = new form_DangNhap();
            if (ket_noi_den_tat_bat_che_do_bao_mat().Rows[0][0].ToString() == "on") dangNhap.ShowDialog();

            //form_Mo_man mo_Man = new form_Mo_man();
            //mo_Man.ShowDialog();


        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


           

            page_HinhNen page_HinhNen = new page_HinhNen();
            frame_Add_Pages.NavigationService.Navigate(page_HinhNen);
           


           


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

        }




        private void Timer_Tick(object sender, EventArgs e)
        {
            textblock_dong_ho.Text = DateTime.Now.ToString("HH:mm:ss");
            textblock_lich.Text = DateTime.Now.ToString("d");
        }





        
        public string trueName;

        string chuoiketnoi;


      


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
                MessageBox.Show(message,"Cảnh báo",MessageBoxButton.OK,MessageBoxImage.Error);
            }
           
           

            return data;







        }



        

       




        








        private void ListViewItem_Trang_chu_Selected(object sender, RoutedEventArgs e)
        {
            page_TrangChu page_TrangChu = new page_TrangChu();
            frame_Add_Pages.NavigationService.Navigate(page_TrangChu);
            button_GoBack.IsEnabled = true;
            button_GoBack.Background = Brushes.Transparent;
            packicon_Trang_chu.Foreground = Brushes.LightSkyBlue;
            packicon_Hethong.Foreground = Brushes.White;
            packicon_Admin.Foreground = Brushes.White;
           
        }

        private void ListViewItem_HeThong_Selected(object sender, RoutedEventArgs e)
        {
            page_HeThong HeThong = new page_HeThong();
            frame_Add_Pages.NavigationService.Navigate(HeThong);
            button_GoBack.IsEnabled = true;
            button_GoBack.Background = Brushes.Transparent;
            packicon_Hethong.Foreground = Brushes.LightSkyBlue;
            packicon_Admin.Foreground = Brushes.White;
            packicon_Trang_chu.Foreground = Brushes.White;
          
           
        }


        private void ListViewItem_Admin_Selected(object sender, RoutedEventArgs e)
        {
           
          
            page_Admin page_Admin = new page_Admin();
            frame_Add_Pages.NavigationService.Navigate(page_Admin);
            button_GoBack.IsEnabled = true;
            button_GoBack.Background = Brushes.Transparent;
            packicon_Admin.Foreground = Brushes.LightSkyBlue;
            packicon_Hethong.Foreground = Brushes.White;
            packicon_Trang_chu.Foreground = Brushes.White;
           


        }

        

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }


     
        private void button_GoBack_Click(object sender, RoutedEventArgs e)
        {
           
            
            var p = frame_Add_Pages.Content as Page;
            if (frame_Add_Pages.CanGoBack)
            {
                frame_Add_Pages.GoBack();

               


            }
            else 
            {
                button_GoBack.Background = Brushes.Gray;
                button_GoBack.IsEnabled = false;
            }


            if (frame_Add_Pages.CanGoForward) 
            {
                button_GoForward.IsEnabled = true;
                button_GoForward.Background = Brushes.Transparent;
            }


            ListViewItem_Trang_chu.IsSelected = false;
            ListViewItem_HeThong.IsSelected = false;
            ListViewItem_Admin.IsSelected = false;


            packicon_Admin.Foreground = Brushes.White;
            packicon_Hethong.Foreground = Brushes.White;
            packicon_Trang_chu.Foreground = Brushes.White;




        }




        private void button_GoForward_Click(object sender, RoutedEventArgs e)
        {
            
            if (frame_Add_Pages.CanGoForward)
            {
                frame_Add_Pages.GoForward();


            }
            else
            {
                button_GoForward.Background = Brushes.Gray;
                button_GoForward.IsEnabled = false;
                
            }

            if (frame_Add_Pages.CanGoBack) 
            {
                button_GoBack.IsEnabled = true;
                button_GoBack.Background = Brushes.Transparent;
            }



            ListViewItem_Trang_chu.IsSelected = false;
            ListViewItem_HeThong.IsSelected = false;
            ListViewItem_Admin.IsSelected = false;

            packicon_Admin.Foreground = Brushes.White;
            packicon_Hethong.Foreground = Brushes.White;
            packicon_Trang_chu.Foreground = Brushes.White;


        }

        private void button_minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void button_window_Normal_Click(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Normal;
            button_window_Maximizied.Visibility = Visibility.Visible;
            button_window_Normal.Visibility = Visibility.Collapsed;

        }

        private void button_window_Maximizied_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            button_window_Normal.Visibility = Visibility.Visible;
            button_window_Maximizied.Visibility = Visibility.Collapsed;
        }

        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

       
    }
}
