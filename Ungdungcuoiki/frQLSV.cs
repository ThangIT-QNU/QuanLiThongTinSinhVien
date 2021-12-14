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
    /// Interaction logic for frQLSV.xaml
    /// </summary>
    public partial class frQLSV : Window
    {
        public frQLSV()
        {
            InitializeComponent();
        }
        readonly SqlConnection conc = new SqlConnection(@"Data Source=DESKTOP-86JH9HT;Initial Catalog=QuanLiThongTin;Integrated Security=True");

        void hienThi()
        {
            conc.Open();
            SqlCommand cmd = new SqlCommand("select * from SinhVien", conc);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conc.Close();
            DTGV1.ItemsSource = dt.DefaultView;
        }

        private void load(object sender, RoutedEventArgs e)
        {
            hienThi();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string delete = "delete from SinhVien where MaSV=@MaSinhVien";
                SqlCommand cm = new SqlCommand(delete, conc); 
                cm.Parameters.AddWithValue("MaSV", txtMaSinhVien.Text);
                cm.Parameters.AddWithValue("TenSV", txtTenSinhVien.Text);
                cm.Parameters.AddWithValue("NamSinh", txtNamSinh.Text);
                cm.Parameters.AddWithValue("GioiTinh", cbxGioiTinh.Text);
                cm.Parameters.AddWithValue("Lop", txtLop.Text);
                cm.Parameters.AddWithValue("MaLop", txtMaLop.Text);
                cm.Parameters.AddWithValue("MaKhoa", txtKhoa.Text);
                cm.ExecuteNonQuery();
                hienThi();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conc = new SqlConnection("Data Source=DESKTOP-86JH9HT;Initial Catalog=QuanLiThongTin;Integrated Security=True");
            conc.Open();
            string ma = txtMaSinhVien.Text;
            string ten = txtTenSinhVien.Text;
            string gt = cbxGioiTinh.Text;
            string ns = txtNamSinh.Text;
            string lop = txtLop.Text;
            string mlop = txtMaLop.Text;
            string khoa = txtKhoa.Text;
            string sql = "INSERT into SinhVien values('" + ma + "','" + ten + "','" + gt + "','" + ns + "','" + lop + "','" + mlop + "','" + khoa + "')";
            SqlCommand cmd = new SqlCommand(sql, conc);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added");
            conc.Close();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaSinhVien.Text == "" || txtTenSinhVien.Text == "" ||cbxGioiTinh.Text == "" || txtNamSinh.Text == "" || txtLop.Text == "" || txtMaLop.Text == "" || txtKhoa.Text == "")
            {
                MessageBox.Show("Thông tin chưa đầy đủ hoặc không chính xác!");
            }
            else
            {
                try
                {
                    conc.Open();
                    string edit = "update SinhVien set TenSV=@TenSinhVien, GioiTinh=@GioiTinh, NamSinh=@NamSinh, Lop=@Lop, MaLop=@MaLop Khoa@MaKhoa where MaSV=@MaSinhVien";
                    SqlCommand cm = new SqlCommand(edit, conc);
                    cm.Parameters.AddWithValue("MaSV", txtMaSinhVien.Text);
                    cm.Parameters.AddWithValue("TenSV", txtTenSinhVien.Text);
                    cm.Parameters.AddWithValue("GioiTinh", cbxGioiTinh.Text);
                    cm.Parameters.AddWithValue("NamSinh", txtNamSinh.Text);
                    cm.Parameters.AddWithValue("Lop", txtLop.Text);
                    cm.Parameters.AddWithValue("MaLop", txtMaLop.Text);
                    cm.Parameters.AddWithValue("MaKhoa", txtKhoa.Text);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo!");
                    hienThi();
                    conc.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu!");
                }
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi đây hay không?","Thông báo!", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                frMain main = new frMain();
                this.Hide();
                main.ShowDialog();
            }
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {

            conc.Open();
            SqlCommand cmd = new SqlCommand("select * from SinhVien where MaSV  ="+txtMaCanTim.Text+"", conc);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conc.Close();
            DTGV1.ItemsSource = dt.DefaultView;
        }

    }
}