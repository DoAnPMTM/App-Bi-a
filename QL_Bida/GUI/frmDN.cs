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

namespace GUI
{
    public partial class frmDN : Form
    {
        NhanVienDAL nhanVienDAL = new NhanVienDAL();
        public frmDN()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if(nhanVienDAL.checkLogin(txtUsername.Text, txtPwd.Text))
            {
                NHANVIEN nv = nhanVienDAL.GetNhanVienByMaNV(txtUsername.Text);
                this.Hide();
                frmMain frmMain = new frmMain(nv);
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
