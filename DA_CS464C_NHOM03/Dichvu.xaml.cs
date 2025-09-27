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
        QLKHACHSANEntities db = new QLKHACHSANEntities();

        public Dichvu()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgOrder.ItemsSource = db.DichVus.ToList();
        }
        private void dgOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dvchon = dgOrder.SelectedItem as DichVu;
            if (dvchon == null) return;

            txtMaDV.Text = dvchon.MaDV.ToString();
            txtTenDV.Text = dvchon.TenDV;
            txtLoaiDV.Text = dvchon.LoaiDV;
            txtMoTa.Text = dvchon.MoTa;
            txtKhungGio.Text = txtKhungGio.Text = dvchon.KhungGioHoatDong.ToString();
            txtDonGia.Text = dvchon.DonGia.ToString();
            cbTinhTrang.Text = dvchon.TinhTrang;
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dv = new DichVu
                {
                    TenDV = txtTenDV.Text,
                    LoaiDV = txtLoaiDV.Text,
                    MoTa = txtMoTa.Text,
                    KhungGioHoatDong = txtKhungGio.Text,
                    DonGia = decimal.Parse(txtDonGia.Text),
                    TinhTrang = cbTinhTrang.Text
                };

                db.DichVus.Add(dv);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm dịch vụ thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }
        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            var dvchon = dgOrder.SelectedItem as DichVu;
            if (dvchon == null)
            {
                MessageBox.Show("Chọn bản ghi cần cập nhật");
                return;
            }
            try
            {
                var dv = db.DichVus.Find(dvchon.MaDV);
                if (dv != null)
                {
                    dv.TenDV = txtTenDV.Text;
                    dv.LoaiDV = txtLoaiDV.Text;
                    dv.MoTa = txtMoTa.Text;
                    dv.KhungGioHoatDong = txtKhungGio.Text;
                    dv.DonGia = decimal.Parse(txtDonGia.Text);
                    dv.TinhTrang = cbTinhTrang.Text;

                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var dvchon = dgOrder.SelectedItem as DichVu;
            if (dvchon == null)
            {
                MessageBox.Show("Chọn bản ghi cần xóa");
                return;
            }
            try
            {
                var dv = db.DichVus.Find(dvchon.MaDV);
                if (dv != null)
                {
                    db.DichVus.Remove(dv);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }
    }
}