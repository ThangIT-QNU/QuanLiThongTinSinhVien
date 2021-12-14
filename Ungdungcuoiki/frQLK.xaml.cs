using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Ungdungcuoiki
{
    /// <summary>
    /// Interaction logic for frQLK.xaml
    /// </summary>
    public partial class frQLK : Window
    {
        public frQLK()
        {
            InitializeComponent();
        }

        SqlConnection conc = new SqlConnection(@"Data Source=DESKTOP-86JH9HT;Initial Catalog=QuanLiThongTin;Integrated Security=True");

        void hienThi()
        {
            conc.Open();
            SqlCommand cmd = new SqlCommand("select * from Khoa", conc);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conc.Close();
            DTGV2.ItemsSource = dt.DefaultView;
        }

        private void load(object sender, RoutedEventArgs e)
        {
            hienThi();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi đây hay không?",
                                         "Thoát",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                frMain main = new frMain();
                this.Hide();
                main.ShowDialog();
            }
        }
    }
}
