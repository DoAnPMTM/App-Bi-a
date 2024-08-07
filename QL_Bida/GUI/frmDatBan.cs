using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DAL.DatBanDAL;

namespace GUI
{
    public partial class frmDatBan : Form
    {
        DatBanDAL datBanDAL = new DatBanDAL();
        public frmDatBan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            minimize_btn.FlatAppearance.BorderSize = 0;
            close_btn.FlatAppearance.BorderSize = 0;
            loadDatBan();
            btnload.Click += Btnload_Click;
            btnSearch.Click += BtnSearch_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtTenKH.Text = row.Cells[0].Value.ToString();
                txtSDT.Text = row.Cells[1].Value.ToString();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKH.Text.ToLower();
            string sdt = txtSDT.Text;

            var listDatBan = datBanDAL.loadDatBan();
            var listKhachHang = datBanDAL.loadKhachHang();
            var listBan = datBanDAL.loadBan();

            var result = listDatBan.Where(db =>
                (string.IsNullOrEmpty(tenKH) || listKhachHang.Any(kh => kh.MAKH == db.MAKH && kh.TENKH.ToLower().Contains(tenKH))) &&
                (string.IsNullOrEmpty(sdt) || listKhachHang.Any(kh => kh.MAKH == db.MAKH && kh.SDT.Contains(sdt)))
            ).ToList();

            dataGridView1.Rows.Clear(); // Clear existing rows

            foreach (var db in result)
            {
                var khachHang = listKhachHang.FirstOrDefault(kh => kh.MAKH == db.MAKH);
                var ban = listBan.FirstOrDefault(b => b.MABAN == db.MABAN);

                if (khachHang != null && ban != null)
                {
                    string loaiBan = db.LOAIBAN == true ? "Bida france" : "Bida lỗ";
                    dataGridView1.Rows.Add(khachHang.TENKH, khachHang.SDT, ban.TENBAN, loaiBan, db.THOIGIANDEN);
                }
            }

            MessageBox.Show($"Tìm thấy {result.Count} kết quả", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btnload_Click(object sender, EventArgs e)
        {
            loadDatBan();
            txtTenKH.Clear();
            txtSDT.Clear();
        }

        public void loadDatBan()
        {
            dataGridView1.Rows.Clear(); // Clear existing rows

            var listDatBan = datBanDAL.loadDatBan();
            var listKhachHang = datBanDAL.loadKhachHang();
            var listBan = datBanDAL.loadBan();

            foreach (var db in listDatBan)
            {
                var khachHang = listKhachHang.FirstOrDefault(kh => kh.MAKH == db.MAKH);
                var ban = listBan.FirstOrDefault(b => b.MABAN == db.MABAN);

                if (khachHang != null && ban != null)
                {
                    string loaiBan = db.LOAIBAN == true ? "Bida france" : "Bida lỗ";
                    dataGridView1.Rows.Add(khachHang.TENKH, khachHang.SDT, ban.TENBAN, loaiBan, db.THOIGIANDEN);
                }
            }


        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDatBan_Load(object sender, EventArgs e)
        {
            loadDatBan();
        }
    }

    
}
