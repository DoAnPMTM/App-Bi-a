using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BanDAL
    {
        QL_BidaDataContext db = new QL_BidaDataContext();
        public List<BAN> GetListBan()
        {
            return db.BANs.ToList();
        }
        public List<BAN> GetListBanTrong()
        {
            return db.BANs.Where(t => t.TINHTRANG == false).ToList();
        }

        public BAN GetBanByMaBan(int maBan)
        {
            return db.BANs.Where(t => t.MABAN == maBan).FirstOrDefault();
        }

        public bool themBan(BAN b)
        {
            try
            {
                db.BANs.InsertOnSubmit(b);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaBan(BAN b)
        {
            try
            {
                BAN ban = db.BANs.Where(t => t.MABAN == b.MABAN).FirstOrDefault();
                ban.TENBAN = b.TENBAN;
                ban.TINHTRANG = b.TINHTRANG;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaBanTrong(BAN b)
        {
            try
            {
                BAN ban = db.BANs.Where(t => t.MABAN == b.MABAN).FirstOrDefault();
                ban.TINHTRANG = b.TINHTRANG;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaBan(BAN b)
        {
            try
            {
                BAN ban = db.BANs.Where(t => t.MABAN == b.MABAN).FirstOrDefault();
                db.BANs.DeleteOnSubmit(ban);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BAN> timBan(string ten)
        {
            return db.BANs.Where(t => t.TENBAN.Contains(ten)).ToList<BAN>();
        }

    }
}
