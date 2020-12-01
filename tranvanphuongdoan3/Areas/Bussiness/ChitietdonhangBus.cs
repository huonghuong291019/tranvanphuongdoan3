using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;

namespace tranvanphuongdoan3.Areas.Bussiness
{
    public class ChitietdonhangBus
    {
        ChitietdonhangModel db = new ChitietdonhangModel();
        public List<Chitietdonhang> laydhma(string madh)
        {
            List<Chitietdonhang> l = db.laydhma(madh);
            return l;
        }
        public List<Chitietdonhang> laydh()
        {
            List<Chitietdonhang> l = db.laydh();
            return l;
        }
    }
}