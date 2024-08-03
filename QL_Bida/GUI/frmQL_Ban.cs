using DevExpress.XtraBars;
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
        public frmQL_Ban()
        {
            InitializeComponent();
            dgvBan.CellClick += DgvBan_CellClick;
            dgvBan.CellValueChanged += DgvBan_CellValueChanged;
            Load += FrmQL_Ban_Load;
            themToolStripMenuItem.Click += ThemToolStripMenuItem_Click;
            xoaToolStripMenuItem.Click += XoaToolStripMenuItem_Click;
            suaToolStripMenuItem.Click += SuaToolStripMenuItem_Click;
            searchToolStripMenuItem.Click += SearchToolStripMenuItem_Click;

            //
            cboLoaiBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhuVuc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maBan = txtMaBan.Text.Trim();
            string tenBan = txtTenBan.Text.Trim();
            string loaiBan = cboLoaiBan.SelectedItem?.ToString();
            string khuVuc = cboKhuVuc.SelectedItem?.ToString();
            string tinhTrang = cboTinhTrang.SelectedItem?.ToString();

            // Chuỗi truy vấn SQL để tìm kiếm theo các tiêu chí đã nhập
            string searchQuery = "SELECT MaBan, TenBan, CASE WHEN LoaiBan = 0 THEN N'Lỗ' ELSE N'France' END AS LoaiBan, KhuVuc, CASE WHEN TinhTrang = 1 THEN N'Còn' ELSE N'Hỏng' END AS TinhTrang, GiaThue FROM Ban WHERE 1 = 1";

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
                    adapter.SelectCommand.Parameters.AddWithValue("@TinhTrang", tinhTrang == "Hỏng" ? 0 : 1);
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

            //// Check if MaBan is a valid integer
            //if (!int.TryParse(txtMaBan.Text, out int maBan))
            //{
            //    MessageBox.Show("Mã bàn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Validate TenBan
            string tenBan = txtTenBan.Text;
            if (string.IsNullOrEmpty(tenBan))
            {
                MessageBox.Show("Tên bàn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //// Validate LoaiBan
            //string loaiBanStr = cboLoaiBan.SelectedItem?.ToString();
            //bool loaiBan;
            //if (loaiBanStr == "Lỗ")
            //{
            //    loaiBan = true;
            //}
            //else if (loaiBanStr == "France")
            //{
            //    loaiBan = false;
            //}
            //else
            //{
            //    MessageBox.Show("Loại bàn không hợp lệ! Chỉ được chọn 'Lỗ' hoặc 'France'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Validate KhuVuc
            //string khuVucStr = cboKhuVuc.SelectedItem?.ToString();
            //if (string.IsNullOrEmpty(khuVucStr) && !cboKhuVuc.Items.Contains(khuVucStr))
            //{
            //    MessageBox.Show("Khu vực không hợp lệ! Chọn một giá trị hợp lệ từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //int khuVuc;
            //if (!int.TryParse(khuVucStr, out khuVuc)&& !cboKhuVuc.Items.Contains(khuVucStr))
            //{
            //    MessageBox.Show("Khu vực không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Validate TinhTrang
            //string tinhTrangStr = cboTinhTrang.SelectedItem?.ToString();
            //bool tinhTrang;
            //if (tinhTrangStr == "Hỏng")
            //{
            //    tinhTrang = false;
            //}
            //else if (tinhTrangStr == "Còn")
            //{
            //    tinhTrang = true;
            //}
            //else
            //{
            //    MessageBox.Show("Tình trạng không hợp lệ! Chỉ được chọn 'Còn' hoặc 'Hỏng'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Validate GiaThue
            if (!float.TryParse(txtGiaThue.Text, out float giaThue))
            {
                MessageBox.Show("Giá thuê không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected values from ComboBox controls
            string loaiBan = cboLoaiBan.SelectedItem?.ToString();
            string khuVuc = cboKhuVuc.SelectedItem?.ToString();
            string tinhTrang = cboTinhTrang.SelectedItem?.ToString();

            // Ensure that ComboBox values are not null or empty
            if (string.IsNullOrEmpty(loaiBan) || string.IsNullOrEmpty(khuVuc) || string.IsNullOrEmpty(tinhTrang))
            {
                MessageBox.Show("Vui lòng chọn giá trị cho tất cả các trường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL Update command
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

                    // Check if the update was successful
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadgvBan(); // Method to refresh the DataGridView with updated data
                        LoadCboLoaiBan();
                        LoadCboKhuVuc();
                        LoadCboTinhTrang();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật bàn thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadgvBan(); // Method to refresh the DataGridView with updated data
                        LoadCboLoaiBan();
                        LoadCboKhuVuc();
                        LoadCboTinhTrang();
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
            string loaiBanText = cboLoaiBan.Text.Trim();
            int loaiBan;
            if (loaiBanText == "Lỗ")
            {
                loaiBan = 0;
            }
            else if (loaiBanText == "France")
            {
                loaiBan = 1;
            }
            else
            {
                MessageBox.Show("Loại bàn không hợp lệ!");
                return;
            }

            int khuVuc;
            if (!int.TryParse(cboKhuVuc.Text.Trim(), out khuVuc))
            {
                MessageBox.Show("Khu vực không hợp lệ!");
                return;
            }

            string tinhTrangText = cboTinhTrang.Text.Trim();
            int tinhTrang;
            if (tinhTrangText == "Hỏng")
            {
                tinhTrang = 0;
            }
            else if (tinhTrangText == "Còn")
            {
                tinhTrang = 1;
            }
            else
            {
                MessageBox.Show("Tình trạng không hợp lệ!");
                return;
            }

            string insertQuery = "INSERT INTO Ban (TenBan, GiaThue, LoaiBan, KhuVuc, TinhTrang) VALUES (@TenBan, @GiaThue, @LoaiBan, @KhuVuc, @TinhTrang)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenBan", tenBan);
                cmd.Parameters.AddWithValue("@GiaThue", giaThue);
                cmd.Parameters.AddWithValue("@LoaiBan", loaiBan); // Chuyển loaiBan thành bit
                cmd.Parameters.AddWithValue("@KhuVuc", khuVuc);
                cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang); // Chuyển tinhTrang thành bit

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm bàn thành công!");
                    LoadgvBan(); // Hàm để load lại dữ liệu DataGridView
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
                    if (cellValueLoaiBan == "Lỗ")
                    {
                        cboLoaiBan.SelectedItem = "Lỗ";
                    }
                    else if (cellValueLoaiBan == "France")
                    {
                        cboLoaiBan.SelectedItem = "France";
                    }
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
                    if (cellValueTinhTrang == "Còn")
                    {
                        cboTinhTrang.SelectedItem = "Còn";
                    }
                    else if (cellValueTinhTrang == "Hỏng")
                    {
                        cboTinhTrang.SelectedItem = "Hỏng";
                    }
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
                            cboTinhTrang.Items.Add(tinhTrang ? "Hỏng" : "Còn");
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
                WHEN LoaiBan = 1 THEN N'Lỗ' 
                ELSE 'France' 
            END AS LoaiBan, 
            KhuVuc, 
            CASE 
                WHEN TinhTrang = 1 THEN N'Còn' 
                ELSE N'Hỏng' 
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