using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BienLaiDAL
    {
        QL_BidaDataContext db = new QL_BidaDataContext();
        public List<BIENLAI> GetListBienLai()
        {
            return db.BIENLAIs.ToList();
        }

        public BIENLAI getBienLai(int maban)
        {
            List<BIENLAI> lst = db.BIENLAIs.Where(t => t.MABAN == maban && t.BAN.TINHTRANG == true).OrderByDescending(t => t.MABIENLAI).ToList();
            return lst.FirstOrDefault();
        }

        public BIENLAI getBienLai1(int maban)
        {
            List<BIENLAI> lst = db.BIENLAIs.Where(t => t.MABAN == maban && t.BAN.TINHTRANG == false).OrderByDescending(t => t.MABIENLAI).ToList();
            return lst.FirstOrDefault();
        }

        public BIENLAI getBienLaiByMa(int mabl)
        {
            return db.BIENLAIs.Where(t => t.MABIENLAI == mabl).FirstOrDefault();
        }


        public bool themBienLai(BIENLAI bl)
        {
            try
            {
                db.BIENLAIs.InsertOnSubmit(bl);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool doiBan(BIENLAI bl, int maban)
        {
            try
            {
                BIENLAI bienLai = db.BIENLAIs.Where(t => t.MABIENLAI == bl.MABIENLAI).FirstOrDefault();
                bienLai.MABAN = maban;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool thanhToan(BIENLAI bl)
        {
            try
            {
                BIENLAI bienLai = db.BIENLAIs.Where(t => t.MABIENLAI == bl.MABIENLAI).FirstOrDefault();
                bienLai.GIOKT = bl.GIOKT;
                bienLai.TONGTIEN = bl.TONGTIEN;
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
