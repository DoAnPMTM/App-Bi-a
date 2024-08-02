using DAL;
using DevExpress.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBan : Form
    {
        BAN b = new BAN();
        NHANVIEN nv = new NHANVIEN();
        KhachHangDAL khachHangDAL = new KhachHangDAL();
        BanDAL banDAL = new BanDAL();
        BienLaiDAL bienLaiDAL = new BienLaiDAL();
        ChiTietDVDAL chiTietDVDAL = new ChiTietDVDAL();
        int tongTienDV = 0;

        public frmBan()
        {
        }

        public frmBan(BAN b, NHANVIEN nv)
        {
            this.b = b;
            this.nv = nv;
            InitializeComponent();
            this.Size = new Size(940, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = nv.TENNV;
            label6.Text = b.TENBAN;
            btnIn.Enabled = false;
            loadCbKH();
            loadCbbBan();
            loadBienLai();
            panel5.Visible = false;
     




        }

        public void loadCbbBan()
        {
            List<BAN> listBan = banDAL.GetListBanTrong();
            List<BAN> listBan1 = listBan.Where(t => t.MABAN != b.MABAN).ToList();
            cbbBanTrong.DataSource = listBan1;
            cbbBanTrong.DisplayMember = "TENBAN";
            cbbBanTrong.ValueMember = "MABAN";


            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frm = new frmMain(nv);
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void loadCbKH()
        {
            cbbKH.DataSource = khachHangDAL.loadKH();
            cbbKH.DisplayMember = "TENKH";
            cbbKH.ValueMember = "MAKH";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BIENLAI bl = new BIENLAI();
            bl.GIOBD = DateTime.Now;
            bl.NGAYLAP = DateTime.Now;
            bl.MAKH = int.Parse(cbbKH.SelectedValue.ToString());
            bl.MABAN = b.MABAN;
            bl.MANHANVIEN = nv.MANHANVIEN;
            bl.TONGTIEN = 0;
            if(bienLaiDAL.themBienLai(bl))
            {
                MessageBox.Show("Bắt đầu tính giờ");
                loadBienLai();

            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
            



        }

        public void loadBienLai()
        {
            if(bienLaiDAL.getBienLai(b.MABAN) != null)
            {
                BIENLAI bl = bienLaiDAL.getBienLai(b.MABAN);
                cbbKH.SelectedValue = bl.MAKH;
                lblKH.Text = "Khách hàng: " + bl.KHACHHANG.TENKH;
                lblGBD.Text = "Giờ bắt đầu: " + bl.GIOBD.Value.ToString("HH:mm:ss");
                lblTongTien.Text = "Tổng tiền: ";
                cbbKH.Enabled = false;
                cbbBanTrong.Enabled = true;
                btnThem.Enabled = false;
                btnThanhToan.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                cbbKH.Enabled = true;
                cbbBanTrong.Enabled = false;
                btnThem.Enabled = true;
                btnThanhToan.Enabled = false;
                btnIn.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            BIENLAI bl = bienLaiDAL.getBienLai(b.MABAN);
            bl.GIOKT = DateTime.Now;
            double tongTien = 0;
            if (bl.GIOKT.Value.Minute - bl.GIOBD.Value.Minute == 0)
            {
                MessageBox.Show("Thanh toán thất bại");
                return;
            }
            if (bl.GIOKT.Value.Minute - bl.GIOBD.Value.Minute > 0)
            {
                tongTien = ((double)((bl.GIOKT.Value.Minute - bl.GIOBD.Value.Minute) * b.GIATHUE / 60));
            }
            else
            {
                tongTien = ((double)((bl.GIOKT.Value.Minute - bl.GIOBD.Value.Minute + 60) * b.GIATHUE / 60));
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tongTien += double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            //tong tien Chỉ lấy phần nguyên không lấy phần thập phân
            tongTien = Math.Truncate(tongTien);
            bl.TONGTIEN = tongTien;
           
            if (bienLaiDAL.thanhToan(bl))
            {
                MessageBox.Show("Thanh toán thành công");
                lblGKT.Text = "Giờ kết thúc: " + bl.GIOKT.Value.ToString("HH:mm:ss");
                lblTongTien.Text = "Tổng tiền: " + bl.TONGTIEN + "đ";
                btnThanhToan.Enabled = false;     
                btnIn.Enabled = true;
                cbbBanTrong.Enabled = false;
                button2.Enabled = false;
            }

            



        }

        private void cbbBanTrong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbBanTrong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int soBan = int.Parse(cbbBanTrong.SelectedValue.ToString());
            //Message box xác nhận khi chuyển bàn
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn chuyển sang bàn số " + soBan, "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BIENLAI bl = bienLaiDAL.getBienLai(b.MABAN);
                bl.MABAN = soBan;
                if (bienLaiDAL.doiBan(bl, soBan))
                {
                    MessageBox.Show("Chuyển bàn thành công");
                    //Cập nhật lại tình trạng bàn mới và cũ
                    BAN ban = banDAL.GetBanByMaBan(b.MABAN);
                    ban.TINHTRANG = false;
                    banDAL.suaBanTrong(ban);

                    BAN ban1 = banDAL.GetBanByMaBan(soBan);
                    ban1.TINHTRANG = true;
                    banDAL.suaBanTrong(ban1);

                    this.Close();
                    frmMain frm = new frmMain(nv);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Chuyển bàn thất bại");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel3.Visible = true;
            button1.BackColor = Color.DodgerBlue;
            button2.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            button2.BackColor = Color.DodgerBlue;
            button1.BackColor = Color.White;
            loadCBDV();
            loadCTDV();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
              
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void loadCTDV()
        {
            double tongTienDV = 0;
            dataGridView1.Rows.Clear();
            int mabl = bienLaiDAL.getBienLai(b.MABAN).MABIENLAI;
            List<CHITIETDV> lst = chiTietDVDAL.getChiTietDVByMaBienLai(mabl);
            foreach(CHITIETDV ct in lst)
            {
                int thanhTien = (int)(ct.SOLUONG * ct.DICHVU.DONGIA);
                tongTienDV += thanhTien;
                dataGridView1.Rows.Add(ct.DICHVU.TENDV, ct.SOLUONG, ct.DICHVU.DONGIA, thanhTien, ct.DICHVU.MADV, ct.MABIENLAI );
            }   
            lblTongDV.Text = "Tổng tiền dịch vụ: " + tongTienDV + "đ";
            
            
        }

       public void loadCBDV()
       {
            comboBox1.DataSource = chiTietDVDAL.loadDV();
            comboBox1.DisplayMember = "TENDV";
            comboBox1.ValueMember = "MADV";
       }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập số lượng");
                    return;
                }
                int mabl = bienLaiDAL.getBienLai(b.MABAN).MABIENLAI;
                int madv = int.Parse(comboBox1.SelectedValue.ToString());
                int soluong = int.Parse(textBox1.Text);
                CHITIETDV ct = new CHITIETDV();
                ct.MABIENLAI = mabl;
                ct.MADV = madv;
                ct.SOLUONG = soluong;
                chiTietDVDAL.themChiTietDV(ct);
                loadCTDV();
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int mabl = bienLaiDAL.getBienLai(b.MABAN).MABIENLAI;
                int madv = int.Parse(comboBox1.SelectedValue.ToString());
                chiTietDVDAL.xoaChiTietDV(mabl, madv);
                loadCTDV();
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
             
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int mabl = bienLaiDAL.getBienLai(b.MABAN).MABIENLAI;
                int madv = int.Parse(comboBox1.SelectedValue.ToString());
                int soluong = int.Parse(textBox1.Text);
                CHITIETDV ct = new CHITIETDV();
                ct.MABIENLAI = mabl;
                ct.MADV = madv;
                ct.SOLUONG = soluong;
                chiTietDVDAL.suaChiTietDV(ct);
                loadCTDV();

            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            BIENLAI bl = bienLaiDAL.getBienLai1(b.MABAN);
            string ngay = bl.NGAYLAP.Value.Day.ToString();
            string thang = bl.NGAYLAP.Value.Month.ToString();
            string nam = bl.NGAYLAP.Value.Year.ToString();
            string gioBD = bl.GIOBD.Value.Hour.ToString() + ":" + bl.GIOBD.Value.Minute.ToString() + ":" + bl.GIOBD.Value.Second.ToString();
            string gioKT = bl.GIOKT.Value.Hour.ToString() + ":" + bl.GIOKT.Value.Minute.ToString() + ":" + bl.GIOKT.Value.Second.ToString();
            string tongTien = bl.TONGTIEN.ToString();
            string maBL = bl.MABIENLAI.ToString();
            string tenNV = bl.NHANVIEN.TENNV;
            string tenKH = bl.KHACHHANG.TENKH;
            string maBan = bl.BAN.MABAN.ToString();
            WordExport wordExport = new WordExport();
            wordExport.BienLai(ngay, thang, nam, maBL, maBan, tenKH, gioBD, gioKT, tongTien, tenNV);

        }
    }
}
