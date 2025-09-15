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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
namespace DA_CS464C_NHOM03
{
    public partial class Dichvu : Window
    {

        public Dichvu()
        {
            InitializeComponent();
            lstMenu.Items.Add(new MonAn { MaMon = "M01", TenMon = "Phở Bò", Gia = 50000 });
            lstMenu.Items.Add(new MonAn { MaMon = "M02", TenMon = "Cơm Gà", Gia = 60000 });
            lstMenu.Items.Add(new MonAn { MaMon = "M03", TenMon = "Cà phê sữa", Gia = 30000 });
            lstMenu.Items.Add(new MonAn { MaMon = "M04", TenMon = "Nước suối", Gia = 15000 });
        }
    }
    public class MonAn
    {
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int Gia { get; set; }
        public override string ToString()
        {
            return TenMon + " - " + Gia + " VNĐ";
        }
    }
}