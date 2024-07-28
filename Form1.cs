using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class Form1 : Form
    {
        List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo dữ liệu mẫu (có thể thay đổi)
            danhSachNhanVien.Add(new NhanVien() { MSNV = "NV001", TenNV = "Nguyễn Thị Thu Hiện", LuongCB = 8500000 });
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            listView1.Items.Clear();
            foreach (NhanVien nv in danhSachNhanVien)
            {
                ListViewItem item = new ListViewItem(nv.MSNV);
                item.SubItems.Add(nv.TenNV);
                item.SubItems.Add(nv.LuongCB.ToString());
                listView1.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVienMoi = new NhanVien(); // Tạo một đối tượng NhanVien mới
            FormNhanVien frmNhanVien = new FormNhanVien(nhanVienMoi); // Truyền đối tượng NhanVien cho hàm khởi tạo
            if (frmNhanVien.ShowDialog() == DialogResult.OK)
            {
                danhSachNhanVien.Add(frmNhanVien.NhanVienMoi);
                HienThiDanhSach();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nhanVienMoi = new NhanVien(); // Tạo một đối tượng NhanVien mới
            FormNhanVien frmNhanVien = new FormNhanVien(nhanVienMoi); // Truyền đối tượng NhanVien cho hàm khởi tạo
            if (frmNhanVien.ShowDialog() == DialogResult.OK)
            {
                danhSachNhanVien.Add(frmNhanVien.NhanVienMoi);
                HienThiDanhSach();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string msnv = item.SubItems[0].Text;
                NhanVien nv = danhSachNhanVien.Find(x => x.MSNV == msnv);

                FormNhanVien frmNhanVien = new FormNhanVien(nv);
                if (frmNhanVien.ShowDialog() == DialogResult.OK)
                {
                    HienThiDanhSach();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string msnv = item.SubItems[0].Text;
                danhSachNhanVien.RemoveAll(x => x.MSNV == msnv);
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!");
            }
        }
    }
    public class NhanVien
    {
        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public int LuongCB { get; set; }
    }
}
