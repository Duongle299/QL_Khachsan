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
    /// <summary>
    /// Interaction logic for Nhanvien.xaml
    /// </summary>
    public partial class Nhanvien : Window
    {
        QLKHACHSANEntities db = new QLKHACHSANEntities();
        public Nhanvien()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvNhanVien.ItemsSource = db.NhanViens.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nv = new NhanVien()
                {
                    MaNV = int.Parse (txtMaNV.Text),
                    TenNV = txtTenNV.Text,
                    ChucVu = txtChucVu.Text,
                    SDT = txtSDT.Text,
                    Email = txtEmail.Text
                };

                db.NhanViens.Add(nv);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nv = db.NhanViens.FirstOrDefault(x => x.MaNV == txtMaNV.Text);
                if (nv != null)
                {
                    nv.TenNV = txtTenNV.Text;
                    nv.ChucVu = txtChucVu.Text;
                    nv.SDT = txtSDT.Text;
                    nv.Email = txtEmail.Text;

                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nv = db.NhanViens.FirstOrDefault(x => x.MaNV == txtMaNV.Text);
                if (nv != null)
                {
                    db.NhanViens.Remove(nv);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var keyword = txtTenNV.Text.Trim();
            dgvNhanVien.ItemsSource = db.NhanViens
                                       .Where(n => n.TenNV.Contains(keyword))
                                       .ToList();
        }
    }
}
