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
        QLKHACHSANEntities db = new QLKHACHSANEntities();
        public ChiTietdatphong()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgOrder.ItemsSource = db.DatPhongs.ToList();
        }

        private void btn_them_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int soLuong = 0;
                int.TryParse(cbSophong.Text, out soLuong);

                int thanhTien = 0;
                int.TryParse(txtGiaPhong.Text, out thanhTien);

                DatPhong dp = new DatPhong()
                {
                    MaKH = int.Parse(txtMaKH.Text),
                    MaPhong  = int.Parse(cbMaphong.Text),
                    SoLuong = soLuong,
                    NgayNhan = dpNgayNhan.SelectedDate ?? DateTime.Now,
                    NgayTra = dpNgayTra.SelectedDate ?? DateTime.Now,
                    ThanhTien = thanhTien
                };

                db.DatPhongs.Add(dp);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_capnhap_Click(object sender, RoutedEventArgs e)
        {
            var dpchon = dgOrder.SelectedItem as DatPhong;
            if (dpchon == null)
            {
                MessageBox.Show("Chọn bản ghi cần sửa");
                return;
            }

            try
            {
                var dp = db.DatPhongs.Find(dpchon.MaDatPhong);
                if (dp != null)
                {
                    dp.MaKH = int.Parse(txtMaKH.Text);
                    dp.MaPhong = int.Parse(cbMaphong.Text);
                    int soLuong = 0;
                    int.TryParse(cbSophong.Text, out soLuong);
                    dp.SoLuong = soLuong;

                    dp.NgayNhan = dpNgayNhan.SelectedDate ?? DateTime.Now;
                    dp.NgayTra = dpNgayTra.SelectedDate ?? DateTime.Now;

                    int thanhTien = 0;
                    int.TryParse(txtGiaPhong.Text, out thanhTien);
                    dp.ThanhTien = thanhTien;

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, RoutedEventArgs e)
        {
            var dpchon = dgOrder.SelectedItem as DatPhong;
            if (dpchon == null)
            {
                MessageBox.Show("Chọn bản ghi cần xóa");
                return;
            }

            try
            {
                var dp = db.DatPhongs.Find(dpchon.MaDatPhong);
                if (dp != null)
                {
                    db.DatPhongs.Remove(dp);
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void DgOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dpchon = dgOrder.SelectedItem as DatPhong;
            if (dpchon == null) return;

            txtMaKH.Text = dpchon.MaKH.ToString();
            cbMaphong.Text = dpchon.MaPhong.ToString();
            cbSophong.Text = dpchon.SoLuong.ToString();
            dpNgayNhan.SelectedDate = dpchon.NgayNhan;
            dpNgayTra.SelectedDate = dpchon.NgayTra;
            txtGiaPhong.Text = dpchon.ThanhTien.ToString();
        }
    }
}

