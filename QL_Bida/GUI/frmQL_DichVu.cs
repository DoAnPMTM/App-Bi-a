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
    public partial class frmQL_DichVu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnn);
        DataSet ds_QLBida = new DataSet();
        SqlDataAdapter da_bida;
        private string userRole;
        public frmQL_DichVu(string userRole)
        {
            InitializeComponent();
            Load += FrmQL_DichVu_Load;
            dgvDV.CellValueChanged += DgvDV_CellValueChanged;
            dgvDV.CellClick += DgvDV_CellClick;
            themToolStripMenuItem.Click += ThemToolStripMenuItem_Click;
            xoaToolStripMenuItem.Click += XoaToolStripMenuItem_Click;
            suaToolStripMenuItem.Click += SuaToolStripMenuItem_Click;
            searchToolStripMenuItem.Click += SearchToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            this.userRole = userRole;
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
            string tenDichVu = txtTenDV.Text.Trim();
            string donViTinh = cbo_DVT.SelectedItem?.ToString();

            // Chuỗi truy vấn SQL để tìm kiếm theo tên dịch vụ và đơn vị tính
            string query = "SELECT * FROM DICHVU WHERE 1 = 1";
            if (!string.IsNullOrEmpty(tenDichVu))
            {
                query += " AND TenDV LIKE @TenDV";
            }
            if (!string.IsNullOrEmpty(donViTinh))
            {
                query += " AND DonViTinh = @DonViTinh";
            }

            // Sử dụng SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu vào DataTable
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                // Thêm tham số vào câu truy vấn
                if (!string.IsNullOrEmpty(tenDichVu))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@TenDV", "%" + tenDichVu + "%");
                }
                if (!string.IsNullOrEmpty(donViTinh))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@DonViTinh", donViTinh);
                }

                // Tạo DataTable để lưu dữ liệu từ cơ sở dữ liệu
                DataTable dt = new DataTable();

                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                    adapter.Fill(dt);

                    int rowCount = dt.Rows.Count;
                    if (rowCount == 0)
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ nào phù hợp !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Tìm kiếm thành công! Có {rowCount} giá trị được tìm thấy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Đặt lại nguồn dữ liệu cho DataGridView để hiển thị kết quả
                    dgvDV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối sau khi thực hiện xong
                    conn.Close();
                }
            }
        }

        private void SuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text) || string.IsNullOrEmpty(txtTenDV.Text) || string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(cbo_DVT.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ và nhập đầy đủ thông tin!");
                return;
            }

            string update = "UPDATE DICHVU SET TenDV = @TenDV, DonGia = @DonGia, DonViTinh = @DonViTinh WHERE MaDV = @MaDV";
            using (SqlCommand cmd = new SqlCommand(update, conn))
            {
                cmd.Parameters.AddWithValue("@MaDV", Convert.ToInt32(txtMaDV.Text));
                cmd.Parameters.AddWithValue("@TenDV", txtTenDV.Text);
                cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(txtDonGia.Text));
                cmd.Parameters.AddWithValue("@DonViTinh", cbo_DVT.Text);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadgvDV();
                        LoadCboDVT();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

        private void XoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!");
                return;
            }

            string delete = "DELETE FROM DICHVU WHERE MaDV = @MaDV";
            using (SqlCommand cmd = new SqlCommand(delete, conn))
            {
                cmd.Parameters.AddWithValue("@MaDV", Convert.ToInt32(txtMaDV.Text));

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadgvDV();
                        LoadCboDVT();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

        private void ThemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDV.Text) || string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(cbo_DVT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string tenDV = txtTenDV.Text.Trim();
            string donGia = txtDonGia.Text.Trim();
            string donViTinh = cbo_DVT.Text.Trim();

            // Kiểm tra và thêm đơn vị tính mới nếu chưa có trong combobox
            if (!cbo_DVT.Items.Contains(donViTinh))
            {
                // AddNewDonViTinh(donViTinh);
            }

            // Kiểm tra xem tên dịch vụ tồn tại
            string checkQuery = "SELECT MaDV, TenDV FROM DichVu WHERE TenDV = @TenDV";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@TenDV", tenDV);

                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    using (SqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string existingMaDV = reader["MaDV"].ToString();
                            string existingTenDV = reader["TenDV"].ToString();
                            conn.Close();

                            // Hiển thị thông báo trùng lặp và xác nhận từ người dùng
                            DialogResult result = MessageBox.Show($"Tên Dịch vụ: '{existingTenDV}', có Mã: '{existingMaDV}' đã tồn tại. Bạn có muốn thêm không?",
                                                                  "Xác nhận thêm dịch vụ trùng lặp !!!",
                                                                  MessageBoxButtons.YesNo,
                                                                  MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                            {
                                return;
                            }
                        }
                        else
                        {
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    return;
                }
            }

            // Thêm dịch vụ mới vào cơ sở dữ liệu (mã tăng auto)
            string insertQuery = "INSERT INTO DichVu (TenDV, DonGia, DonViTinh) VALUES (@TenDV, @DonGia, @DonViTinh)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenDV", tenDV);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@DonViTinh", donViTinh);

                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm dịch vụ thành công!");
                    LoadgvDV(); // Hàm để load lại dữ liệu DataGridView
                    LoadCboDVT(); // Load lại combobox
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

        private void DgvDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDV.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["MaDichVu"].Value.ToString();
                txtTenDV.Text = row.Cells["TenDichVu"].Value.ToString();
                txtDonGia.Text = row.Cells["dongia"].Value.ToString();
                var cellValue = row.Cells["donvitinh"].Value;

                // Check if the cell value is null or empty
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    cbo_DVT.SelectedItem = cellValue.ToString();
                }
                else
                {
                    cbo_DVT.SelectedIndex = -1; // Clear the ComboBox selection
                }
            }
        }

        private void DgvDV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDV.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["MaDichVu"].Value.ToString();
                txtTenDV.Text = row.Cells["TenDichVu"].Value.ToString();
                txtDonGia.Text = row.Cells["dongia"].Value.ToString();
                var cellValue = row.Cells["donvitinh"].Value;

                // Check if the cell value is null or empty
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    cbo_DVT.SelectedItem = cellValue.ToString();
                }
                else
                {
                    cbo_DVT.SelectedIndex = -1; // Clear the ComboBox selection
                }
            }
        }

        private void FrmQL_DichVu_Load(object sender, EventArgs e)
        {
            LoadgvDV();
            LoadCboDVT();

            if(userRole!="ADMIN")
            {
                DisableUser();
            }    

        }
        public void DisableUser()
        {
            themToolStripMenuItem.Enabled = false;
            xoaToolStripMenuItem.Enabled = false;
            suaToolStripMenuItem.Enabled = false;
        }
        private void ClearFields()
        {
            txtMaDV.Text = string.Empty;
            txtTenDV.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            cbo_DVT.Text = string.Empty;
        }
        //private void AddNewDonViTinh(string donViTinh)
        //{
        //    string insertDonViTinhQuery = "INSERT INTO DonViTinh (TenDonViTinh) VALUES (@DonViTinh)";
        //    using (SqlCommand cmd = new SqlCommand(insertDonViTinhQuery, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@DonViTinh", donViTinh);

        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            cbo_DVT.Items.Add(donViTinh);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        public void LoadCboDVT()
        {
            List<string> existingItems = cbo_DVT.Items.Cast<string>().ToList();
            cbo_DVT.Items.Clear();

            string query = "SELECT DISTINCT DonViTinh FROM DichVu";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string donViTinh = reader["DonViTinh"].ToString();
                            cbo_DVT.Items.Add(donViTinh);
                        }
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
        public void LoadgvDV()
        {
            string select_dv = "select * from DICHVU";
            SqlDataAdapter da_dv = new SqlDataAdapter(select_dv, conn);
            DataTable dt_dv = new DataTable();
            da_dv.Fill(dt_dv);
            dgvDV.DataSource = dt_dv;
        }

    }
}
