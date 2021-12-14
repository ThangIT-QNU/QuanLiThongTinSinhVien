using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for frDangKy.xaml
    /// </summary>
    public partial class frDangKy : Window
    {
        public frDangKy()
        {
            InitializeComponent();
        }

        SqlConnection conc = new SqlConnection(@"Data Source=DESKTOP-86JH9HT;Initial Catalog=QuanLiThongTin;Integrated Security=True");
        private void DangKy_Click(object sender, RoutedEventArgs e)
        {
            if (txtTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtNhapLaiMatKhau.Text != "" && txtHoVaTen.Text != "" && txtSoDienThoai.Text != "")
            {
                conc.Open();
                String TaiKhoan = txtTaiKhoan.Text;
                String MatKhau = txtMatKhau.Text;
                String NhapLaiMatKhau = txtNhapLaiMatKhau.Text;
                String HoVaTen = txtHoVaTen.Text;
                String SoDienThoai = txtSoDienThoai.Text;
                SqlCommand cmd = new SqlCommand(" insert into DangNhap (TaiKhoan,MatKhau,NhapLaiMatKhau,HoVaTen,SoDienThoai) values ('" + TaiKhoan + "', '" + MatKhau +"','"+ NhapLaiMatKhau + "','"+HoVaTen+"','"+SoDienThoai+  "')", conc);
                cmd.ExecuteNonQuery();
                conc.Close();
                //
                MessageBox.Show("Đăng kí thành công", "Thành Công", MessageBoxButton.OK, MessageBoxImage.Information);
                txtTaiKhoan.Clear();
                txtMatKhau.Clear();
                txtNhapLaiMatKhau.Clear();
                txtHoVaTen.Clear();
                txtSoDienThoai.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin ở trên", "Nhắc nhở", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void QuayLai_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi đây hay không?",
                                         "Thoát",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                frDangNhap DangNhap = new frDangNhap();
                this.Hide();
                DangNhap.ShowDialog();
            }
        }

    }
}
