using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        QL_BidaDataContext db = new QL_BidaDataContext();
        public List<KHACHHANG> loadKH()
        {
            return db.KHACHHANGs.ToList();
        }
        public bool themKH(KHACHHANG kh)
        {
            try
            {
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suaKH(KHACHHANG kh)
        {
            try
            {
                KHACHHANG k = db.KHACHHANGs.Where(t => t.MAKH == kh.MAKH).FirstOrDefault();
                k.TENKH = kh.TENKH;
                k.SDT = kh.SDT;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoaKH(KHACHHANG kh)
        {
            try
            {
                KHACHHANG k = db.KHACHHANGs.Where(t => t.MAKH == kh.MAKH).FirstOrDefault();
                db.KHACHHANGs.DeleteOnSubmit(k);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<KHACHHANG> timKH(string ten)
        {
            return db.KHACHHANGs.Where(t => t.TENKH.Contains(ten)).ToList<KHACHHANG>();
        }
    
    
    }
}
