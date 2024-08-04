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
            
        }
        public frmMain()
        {
            


        }

        public void loadHienThi()
        {
            if(nv.QUYEN == "ADMIN")
            {
                tàiKhoảnToolStripMenuItem.Visible = true;
            }
            else
            {
                tàiKhoảnToolStripMenuItem.Visible = false;

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

        private void button3_Click(object sender, EventArgs e)
        {
            frmDatBan frm = new frmDatBan();
            frm.Show();


        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPhanQuyen frmPhanQuyen = new frmPhanQuyen(nv);
            frmPhanQuyen.ShowDialog();
            this.Show();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTaiKhoan frmTaiKhoan = new frmTaiKhoan();
            frmTaiKhoan.ShowDialog();
            this.Show();
        }
    }
}
