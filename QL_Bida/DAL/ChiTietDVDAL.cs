using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietDVDAL
    {
        QL_BidaDataContext db = new QL_BidaDataContext();

        public List<DICHVU> loadDV()
        {
            return db.DICHVUs.ToList();
        }

        public void themChiTietDV(CHITIETDV ct)
        {
            db.CHITIETDVs.InsertOnSubmit(ct);
            db.SubmitChanges();
        }

        public List<CHITIETDV> getChiTietDVByMaBienLai(int mabl)
        {
            return db.CHITIETDVs.Where(t => t.MABIENLAI == mabl).ToList();
        }

        public void xoaChiTietDV(int mabl, int madv)
        {
            CHITIETDV ct = db.CHITIETDVs.Where(t => t.MABIENLAI == mabl && t.MADV == madv).FirstOrDefault();
            db.CHITIETDVs.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }

        public void suaChiTietDV(CHITIETDV ctdv)
        {
            CHITIETDV ctnew = db.CHITIETDVs.Where(t => t.MABIENLAI == ctdv.MABIENLAI && t.MADV == ctdv.MADV).FirstOrDefault();
            ctnew.SOLUONG = ctdv.SOLUONG;
            db.SubmitChanges();
        }


    }
}
