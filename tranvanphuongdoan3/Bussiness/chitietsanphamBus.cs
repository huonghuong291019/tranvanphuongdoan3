using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;
namespace tranvanphuongdoan3.Bussiness
{
    public class chitietsanphamBus
    {
        nhanModel db = new nhanModel();
        public nhan Laysp(string masp)
        {
            nhan sp = db.LaySanPhamMa(masp);
            return sp;
        }
    }
}