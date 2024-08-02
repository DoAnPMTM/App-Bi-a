using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        QL_BidaDataContext db = new QL_BidaDataContext();
        public List<NHANVIEN> GetListNhanVien()
        {
            return db.NHANVIENs.ToList();
        }

        public NHANVIEN GetNhanVienByMaNV(string maNV)
        {
            return db.NHANVIENs.Where(t => t.MANHANVIEN == maNV).FirstOrDefault();
        }

        public bool checkLogin(string maNV, string matKhau)
        {
            NHANVIEN nv = db.NHANVIENs.Where(t => t.MANHANVIEN == maNV && t.PASSNV == matKhau).FirstOrDefault();
            if (nv != null)
            {
                return true;
            }
            return false;
        }

        public bool updateQuyen(string maNV, string quyen)
        {
            try
            {
                NHANVIEN nv = db.NHANVIENs.Where(t => t.MANHANVIEN == maNV).FirstOrDefault();
                nv.QUYEN = quyen;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updatePass(string maNV, string pass)
        {
            try
            {
                NHANVIEN nv = db.NHANVIENs.Where(t => t.MANHANVIEN == maNV).FirstOrDefault();
                nv.PASSNV = pass;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }   

        public bool themNV(NHANVIEN nv)
        {
            try
            {
                db.NHANVIENs.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
