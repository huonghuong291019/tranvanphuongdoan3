using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Bussiness
{
    public class KhachhangAdminBus
    {
        KhachhangModel db = new KhachhangModel();
        public List<Khachhang> layLoai()
        {
            List<Khachhang> l = db.layLoai();
            return l;
        }
        public bool XoaLoai(string id)
        {
            return db.XoaLoai(id);
        }
        public bool Insert(Khachhang k)
        {
            return db.Insert(k);
        }
        public bool Update(Khachhang k)
        {
            return db.Update(k);
        }
    }
}