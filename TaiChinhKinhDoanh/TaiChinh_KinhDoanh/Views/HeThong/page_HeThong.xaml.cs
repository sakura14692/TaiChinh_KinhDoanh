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

namespace TaiChinh_KinhDoanh.Views.HeThong
{
    /// <summary>
    /// Interaction logic for page_HeThong.xaml
    /// </summary>
    public partial class page_HeThong : Page
    {
        public page_HeThong()
        {
            InitializeComponent();


            var fullpath = System.IO.Path.GetFullPath("chuoi_ket_noi.txt");
            if (File.Exists(fullpath))
            {
                string doc_file = File.ReadAllText(fullpath);
                chuoiketnoi = doc_file;
            }

            this.DataContext = this;
            source = ketNoiCSDL_HinhNen().Rows[1]["nguon"].ToString();

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
            string truyvan = "select * from hinh_nen";
            SqlConnection connect = new SqlConnection(chuoiketnoi);
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(truyvan, connect);
            adapter.Fill(data);
            connect.Close();
            return data;
        }





        private void button_HinhAnh_Click(object sender, RoutedEventArgs e)
        {
            UserControl_HinhAnh userControl_HinhAnh = new UserControl_HinhAnh();
            grid_Add_UserControls_HeThong.Children.Add(userControl_HinhAnh);
            button_HinhAnh.BorderBrush = Brushes.LightSkyBlue;
            textblock_hinh_anh.Foreground = Brushes.LightSkyBlue;
            packicon_hinh_anh.Foreground = Brushes.LightSkyBlue;
        }





    }
}
