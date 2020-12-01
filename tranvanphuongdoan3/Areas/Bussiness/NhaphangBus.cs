using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Bussiness
{
    public class NhaphangBus
    {
        NhaphangModel db = new NhaphangModel();
        public List<nhaphang> layLoai()
        {
            List<nhaphang> l = db.layLoai();
            return l;
        }
        public bool XoaLoai(string id)
        {
         return   db.XoaLoai(id);
        }
        public bool Insert(nhaphang nh)
        {
            return db.Insert(nh);
        }
        public bool Update(nhaphang nh)
        {
            return db.Update(nh);
        }
    }
}