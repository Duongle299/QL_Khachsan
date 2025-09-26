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
namespace DA_CS464C_NHOM03
{
    public partial class ChiTietdatphong : Window
    {
        public ChiTietdatphong()
        {
            InitializeComponent();
        }

        private void btnTinhGia_Click(object sender, RoutedEventArgs e)
        {
            CapNhatGia();
        }

        private void CapNhatGia()
        {
            string loaiPhong = cbLoaiPhong.Text.Trim();
            string maPhong = cbMaphong.Text.Trim();
            string soPhongText = cbSophong.Text.Trim();

            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng nhập mã phòng.");
                return;
            }

            if (string.IsNullOrEmpty(loaiPhong))
            {
                MessageBox.Show("Vui lòng nhập loại phòng.");
                return;
            }

            if (!int.TryParse(soPhongText, out int soPhong) || soPhong <= 0)
            {
                MessageBox.Show("Số phòng không hợp lệ.");
                return;
            }

            int gia = 0;
            if (loaiPhong.Equals("VIP", StringComparison.OrdinalIgnoreCase))
                gia = soPhong * 1000000;
            else if (loaiPhong.Equals("Thường", StringComparison.OrdinalIgnoreCase))
                gia = soPhong * 500000;
            else
            {
                MessageBox.Show("Loại phòng không hợp lệ. Chỉ có 'VIP' hoặc 'Thường'.");
                return;
            }

            txtGiaPhong.Text = gia.ToString("N0") + " VND";
        }
    }
}


