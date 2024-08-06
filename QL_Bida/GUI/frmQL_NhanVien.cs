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
    public partial class frmQL_NhanVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnn);
        SqlDataAdapter da_nv;
        DataSet ds_QLBida = new DataSet();
        public frmQL_NhanVien()
        {
            InitializeComponent();
            dgvNV.CellClick += DgvNV_CellClick;
            Load += FrmQL_NhanVien_Load;
            dgvNV.CellValueChanged += DgvNV_CellValueChanged;
            themToolStripMenuItem.Click += ThemToolStripMenuItem_Click;
            xoaToolStripMenuItem.Click += XoaToolStripMenuItem_Click;
            suaToolStripMenuItem.Click += SuaToolStripMenuItem_Click;
            searchToolStripMenuItem.Click += SearchToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;

            //
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string caLam = cboNV.SelectedItem?.ToString();

            string searchQuery = "SELECT MaNhanVien, TenNV, CaLam FROM NhanVien WHERE 1 = 1";

            if (!string.IsNullOrEmpty(maNV))
            {
                searchQuery += " AND MaNhanVien = @MaNhanVien";
            }
            if (!string.IsNullOrEmpty(tenNV))
            {
                searchQuery += " AND TenNV LIKE @TenNV";
            }
            if (!string.IsNullOrEmpty(caLam))
            {
                searchQuery += " AND CaLam = @CaLam";
            }

            using (SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, conn))
            {
                if (!string.IsNullOrEmpty(maNV))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@MaNhanVien", maNV);
                }
                if (!string.IsNullOrEmpty(tenNV))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@TenNV", "%" + tenNV + "%");
                }
                if (!string.IsNullOrEmpty(caLam))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@CaLam", caLam);
                }

                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);

                    int rowCount = dt.Rows.Count;
                    if (rowCount == 0)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên nào phù hợp !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Tìm kiếm thành công! Có {rowCount} nhân viên được tìm thấy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvNV.DataSource = dt;
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
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(cboNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string caLam = cboNV.SelectedItem.ToString().Trim() == "Có" ? "1" : "0";
            string updateQuery = "UPDATE NHANVIEN SET TENNV = @TenNV, CALAM = @CaLam WHERE MANHANVIEN = @MaNV";
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@TenNV", tenNV);
                cmd.Parameters.AddWithValue("@CaLam", caLam);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công!");
                        LoadgvNV();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã nhân viên!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void XoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!");
                return;
            }

            string maNV = txtMaNV.Text.Trim();

            string deleteQuery = "DELETE FROM NHANVIEN WHERE MANHANVIEN = @MaNV";
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        LoadgvNV();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã nhân viên!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ThemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(cboNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string maNV = GenerateMaNhanVien();
            string tenNV = txtTenNV.Text.Trim();
            string caLam = cboNV.Text.Trim() == "Có" ? "1" : "0";

            string insertQuery = "INSERT INTO NhanVien (MaNhanVien, TenNV, CaLam) VALUES (@MaNhanVien, @TenNV, @CaLam)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MaNhanVien", maNV);
                cmd.Parameters.AddWithValue("@TenNV", tenNV);
                cmd.Parameters.AddWithValue("@CaLam", caLam);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadgvNV();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void DgvNV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNV.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
                var cellValue = row.Cells["CaLam"].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    cboNV.SelectedItem = cellValue.ToString();
                }
                else
                {
                    cboNV.SelectedIndex = -1;
                }
            }
        }

        private void FrmQL_NhanVien_Load(object sender, EventArgs e)
        {
            LoadgvNV();
            LoadCboCaLam();

            dgvNV.Columns["MaNhanVien"].ReadOnly = true;
            dgvNV.Columns["CaLam"].ReadOnly = true;
        }

        private void DgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNV.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
                var cellValue = row.Cells["CaLam"].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    cboNV.SelectedItem = cellValue.ToString();
                }
                else
                {
                    cboNV.SelectedIndex = -1;
                }
            }
        }
        private string GenerateMaNhanVien()
        {
            string maNV = "NV";
            int maxId = 1;

            string query = "SELECT MAX(CAST(SUBSTRING(MaNhanVien, 3, LEN(MaNhanVien) - 2) AS INT)) AS MaxId FROM NhanVien";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result) + 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating MaNhanVien: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            maNV += maxId.ToString("D3"); // Format the number as three digits with leading zeros if necessary
            return maNV;
        }
        public void LoadgvNV()
        {
            string query = @"SELECT MaNhanVien, TenNV, 
                            CASE WHEN CaLam = 0 THEN N'Không' ELSE N'Có' END AS CaLam 
                            FROM NhanVien";
            da_nv = new SqlDataAdapter(query, conn);
            ds_QLBida.Clear();
            da_nv.Fill(ds_QLBida, "NhanVien");
            dgvNV.DataSource = ds_QLBida.Tables["NhanVien"];
        }

        public void LoadCboCaLam()
        {
            cboNV.Items.Clear();
            cboNV.Items.Add("Có");
            cboNV.Items.Add("Không");
        }

        private void ClearFields()
        {
            txtMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            cboNV.SelectedIndex = -1;
        }

    }
}
