using System;
using System.Collections.Generic;
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
    /// Interaction logic for form_Ho_tro_ket_noi_den_CSDL.xaml
    /// </summary>
    public partial class form_Ho_tro_ket_noi_den_CSDL : Window
    {
        public form_Ho_tro_ket_noi_den_CSDL()
        {
            InitializeComponent();

           


        }




        public bool textIsnotNull() 
        {

            if (string.IsNullOrEmpty(textbox_ten_Server.Text)) 
            {
                MessageBox.Show("Hãy điền 'Tên Server !' ","Nhắc nhở",MessageBoxButton.OK,MessageBoxImage.Information);
                textbox_ten_Server.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_ten_co_so_du_lieu.Text)) 
            {

                MessageBox.Show("Hãy điền 'Tên Cơ sở dự liệu !' ", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
                textbox_ten_co_so_du_lieu.Focus();
                return false;
            }
            else
            if (string.IsNullOrEmpty(textbox_che_do_bao_mat.Text))
            {

                MessageBox.Show("Hãy điền 'Chế độ bảo mật !' ", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
                textbox_che_do_bao_mat.Focus();
                return false;
            }

            return true;
        }


       
        private void button_Ket_noi_Click(object sender, RoutedEventArgs e)
        {
            if (textIsnotNull()) 
            {
                var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
                string contentfile = string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = {2}",
                textbox_ten_Server.Text, textbox_ten_co_so_du_lieu.Text, textbox_che_do_bao_mat.Text);
                File.WriteAllText(fullpath, contentfile);
                MessageBox.Show("Chuỗi kết nối đã được nhập, ứng dụng đã sẵn sàng' ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }

           
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
