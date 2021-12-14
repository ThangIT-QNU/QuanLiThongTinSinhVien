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
    /// Interaction logic for frMain.xaml
    /// </summary>
    public partial class frMain : Window
    {
        public frMain()
        {
            InitializeComponent();
        }

        private void btnQLSV_Click(object sender, RoutedEventArgs e)
        {
            frQLSV QLSV = new frQLSV();
            this.Close();
            QLSV.ShowDialog();
        }

        private void btnQLL_Click(object sender, RoutedEventArgs e)
        {
            frQLL QLL = new frQLL();
            this.Close();
            QLL.ShowDialog();
        }

        private void btnQLK_Click(object sender, RoutedEventArgs e)
        {
            frQLK QLK = new frQLK();
            this.Close();
            QLK.ShowDialog();
        }
    }
}
