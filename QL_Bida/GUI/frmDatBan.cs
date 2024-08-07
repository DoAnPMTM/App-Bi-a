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
    public partial class frmDatBan : Form
    {
        DatBanDAL datBanDAL = new DatBanDAL();
        public frmDatBan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            minimize_btn.FlatAppearance.BorderSize = 0;
            close_btn.FlatAppearance.BorderSize = 0;
            loadDatBan();
            
        }

        public void loadDatBan()
        {
            //load list view
            List<DATBAN> listDatBan = datBanDAL.loadDatBan();
            foreach (DATBAN db in listDatBan)
            {
                string loaiBan = db.LOAIBAN==false?"Bida france":"Bida lỗ";
               
                dataGridView1.Rows.Add(db.TENKH, db.SDT, loaiBan, db.THOIGIANDEN);
            }    
            
 
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDatBan_Load(object sender, EventArgs e)
        {
            loadDatBan();
        }
    }

    
}
