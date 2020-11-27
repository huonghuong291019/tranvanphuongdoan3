using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;

namespace tranvanphuongdoan3.Bussiness
{
    public class loaiBus
    {
        nhanModel db = new nhanModel();
        public List<nhan> LaySanPhamTheoLoai(string maloai)
        {
            List<nhan> sp = db.LaySanPhamTheoLoai(maloai);
            return sp;
        }
        public List<nhan> LaySanPhamTK(string tk)
        {
            return db.LaySPham().Where(x => (x.tennhan.ToLower().Contains(tk.ToLower()))).ToList();
        }
    }
}