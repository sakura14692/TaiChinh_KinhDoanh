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


namespace TaiChinh_KinhDoanh.Views.Admin
{
    /// <summary>
    /// Interaction logic for page_Admin.xaml
    /// </summary>
    public partial class page_Admin : Page
    {
        public page_Admin()
        {
            InitializeComponent();



            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

            this.DataContext = this;
            source = ketNoiCSDL_HinhNen().Rows[2]["nguon"].ToString();





        }



        string source;
        public string Source
        {
            get { return source; }
            set { source = value; }

        }

        string chuoiketnoi;

        public DataTable ketNoiCSDL_HinhNen()
        {

            DataTable data = new DataTable();
            try
            {
                string truyvan = "select * from hinh_nen";
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







        private void button_Thong_tin_nguoi_dung_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Thong_tin_nguoi_dung thong_Tin_Nguoi_Dung = new UserControl_Thong_tin_nguoi_dung();
            grid_Add_UserControls_Admin.Children.Add(thong_Tin_Nguoi_Dung);
            button_Che_do_bao_mat.BorderBrush = Brushes.White;
            packicon_che_do_bao_mat.Foreground = Brushes.White; ;
            textblock_che_do_bao_mat.Foreground = Brushes.White;
            button_Thong_tin_nguoi_dung.BorderBrush = Brushes.LightSkyBlue;
            packicon_thong_tin_nguoi_dung.Foreground = Brushes.LightSkyBlue;
            textblock_thong_tin_nguoi_dung.Foreground = Brushes.LightSkyBlue;

        }

        private void button_Che_do_bao_mat_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Che_do_bao_mat che_Do_Bao_Mat = new UserControl_Che_do_bao_mat();
            grid_Add_UserControls_Admin.Children.Add(che_Do_Bao_Mat);
            button_Che_do_bao_mat.BorderBrush = Brushes.LightSkyBlue;
            packicon_che_do_bao_mat.Foreground = Brushes.LightSkyBlue;
            textblock_che_do_bao_mat.Foreground= Brushes.LightSkyBlue;
            button_Thong_tin_nguoi_dung.BorderBrush = Brushes.White;
            packicon_thong_tin_nguoi_dung.Foreground= Brushes.White;
            textblock_thong_tin_nguoi_dung.Foreground= Brushes.White;
        }
    }
}
