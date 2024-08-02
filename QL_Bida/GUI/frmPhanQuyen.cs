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
    public partial class frmPhanQuyen : Form
    {
        NHANVIEN nv = new NHANVIEN();
        NhanVienDAL nvDAL = new NhanVienDAL();
        public frmPhanQuyen(NHANVIEN nv)
        {
            this.nv = nv;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loadNV();
        }

        public void loadNV()
        {
            dataGridView1.Rows.Clear();
            List<NHANVIEN> listNV = nvDAL.GetListNhanVien();
            foreach (NHANVIEN nv1 in listNV)
            {
                if(nv.MANHANVIEN != nv1.MANHANVIEN)
                {
                    dataGridView1.Rows.Add(nv1.MANHANVIEN, nv1.TENNV, nv1.QUYEN);

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nvDAL.updateQuyen(textBox1.Text, comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("Phân quyền thành công");
                loadNV();
            }
            else
            {
                MessageBox.Show("Phân quyền thất bại");
            }

        }

      
    }
}
