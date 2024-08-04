namespace GUI
{
    partial class frmQL_Ban
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dgvBan = new System.Windows.Forms.DataGridView();
            this.maban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khuvuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhtrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giathue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboLoaiBan = new System.Windows.Forms.ComboBox();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiaThue = new System.Windows.Forms.TextBox();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.themToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1249, 63);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH BÀN";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themToolStripMenuItem,
            this.xoaToolStripMenuItem,
            this.suaToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 67);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(483, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dgvBan
            // 
            this.dgvBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maban,
            this.tenban,
            this.loaiban,
            this.khuvuc,
            this.tinhtrang,
            this.giathue});
            this.dgvBan.Location = new System.Drawing.Point(443, 154);
            this.dgvBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.RowHeadersWidth = 51;
            this.dgvBan.RowTemplate.Height = 24;
            this.dgvBan.Size = new System.Drawing.Size(794, 291);
            this.dgvBan.TabIndex = 55;
            // 
            // maban
            // 
            this.maban.DataPropertyName = "MABAN";
            this.maban.HeaderText = "Mã Bàn";
            this.maban.MinimumWidth = 6;
            this.maban.Name = "maban";
            this.maban.Width = 125;
            // 
            // tenban
            // 
            this.tenban.DataPropertyName = "TENBAN";
            this.tenban.HeaderText = "Tên Bàn";
            this.tenban.MinimumWidth = 6;
            this.tenban.Name = "tenban";
            this.tenban.Width = 125;
            // 
            // loaiban
            // 
            this.loaiban.DataPropertyName = "LOAIBAN";
            this.loaiban.HeaderText = "Loại Bàn";
            this.loaiban.MinimumWidth = 6;
            this.loaiban.Name = "loaiban";
            this.loaiban.Width = 125;
            // 
            // khuvuc
            // 
            this.khuvuc.DataPropertyName = "KHUVUC";
            this.khuvuc.HeaderText = "Khu Vực";
            this.khuvuc.MinimumWidth = 6;
            this.khuvuc.Name = "khuvuc";
            this.khuvuc.Width = 125;
            // 
            // tinhtrang
            // 
            this.tinhtrang.DataPropertyName = "TINHTRANG";
            this.tinhtrang.HeaderText = "Tình Trạng";
            this.tinhtrang.MinimumWidth = 6;
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Width = 125;
            // 
            // giathue
            // 
            this.giathue.DataPropertyName = "GIATHUE";
            this.giathue.HeaderText = "Giá Thuê";
            this.giathue.MinimumWidth = 6;
            this.giathue.Name = "giathue";
            this.giathue.Width = 125;
            // 
            // cboLoaiBan
            // 
            this.cboLoaiBan.FormattingEnabled = true;
            this.cboLoaiBan.Location = new System.Drawing.Point(110, 254);
            this.cboLoaiBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLoaiBan.Name = "cboLoaiBan";
            this.cboLoaiBan.Size = new System.Drawing.Size(294, 24);
            this.cboLoaiBan.TabIndex = 82;
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.Location = new System.Drawing.Point(110, 308);
            this.cboKhuVuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(294, 24);
            this.cboKhuVuc.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 80;
            this.label6.Text = "Gia Thue";
            // 
            // txtGiaThue
            // 
            this.txtGiaThue.Location = new System.Drawing.Point(110, 422);
            this.txtGiaThue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGiaThue.Name = "txtGiaThue";
            this.txtGiaThue.Size = new System.Drawing.Size(294, 23);
            this.txtGiaThue.TabIndex = 83;
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(110, 366);
            this.cboTinhTrang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(294, 24);
            this.cboTinhTrang.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "Tình Trạng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Khu vực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 76;
            this.label3.Text = "Loại bàn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 75;
            this.label2.Text = "Tên Bàn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 74;
            this.label7.Text = "Mã Bàn";
            // 
            // txtTenBan
            // 
            this.txtTenBan.Location = new System.Drawing.Point(110, 201);
            this.txtTenBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(294, 23);
            this.txtTenBan.TabIndex = 73;
            // 
            // txtMaBan
            // 
            this.txtMaBan.Enabled = false;
            this.txtMaBan.Location = new System.Drawing.Point(110, 151);
            this.txtMaBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.ReadOnly = true;
            this.txtMaBan.Size = new System.Drawing.Size(294, 23);
            this.txtMaBan.TabIndex = 72;
            // 
            // themToolStripMenuItem
            // 
            this.themToolStripMenuItem.Image = global::GUI.Properties.Resources.add;
            this.themToolStripMenuItem.Name = "themToolStripMenuItem";
            this.themToolStripMenuItem.Size = new System.Drawing.Size(94, 32);
            this.themToolStripMenuItem.Text = "Thêm";
            // 
            // xoaToolStripMenuItem
            // 
            this.xoaToolStripMenuItem.Image = global::GUI.Properties.Resources.delete;
            this.xoaToolStripMenuItem.Name = "xoaToolStripMenuItem";
            this.xoaToolStripMenuItem.Size = new System.Drawing.Size(80, 32);
            this.xoaToolStripMenuItem.Text = "Xóa";
            // 
            // suaToolStripMenuItem
            // 
            this.suaToolStripMenuItem.Image = global::GUI.Properties.Resources.edit;
            this.suaToolStripMenuItem.Name = "suaToolStripMenuItem";
            this.suaToolStripMenuItem.Size = new System.Drawing.Size(79, 32);
            this.suaToolStripMenuItem.Text = "Sửa";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = global::GUI.Properties.Resources.search;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(125, 32);
            this.searchToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.closeToolStripMenuItem.Image = global::GUI.Properties.Resources.close;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(95, 32);
            this.closeToolStripMenuItem.Text = "Đóng";
            // 
            // frmQL_Ban
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1249, 515);
            this.Controls.Add(this.cboLoaiBan);
            this.Controls.Add(this.cboKhuVuc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGiaThue);
            this.Controls.Add(this.cboTinhTrang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.txtMaBan);
            this.Controls.Add(this.dgvBan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmQL_Ban";
            this.Text = "frmQL_Ban";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem themToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn maban;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenban;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiban;
        private System.Windows.Forms.DataGridViewTextBoxColumn khuvuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhtrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn giathue;
        private System.Windows.Forms.ComboBox cboLoaiBan;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGiaThue;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.TextBox txtMaBan;
    }
}