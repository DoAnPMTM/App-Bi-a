using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace GUI
{
    public partial class frmMain : Form
    {
        NHANVIEN nv = new NHANVIEN();
        BanDAL banDAL = new BanDAL();
        DatBanDAL db = new DatBanDAL();
        public frmMain(NHANVIEN nv)
        {
            this.nv = nv;
            InitializeComponent();
            minimize_btn.FlatAppearance.BorderSize = 0;
            close_btn.FlatAppearance.BorderSize = 0;
            this.Size = new Size(950, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            loadHienThi();
            label1.Text = nv.TENNV;
            getTable1();
            updateDatBanButton();
            dịchVụToolStripMenuItem.Click += DịchVụToolStripMenuItem_Click;
            kháchHàngToolStripMenuItem.Click += KháchHàngToolStripMenuItem_Click;
            nhânViênToolStripMenuItem.Click += NhânViênToolStripMenuItem_Click;
            phânQuyềnToolStripMenuItem.Click += PhânQuyềnToolStripMenuItem_Click;
            tạoTàiKhoảnToolStripMenuItem.Click += TạoTàiKhoảnToolStripMenuItem_Click;
            btnDatBan.Click += BtnDatBan_Click;
            timerDateTime.Tick += TimerDateTime_Tick;
            timerDateTime.Start();
        }

        private void TạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the panels
            this.bida_panel1.Visible = false;
            this.flowLayoutPanel1.Visible = false;
            this.panel1.Visible = false;

            // Create and display the frmQL_Ban form
            frmTaiKhoan tk = new frmTaiKhoan();
            tk.TopLevel = false; // Set to false to add to a panel
            tk.FormBorderStyle = FormBorderStyle.None; // Optional: remove form borders
            tk.Dock = DockStyle.Fill; // Make it fill the panel

            // Attach the FormClosed event handler
            tk.FormClosed += Tk_FormClosed;

            this.bida_panel.Controls.Clear(); // Clear previous controls if needed
            this.bida_panel.Controls.Add(tk); // Add to the panel
            tk.Show();
        }

        private void Tk_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain main = new frmMain(nv);
            main.Show();
            this.Close();
        }

        private void PhânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the panels
            this.bida_panel1.Visible = false;
            this.flowLayoutPanel1.Visible = false;
            this.panel1.Visible = false;

            // Create and display the frmQL_Ban form
            frmPhanQuyen pq = new frmPhanQuyen(nv);
            pq.TopLevel = false; // Set to false to add to a panel
            pq.FormBorderStyle = FormBorderStyle.None; // Optional: remove form borders
            pq.Dock = DockStyle.Fill; // Make it fill the panel

            // Attach the FormClosed event handler
            pq.FormClosed += Pq_FormClosed;

            this.bida_panel.Controls.Clear(); // Clear previous controls if needed
            this.bida_panel.Controls.Add(pq); // Add to the panel
            pq.Show();
        }

        private void Pq_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain main = new frmMain(nv);
            main.Show();
            this.Close();
        }

        private void BtnDatBan_Click(object sender, EventArgs e)
        {
            // Hide the panels
            this.bida_panel1.Visible = false;
            this.flowLayoutPanel1.Visible = false;
            this.panel1.Visible = false;

            // Create and display the frmQL_Ban form
            frmDatBan db = new frmDatBan();
            db.TopLevel = false; // Set to false to add to a panel
            db.FormBorderStyle = FormBorderStyle.None; // Optional: remove form borders
            db.Dock = DockStyle.Fill; // Make it fill the panel

            // Attach the FormClosed event handler
            db.FormClosed += Db_FormClosed;

            this.bida_panel.Controls.Clear(); // Clear previous controls if needed
            this.bida_panel.Controls.Add(db); // Add to the panel
            db.Show();
        }
        private void Db_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain main = new frmMain(nv);
            main.Show();
            this.Close();
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm tt\ndd/MM/yyyy");
        }

        private void updateDatBanButton()
        {
            int datBanCount = db.loadDatBan().Count;
            btnDatBan.Text = $"Đặt bàn ({datBanCount})";
        }

        private void NhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the panels
            this.bida_panel1.Visible = false;
            this.flowLayoutPanel1.Visible = false;
            this.panel1.Visible = false;

            // Create and display the frmQL_Ban form
            frmQL_NhanVien nv = new frmQL_NhanVien();
            nv.TopLevel = false; // Set to false to add to a panel
            nv.FormBorderStyle = FormBorderStyle.None; // Optional: remove form borders
            nv.Dock = DockStyle.Fill; // Make it fill the panel

            // Attach the FormClosed event handler
            nv.FormClosed += Nv_FormClosed;

            this.bida_panel.Controls.Clear(); // Clear previous controls if needed
            this.bida_panel.Controls.Add(nv); // Add to the panel
            nv.Show();
        }

        private void Nv_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frm = new frmMain(nv);
            frm.Show();
            this.Close();
        }

        private void KháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the panels
            this.bida_panel1.Visible = false;
            this.flowLayoutPanel1.Visible = false;
            this.panel1.Visible = false;

            // Create and display the frmQL_Ban form
            frmQL_KhachHang kh = new frmQL_KhachHang(nv.QUYEN);
            kh.TopLevel = false; // Set to false to add to a panel
            kh.FormBorderStyle = FormBorderStyle.None; // Optional: remove form borders
            kh.Dock = DockStyle.Fill; // Make it fill the panel

            // Attach the FormClosed event handler
            kh.FormClosed += Kh_FormClosed;

            this.bida_panel.Controls.Clear(); // Clear previous controls if needed
            this.bida_panel.Controls.Add(kh); // Add to the panel
            kh.Show(); // Show the form
        }

        private void Kh_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frm = new frmMain(nv);
            frm.Show();
            this.Close();
        }

        private void DịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the panels
            this.bida_panel1.Visible = false;
            this.flowLayoutPanel1.Visible = false;
            this.panel1.Visible = false;

            // Create and display the frmQL_Ban form
            frmQL_DichVu dv = new frmQL_DichVu(nv.QUYEN);
            dv.TopLevel = false; // Set to false to add to a panel
            dv.FormBorderStyle = FormBorderStyle.None; // Optional: remove form borders
            dv.Dock = DockStyle.Fill; // Make it fill the panel

            // Attach the FormClosed event handler
            dv.FormClosed += Dv_FormClosed;

            this.bida_panel.Controls.Clear(); // Clear previous controls if needed
            this.bida_panel.Controls.Add(dv); // Add to the panel
            dv.Show(); // Show the form
        }

        private void Dv_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frm = new frmMain(nv);
            frm.Show();
            this.Close();
        }

        public frmMain()
        {
            


        }

        public void loadHienThi()
        {
            if(nv.QUYEN == "ADMIN")
            {
                tàiKhoảnToolStripMenuItem.Visible = true;
                nhânViênToolStripMenuItem.Visible=true;
            }
            else
            {
                tàiKhoảnToolStripMenuItem.Visible = false;
                nhânViênToolStripMenuItem.Visible = false;
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

       

      

        public void getTable1()
        {
            List<BAN> listBan = banDAL.GetListBan();
            int d = 0;
            int c = 0;
            int r = 6;
            for(int i = 0; i < listBan.Count; i++)
            {
                BAN ban = listBan[i];
                if(ban.KHUVUC == 1)
                {
                    Button btn = new Button();
                    this.bida_panel.Controls.Add(btn);
                    this.bida_panel.BringToFront();
                    this.bida_panel1.SendToBack();
                    btn.BackColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseDownBackColor = Color.LightGray;
                    btn.FlatAppearance.MouseOverBackColor = Color.LightGray;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.Size = new Size(83, 147);
                    btn.TabIndex = 2;
                    btn.Text = "Bàn " + listBan[i].MABAN;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.UseVisualStyleBackColor = false;
                    if (listBan[i].TINHTRANG == false)
                    {
                        if (listBan[i].LOAIBAN == false)
                        {
                            btn.Image = global::GUI.Properties.Resources.bidafrace;
                        }
                        else
                        {
                            btn.Image = global::GUI.Properties.Resources.bida;
                        }
                    }
                    else
                    {
                        if (listBan[i].LOAIBAN == false)
                        {
                            btn.Image = global::GUI.Properties.Resources.bidafrance_s;
                        }
                        else
                        {
                            btn.Image = global::GUI.Properties.Resources.bida_s;
                        }
                    }
                    btn.Click += (s, e) =>
                    {
                        frmBan frm = new frmBan(ban, nv);
                        frm.Show();
                        this.Hide();
                     
                    };
                    if(r > 0)
                    {
                        btn.Left = c * 120;
                        c = c + 1;
                        btn.Top = d * 158;
                        r--;
                    }
                    else
                    {
                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c * 120;
                        c++;
                        btn.Top = d * 158;
                        r--;
                    }
                }
            }    

        }

        public void getTable2()
        {
            List<BAN> listBan = banDAL.GetListBan();
            int d = 0;
            int c = 0;
            int r = 6;
            for (int i = 0; i < listBan.Count; i++)
            {
                BAN ban = listBan[i];
                if (ban.KHUVUC == 2)
                {
                    Button btn = new Button();
                    this.bida_panel1.Controls.Add(btn);
                    this.bida_panel1.BringToFront();
                    btn.BackColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseDownBackColor = Color.LightGray;
                    btn.FlatAppearance.MouseOverBackColor = Color.LightGray;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.Size = new Size(83, 147);
                    btn.TabIndex = 2;
                    btn.Text = "Bàn " + listBan[i].MABAN;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.UseVisualStyleBackColor = false;
                    if (listBan[i].TINHTRANG == false)
                    {
                        if (listBan[i].LOAIBAN == false)
                        {
                            btn.Image = global::GUI.Properties.Resources.bidafrace;
                        }
                        else
                        {
                            btn.Image = global::GUI.Properties.Resources.bida;
                        }
                    }
                    else
                    {
                        if (listBan[i].LOAIBAN == false)
                        {
                            btn.Image = global::GUI.Properties.Resources.bidafrance_s;
                        }
                        else
                        {
                            btn.Image = global::GUI.Properties.Resources.bida_s;
                        }
                    }
                    btn.Click += (s, e) =>
                    {
                        frmBan frm = new frmBan(ban, nv);
                        frm.Show();
                        this.Hide();
                        
                    };
                    if (r > 0)
                    {
                        btn.Left = c * 120;
                        c = c + 1;
                        btn.Top = d * 158;
                        r--;
                    }
                    else
                    {
                        r = 6;
                        d++;
                        c = 0;
                        btn.Left = c * 120;
                        c++;
                        btn.Top = d * 158;
                        r--;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getTable2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getTable1();
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDN frm = new frmDN();
            frm.Show();
        }

        private void bànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the panels
            this.bida_panel1.Visible = false;
            this.flowLayoutPanel1.Visible = false;
            this.panel1.Visible = false;

            // Create and display the frmQL_Ban form
            frmQL_Ban ban = new frmQL_Ban(nv.QUYEN);
            ban.TopLevel = false; // Set to false to add to a panel
            ban.FormBorderStyle = FormBorderStyle.None; // Optional: remove form borders
            ban.Dock = DockStyle.Fill; // Make it fill the panel

            // Attach the FormClosed event handler
            ban.FormClosed += Ban_FormClosed;

            this.bida_panel.Controls.Clear(); // Clear previous controls if needed
            this.bida_panel.Controls.Add(ban); // Add to the panel
            ban.Show(); // Show the form
        }

        private void Ban_FormClosed(object sender, FormClosedEventArgs e)
        {
            //// Show the panels again
            //this.bida_panel1.Visible = true;
            //this.flowLayoutPanel1.Visible = true;
            //this.panel1.Visible = true;
            frmMain frm = new frmMain(nv);
            frm.Show();
            this.Close();
        }

        private void bida_panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sƠĐỒBÀNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain(nv);
            frmMain.Show();
            this.Close();
        }
    }
}
