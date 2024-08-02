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

    }
}
