using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ungdungcuoiki
{
    /// <summary>
    /// Interaction logic for frDangNhap.xaml
    /// </summary>
    public partial class frDangNhap : Window
    {
        public frDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            /*SqlConnection conc = new SqlConnection(@"Data Source=DESKTOP-86JH9HT;Initial Catalog=QuanLiThongTin;Integrated Security=True");
            conc.Open();
                try
                {
                    string sql = "select *from DangNhap where TaiKhoan='" + txtTaiKhoan.Text + "'and MatKhau='" + txtMatKhau.Text + "'";
                    conc.Open();
                    SqlCommand cmd = new SqlCommand(sql, conc);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                    MessageBox.Show("Đăng Nhập Thành Công","Thành Công", MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                else
                {
                    MessageBox.Show("Đăng Nhập Thất Bại","Thất Bại", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                    conc.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi Kết Nối!");
                }*/
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-86JH9HT;Initial Catalog=QuanLiThongTin;Integrated Security=True";
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) from DangNhap where TaiKhoan='" + txtTaiKhoan.Text + "'and MatKhau='" + txtMatKhau.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {

                this.Hide();
                new frMain().Show();
            }
            else
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
        }
        private void DangKi(object sender, RoutedEventArgs e)
        {
            frDangKy dk = new frDangKy();
            this.Close();
            dk.ShowDialog();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi đây hay không?",
                                         "Thoát",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
