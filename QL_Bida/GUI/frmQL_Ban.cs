using DevExpress.XtraBars;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQL_Ban : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnn);
        DataSet ds_QLBida = new DataSet();
        SqlDataAdapter da_bida;
        private string userRole;
        public frmQL_Ban(string userRole)
        {
            InitializeComponent();
            dgvBan.CellClick += DgvBan_CellClick;
            dgvBan.CellValueChanged += DgvBan_CellValueChanged;
            Load += FrmQL_Ban_Load;
            themToolStripMenuItem.Click += ThemToolStripMenuItem_Click;
            xoaToolStripMenuItem.Click += XoaToolStripMenuItem_Click;
            suaToolStripMenuItem.Click += SuaToolStripMenuItem_Click;
            searchToolStripMenuItem.Click += SearchToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;

            //
            cboLoaiBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhuVuc.DropDownStyle = ComboBoxStyle.DropDownList;
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
            string maBan = txtMaBan.Text.Trim();
            string tenBan = txtTenBan.Text.Trim();
            string loaiBan = cboLoaiBan.SelectedItem?.ToString();
            string khuVuc = cboKhuVuc.SelectedItem?.ToString();
            string tinhTrang = cboTinhTrang.SelectedItem?.ToString();

            // Chuỗi truy vấn SQL để tìm kiếm theo các tiêu chí đã nhập
            string searchQuery = "SELECT MaBan, TenBan, CASE WHEN LoaiBan = 0 THEN N'Lỗ' ELSE N'France' END AS LoaiBan, KhuVuc, CASE WHEN TinhTrang = 1 THEN N'Đã đặt' ELSE N'Trống' END AS TinhTrang, GiaThue FROM Ban WHERE 1 = 1";

            if (!string.IsNullOrEmpty(maBan))
            {
                searchQuery += " AND MaBan = @MaBan";
            }
            if (!string.IsNullOrEmpty(tenBan))
            {
                searchQuery += " AND TenBan LIKE @TenBan";
            }
            if (!string.IsNullOrEmpty(loaiBan))
            {
                searchQuery += " AND LoaiBan = @LoaiBan";
            }
            if (!string.IsNullOrEmpty(khuVuc))
            {
                searchQuery += " AND KhuVuc = @KhuVuc";
            }
            if (!string.IsNullOrEmpty(tinhTrang))
            {
                searchQuery += " AND TinhTrang = @TinhTrang";
            }

            using (SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, conn))
            {
                // Thêm tham số vào câu truy vấn
                if (!string.IsNullOrEmpty(maBan))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@MaBan", maBan);
                }
                if (!string.IsNullOrEmpty(tenBan))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@TenBan", "%" + tenBan + "%");
                }
                if (!string.IsNullOrEmpty(loaiBan))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@LoaiBan", loaiBan == "Lỗ" ? 0 : 1);
                }
                if (!string.IsNullOrEmpty(khuVuc))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@KhuVuc", khuVuc);
                }
                if (!string.IsNullOrEmpty(tinhTrang))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@TinhTrang", tinhTrang == "Trống" ? 0 : 1);
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
                        MessageBox.Show("Không tìm thấy bàn nào phù hợp !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Tìm kiếm thành công! Có {rowCount} bàn được tìm thấy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Đặt lại nguồn dữ liệu cho DataGridView để hiển thị kết quả
                    dgvBan.DataSource = dt;
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
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenBan = txtTenBan.Text.Trim();
            if (string.IsNullOrEmpty(tenBan))
            {
                MessageBox.Show("Tên bàn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtGiaThue.Text, out float giaThue))
            {
                MessageBox.Show("Giá thuê không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int loaiBan = cboLoaiBan.Text.Trim() == "Lỗ" ? 0 : 1;
            string khuVuc = cboKhuVuc.Text.Trim();
            int tinhTrang = cboTinhTrang.Text.Trim() == "Đã đặt" ? 1 : 0;

            string query = "UPDATE Ban SET TenBan = @TenBan, LoaiBan = @LoaiBan, KhuVuc = @KhuVuc, TinhTrang = @TinhTrang, GiaThue = @GiaThue WHERE MaBan = @MaBan";

            try
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaBan", txtMaBan.Text.Trim());
                    command.Parameters.AddWithValue("@TenBan", tenBan);
                    command.Parameters.AddWithValue("@LoaiBan", loaiBan);
                    command.Parameters.AddWithValue("@KhuVuc", khuVuc);
                    command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                    command.Parameters.AddWithValue("@GiaThue", giaThue);

                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadgvBan();
                        LoadCboKhuVuc();
                        LoadCboLoaiBan();
                        LoadCboTinhTrang();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật bàn thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void XoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa!");
                return;
            }

            int maBan;
            if (!int.TryParse(txtMaBan.Text.Trim(), out maBan))
            {
                MessageBox.Show("Mã bàn không hợp lệ!");
                return;
            }

            string deleteQuery = "DELETE FROM Ban WHERE MaBan = @MaBan";
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa bàn thành công!");
                    LoadgvBan();
                    LoadCboLoaiBan();
                    LoadCboKhuVuc();
                    LoadCboTinhTrang();
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

        private void ThemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenBan.Text) || string.IsNullOrEmpty(txtGiaThue.Text) || string.IsNullOrEmpty(cboLoaiBan.Text) || string.IsNullOrEmpty(cboKhuVuc.Text) || string.IsNullOrEmpty(cboTinhTrang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string tenBan = txtTenBan.Text.Trim();
            decimal giaThue;
            if (!decimal.TryParse(txtGiaThue.Text.Trim(), out giaThue))
            {
                MessageBox.Show("Giá thuê không hợp lệ!");
                return;
            }

            int loaiBan = cboLoaiBan.Text.Trim() == "Lỗ" ? 0 : 1;
            string khuVuc = cboKhuVuc.Text.Trim();
            int tinhTrang = cboTinhTrang.Text.Trim() == "Đã đặt" ? 1 : 0;

            string insertQuery = "INSERT INTO Ban (TenBan, GiaThue, LoaiBan, KhuVuc, TinhTrang) VALUES (@TenBan, @GiaThue, @LoaiBan, @KhuVuc, @TinhTrang)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenBan", tenBan);
                cmd.Parameters.AddWithValue("@GiaThue", giaThue);
                cmd.Parameters.AddWithValue("@LoaiBan", loaiBan);
                cmd.Parameters.AddWithValue("@KhuVuc", khuVuc);
                cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm bàn thành công!");
                    LoadgvBan();
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

        private void FrmQL_Ban_Load(object sender, EventArgs e)
        {
            LoadgvBan();
            LoadCboLoaiBan();
            LoadCboKhuVuc();
            LoadCboTinhTrang();

            dgvBan.Columns["MaBan"].ReadOnly = true;
            dgvBan.Columns["LoaiBan"].ReadOnly = true;
            dgvBan.Columns["KhuVuc"].ReadOnly = true;
            dgvBan.Columns["TinhTrang"].ReadOnly = true;

            // Disable buttons if user is not an admin
            if (userRole != "ADMIN")
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

        private void DgvBan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBan.Rows[e.RowIndex];
                txtMaBan.Text = row.Cells["MaBan"].Value.ToString();
                txtTenBan.Text = row.Cells["TenBan"].Value.ToString();
                txtGiaThue.Text = row.Cells["GiaThue"].Value.ToString();
                var cellValue = row.Cells["LoaiBan"].Value;
                // Kiểm tra nếu giá trị rỗng
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    cboLoaiBan.SelectedItem = cellValue.ToString();
                }
                else
                {
                    cboLoaiBan.SelectedIndex = -1; // clear value text
                }
                //Khu vực
                var cellValueKV = row.Cells["KhuVuc"].Value;
                // Kiểm tra nếu giá trị rỗng
                if (cellValueKV != null && !string.IsNullOrEmpty(cellValueKV.ToString()))
                {
                    cboKhuVuc.SelectedItem = cellValueKV.ToString();
                }
                else
                {
                    cboKhuVuc.SelectedIndex = -1; // clear value text
                }
                //Tình trạng
                var cellValueTT = row.Cells["TinhTrang"].Value;

                // Kiểm tra nếu giá trị rỗng
                if (cellValueTT != null && !string.IsNullOrEmpty(cellValueTT.ToString()))
                {
                    cboLoaiBan.SelectedItem = cellValueTT.ToString();
                }
                else
                {
                    cboLoaiBan.SelectedIndex = -1; // clear value text
                }
                //cboLoaiBan.SelectedItem = row.Cells["LoaiBan"].Value.ToString();
                //cboKhuVuc.SelectedItem = row.Cells["KhuVuc"].Value.ToString();
                //cboTinhTrang.SelectedItem = row.Cells["TinhTrang"].Value.ToString();
            }
        }

        private void DgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBan.Rows[e.RowIndex];
                txtMaBan.Text = row.Cells["MaBan"].Value.ToString();
                txtTenBan.Text = row.Cells["TenBan"].Value.ToString();
                txtGiaThue.Text = row.Cells["GiaThue"].Value.ToString();

                // Thiết lập giá trị cho cboLoaiBan
                var cellValueLoaiBan = row.Cells["LoaiBan"].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValueLoaiBan))
                {
                    cboLoaiBan.SelectedItem = cellValueLoaiBan;
                }
                else
                {
                    cboLoaiBan.SelectedIndex = -1; // clear value text
                }

                // Thiết lập giá trị cho cboKhuVuc
                var cellValueKhuVuc = row.Cells["KhuVuc"].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValueKhuVuc))
                {
                    cboKhuVuc.SelectedItem = cellValueKhuVuc;
                }
                else
                {
                    cboKhuVuc.SelectedIndex = -1; // clear value text
                }

                // Thiết lập giá trị cho cboTinhTrang
                var cellValueTinhTrang = row.Cells["TinhTrang"].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValueTinhTrang))
                {
                    cboTinhTrang.SelectedItem = cellValueTinhTrang;
                }
                else
                {
                    cboTinhTrang.SelectedIndex = -1; // clear value text
                }
            }
        }
        private void ClearFields()
        {
            txtMaBan.Text = string.Empty;
            txtTenBan.Text = string.Empty;
            cboLoaiBan.Text = string.Empty;
            cboKhuVuc.Text = string.Empty;
            cboTinhTrang.Text = string.Empty;
            txtGiaThue.Text = string.Empty;
        }

        public void LoadCboLoaiBan()
        {
            List<string> existingItems = cboLoaiBan.Items.Cast<string>().ToList();
            cboLoaiBan.Items.Clear();

            string query = "SELECT DISTINCT LoaiBan FROM Ban";
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
                            bool loaiBan = (bool)reader["LoaiBan"];
                            cboLoaiBan.Items.Add(loaiBan ? "France" : "Lỗ");
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

        public void LoadCboTinhTrang()
        {
            List<string> existingItems = cboTinhTrang.Items.Cast<string>().ToList();
            cboTinhTrang.Items.Clear();

            string query = "SELECT DISTINCT TinhTrang FROM Ban";
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
                            bool tinhTrang = (bool)reader["TinhTrang"];
                            cboTinhTrang.Items.Add(tinhTrang ? "Đã đặt" : "Trống");
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

        public void LoadCboKhuVuc()
        {
            List<string> existingItems = cboKhuVuc.Items.Cast<string>().ToList();
            cboKhuVuc.Items.Clear();

            string query = "SELECT DISTINCT KhuVuc FROM Ban";
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
                            string khuVuc = reader["KhuVuc"].ToString();
                            cboKhuVuc.Items.Add(khuVuc);
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
        public void LoadgvBan()
        {
            string select_ban = @"
            SELECT 
                MaBan, 
                TenBan, 
                CASE 
                    WHEN LoaiBan = 0 THEN N'Lỗ' 
                    ELSE N'France' 
                END AS LoaiBan, 
                KhuVuc, 
                CASE 
                    WHEN TinhTrang = 1 THEN N'Đã đặt' 
                    ELSE N'Trống' 
                END AS TinhTrang, 
                GiaThue 
            FROM Ban";

            SqlDataAdapter da_ban = new SqlDataAdapter(select_ban, conn);
            DataTable dt_ban = new DataTable();
            da_ban.Fill(dt_ban);
            dgvBan.DataSource = dt_ban;
        }
    }
}