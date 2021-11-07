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

namespace TaiChinh_KinhDoanh
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            var fullpath = System.IO.Path.GetFullPath("test excomands.txt");

            string s = File.ReadAllText(fullpath);
            test_doc_file.Text = s;

            if(File.Exists(fullpath)) MessageBox.Show("Tồn tại");



            var filename = "thu_xem.txt";
            string contentfile = "Xin chào! xuanthulab.net";
            string X = "chuong_trinh";
           

            var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.Create(@"C:\Users\user\OneDrive\Desktop\" + X + ".txt");

            File.WriteAllText(fullpath, contentfile);
        }
    }
}
