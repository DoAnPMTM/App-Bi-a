using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQL_KhachHang : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnn);
        DataSet ds_QLBida = new DataSet();
        SqlDataAdapter da_bida;
        public frmQL_KhachHang()
        {
            InitializeComponent();
            Load += FrmQL_KhachHang_Load;
            dgvKH.CellClick += DgvKH_CellClick;
            dgvKH.CellValueChanged += DgvKH_CellValueChanged;
            themToolStripMenuItem.Click += ThemToolStripMenuItem_Click;
            xoaToolStripMenuItem.Click += XoaToolStripMenuItem_Click;
            suaToolStripMenuItem.Click += SuaToolStripMenuItem_Click;
            searchToolStripMenuItem.Click += SearchToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txtTenKhach.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            string query = "SELECT * FROM KHACHHANG WHERE 1 = 1";
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                query += " AND TenKh LIKE @TenKh";
            }
            if (!string.IsNullOrEmpty(sdt))
            {
                query += " AND SDT LIKE @SDT";
            }

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                if (!string.IsNullOrEmpty(tenKhachHang))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@TenKh", "%" + tenKhachHang + "%");
                }
                if (!string.IsNullOrEmpty(sdt))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@SDT", "%" + sdt + "%");
                }

                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);

                    int rowCount = dt.Rows.Count;
                    if (rowCount == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Tìm kiếm thành công! Có {rowCount} khách hàng phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvKH.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void SuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhach.Text) || string.IsNullOrEmpty(txtTenKhach.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng và nhập đầy đủ thông tin!");
                return;
            }

            string update = "UPDATE KHACHHANG SET TenKh = @TenKh, SDT = @SDT WHERE MaKh = @MaKh";
            using (SqlCommand cmd = new SqlCommand(update, conn))
            {
                cmd.Parameters.AddWithValue("@MaKh", Convert.ToInt32(txtMaKhach.Text));
                cmd.Parameters.AddWithValue("@TenKh", txtTenKhach.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            LoadgvKH();
            ClearFields();
        }

        private void XoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhach.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
                return;
            }

            string delete = "DELETE FROM KHACHHANG WHERE MaKh = @MaKh";
            using (SqlCommand cmd = new SqlCommand(delete, conn))
            {
                cmd.Parameters.AddWithValue("@MaKh", Convert.ToInt32(txtMaKhach.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa khách hàng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            LoadgvKH();
            ClearFields();
        }

        private void ThemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKhach.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!");
                return;
            }

            string insert = "INSERT INTO KHACHHANG (TenKh, SDT) VALUES (@TenKh, @SDT)";
            using (SqlCommand cmd = new SqlCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@TenKh", txtTenKhach.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm khách hàng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            LoadgvKH();
            ClearFields();
        }

        private void DgvKH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];
                txtMaKhach.Text = row.Cells["MaKhach"].Value.ToString();
                txtTenKhach.Text = row.Cells["TenKhach"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }

        private void DgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];
                txtMaKhach.Text = row.Cells["MaKhach"].Value.ToString();
                txtTenKhach.Text = row.Cells["TenKhach"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }

        private void FrmQL_KhachHang_Load(object sender, EventArgs e)
        {
            LoadgvKH();
        }
        public void LoadgvKH()
        {
            string select = "select * from KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(select, conn);
            DataTable dt_dv = new DataTable();
            da.Fill(dt_dv);
            dgvKH.DataSource = dt_dv;
        }
        private void ClearFields()
        {
            txtMaKhach.Clear();
            txtTenKhach.Clear();
            txtSDT.Clear();
        }
    }
}
