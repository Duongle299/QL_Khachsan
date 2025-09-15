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
       
        }
    }


