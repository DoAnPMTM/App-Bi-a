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
    public partial class frmTaiKhoan : Form
    {
        NhanVienDAL nvDAL = new NhanVienDAL();

        public frmTaiKhoan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loadNV();
        }

        public void loadNV()
        {
            dataGridView1.Rows.Clear();
            List<NHANVIEN> listNV = nvDAL.GetListNhanVien();
            foreach (NHANVIEN nv in listNV)
            {
                dataGridView1.Rows.Add(nv.MANHANVIEN, nv.TENNV, nv.PASSNV);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nvDAL.updatePass(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Đổi mật khẩu thành công");
                loadNV();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại");
            }
        }

  
    }
}
