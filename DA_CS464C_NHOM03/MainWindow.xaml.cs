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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DA_CS464C_NHOM03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        QLKHACHSANEntities db = new QLKHACHSANEntities();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Phong p = new Phong()
            {
                MaPhong = int.Parse(txt_maphong.Text),
                SoPhong = int.Parse(txt_sophon.Text),
                Tang = int.Parse(txt_sophon.Text),
                SucChua = int.Parse(txt_sophon.Text),
                LoaiPhong = txt_sophon.Text,
                GiaPhong = int.Parse(txt_sophon.Text),
                DienTich = int.Parse(txt_sophon.Text),
                TienNghi = txt_sophon.Text,
                MoTa = txt_sophon.Text,
                TinhTrang = txt_sophon.Text,
            };
            db.Phongs.Add(p);
            db.SaveChanges();
            MessageBox.Show("thêm mới phòng thành công");
            loadPhong();
        }
        public void loadPhong()
        {
            dg_phong.ItemsSource = db.Phongs.ToList();
        }
        private void Dg_phong_Loaded(object sender, RoutedEventArgs e)
        {
            loadPhong();
        }

        private void Btn_capnhat_Click(object sender, RoutedEventArgs e)
        {
            Phong pchon = dg_phong.SelectedItem as Phong;
            if(pchon == null)
            {
                MessageBox.Show("vui lòng chọn mã phòng");
                return;
            }
            else
            {
                Phong p = db.Phongs.Find(pchon.MaPhong);
                p.MaPhong = int.Parse(txt_maphong.Text);
                p.SoPhong = int.Parse(txt_sophon.Text);
                p.Tang = int.Parse(txt_sophon.Text);
                p.SucChua = int.Parse(txt_sophon.Text);
                p.LoaiPhong = txt_sophon.Text;
                p.GiaPhong = int.Parse(txt_sophon.Text);
                p.DienTich = int.Parse(txt_sophon.Text);
                p.TienNghi = txt_sophon.Text;
                p.MoTa = txt_sophon.Text;
                p.TinhTrang = txt_sophon.Text;
                db.SaveChanges();
                MessageBox.Show("câp nhật phòng thành công");
                loadPhong();
            }
                
        }

        private void Btn_xoa_Click(object sender, RoutedEventArgs e)
        {
            Phong pchon = dg_phong.SelectedItem as Phong;
            if (pchon == null)
            {
                MessageBox.Show("vui lòng chọn mã phòng");
                return;
            }
            else
            {
                Phong p = db.Phongs.Find(pchon.MaPhong);
                db.Phongs.Remove(p);
                db.SaveChanges();
                MessageBox.Show("xóa phòng thành công");
                loadPhong();
            }
        }
    }
}
