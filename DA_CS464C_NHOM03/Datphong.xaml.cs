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
    public partial class DatPhong : Window
    {
        public DatPhong()
        {
            InitializeComponent();
        }

        // Nút Đặt phòng
        private void btnDatPhong_Click(object sender, RoutedEventArgs e)
        {
            string tenKhach = txtTenKhach.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string email = txtEmail.Text;

            DateTime? gioNhan = LayGioNhan();
            DateTime? gioTra = LayGioTra();

            // Chuẩn hóa thông tin giờ nhận/trả
            string thongTinGio = "";
            if (gioNhan != null)
                thongTinGio += $"\nGiờ nhận: {gioNhan.Value:dd/MM/yyyy HH:mm}";
            if (gioTra != null)
                thongTinGio += $"\nGiờ trả: {gioTra.Value:dd/MM/yyyy HH:mm}";

            MessageBox.Show(
                $"Tên khách hàng: {tenKhach}\n" +
                $"Số điện thoại: {sdt}\n" +
                $"CCCD: {cccd}\n" +
                $"Email: {email}" +
                thongTinGio,
                "Thông tin khách hàng",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
        private void cbLoaiPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CapNhatGia();
        }
        private void btnChonPhong_Click(object sender, RoutedEventArgs e)
        {
            if (lbSoPhong.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phòng.");
                return;
            }
            CapNhatGia();
        }
        private void CapNhatGia()
        {
            if (cbLoaiPhong.SelectedItem is ComboBoxItem selectedItem)
            {
                string loaiPhong = selectedItem.Content.ToString();
                int soPhong = lbSoPhong.SelectedItems.Count;

                if (loaiPhong == "VIP")
                    txtGiaPhong.Text = (soPhong * 1000000).ToString("N0") + " VND";
                else if (loaiPhong == "Thường")
                    txtGiaPhong.Text = (soPhong * 500000).ToString("N0") + " VND";
                else
                    txtGiaPhong.Text = "";
            }
        }
        private DateTime? LayGio(DatePicker dp, ComboBox cb)
        {
            if (dp.SelectedDate != null && cb.SelectedItem is ComboBoxItem selectedItem)
            {
                string[] parts = selectedItem.Content.ToString().Split(':');
                int hour = int.Parse(parts[0]);
                int minute = int.Parse(parts[1]);
                DateTime ngay = dp.SelectedDate.Value;
                return new DateTime(ngay.Year, ngay.Month, ngay.Day, hour, minute, 0);
            }
            return null;
        }
    }
}

