using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Bussiness
{
    public class NhacungcapBus
    {
        NhacungcapModel db = new NhacungcapModel();
        public List<Nhacungcap> layLoai()
        {
            List<Nhacungcap> l = db.layLoai();
            return l;
        }
        public bool XoaLoai(string id)
        {
            return db.XoaLoai(id);
        }
        public bool Insert(Nhacungcap l)
        {
            return db.Insert(l);
        }
        public bool Update(Nhacungcap n)
        {
            return db.Update(n);
        }
    }
}