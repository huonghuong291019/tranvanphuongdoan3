using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;

namespace tranvanphuongdoan3.Areas.Bussiness
{
    public class LoaiBus
    {
        LoaiModel db = new LoaiModel();
        public List<Loai> layLoai()
        {
            List<Loai> l = db.layLoai();
            return l;
        }
        public bool XoaLoai(string id)
        {
            return db.XoaLoai(id);
        }
        public bool Insert(Loai sp)
        {
            return db.Insert(sp);
        }
        public bool Update(Loai sp)
        {
            return db.Update(sp);
        }
    }
}