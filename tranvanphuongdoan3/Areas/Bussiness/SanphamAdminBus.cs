using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;

namespace tranvanphuongdoan3.Areas.Bussiness
{
    public class SanphamAdminBus
    {
        SanphamModel db = new SanphamModel();
        public List<Sanpham> layLoai(string maloai)
        {
          List<Sanpham> l = db.layLoai(maloai);
            return l;
        }
        public bool XoaLoai(string id)
        {            
            return db.XoaLoai(id); 
        }
        public bool Insert(Sanpham sp)
        {
            return db.Insert(sp);
        }
        public bool Update(Sanpham sp)
        {
            return db.Update(sp);
        }
    }
}