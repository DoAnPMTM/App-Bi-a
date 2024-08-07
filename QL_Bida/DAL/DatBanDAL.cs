using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatBanDAL
    {
        QL_BidaDataContext db = new QL_BidaDataContext();

        public List<DATBAN> loadDatBan()
        {
            return db.DATBANs.ToList();
        }

        public List<KHACHHANG> loadKhachHang()
        {
            return db.KHACHHANGs.ToList();
        }

        public List<BAN> loadBan()
        {
            return db.BANs.ToList();
        }

        public void addDatBan(DATBAN newDatBan)
        {
            db.GetTable<DATBAN>().InsertOnSubmit(newDatBan);
            db.SubmitChanges();
        }

        public class DatBan
        {
            public int MAKH { get; set; }
            public int MABAN { get; set; }
            public bool LOAIBAN { get; set; }
            public DateTime THOIGIANDEN { get; set; }
        }

    }
}
