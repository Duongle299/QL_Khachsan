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
    /// Interaction logic for Khachhang.xaml
    /// </summary>
    public partial class Khachhang : Window
    {
        QLKHACHSANEntities db = new QLKHACHSANEntities();
        public Khachhang()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dgvKhachHang.ItemsSource = db.KhachHangs.ToList();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {


            KhachHang kh = new KhachHang()
            {
                MaKH = int.Parse (txtMaKH.Text),
                CCCD = int.Parse (txtCMND.Text),
                SoDienThoai = int.Parse (txtSDT.Text),
                Email = txtEmail.Text

            };
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm thành công!");                
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kh = db.KhachHangs.FirstOrDefault(x => x.MaKH == txtMaKH.Text);
                if (kh != null)
                {
                    kh.TenKH = txtTenKH.Text;
                    kh.CMND = txtCMND.Text;
                    kh.SDT = txtSDT.Text;
                    kh.Email = txtEmail.Text;

                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
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
                var kh = db.KhachHangs.FirstOrDefault(x => x.MaKH == txtMaKH.Text);
                if (kh != null)
                {
                    db.KhachHangs.Remove(kh);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var keyword = txtTenKH.Text.Trim();
            dgvKhachHang.ItemsSource = db.KhachHangs
                                        .Where(k => k.TenKH.Contains(keyword))
                                        .ToList();
        }

    }
}
