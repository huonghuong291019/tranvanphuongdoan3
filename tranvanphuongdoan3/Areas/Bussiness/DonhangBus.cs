using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Bussiness
{
    public class DonhangBus
    {
        DonhangModel db = new DonhangModel();
        public List<Donhang> laydonhangdaxacthuc()
        {
            List<Donhang> l = db.Laydonhangdaxacthuc();
            return l;
        }
        public List<Donhang> laydonhangchuaxacthuc()
        {
            List<Donhang> l = db.Laydonhangchuaxacthuc();
            return l;
        }
        public List<Donhang> laydonhangdagiao()
        {
            List<Donhang> l = db.Laydonhangdagiao();
            return l;
        }
        public List<Donhang> xacthucthanhtoan()
        {
            List<Donhang> l = db.xacthucthanhtoan();
            return l;
        }
        public List<Donhang> huy()
        {
            List<Donhang> l = db.huy();
            return l;
        }
        public bool Update(Donhang dh)
        {
            return db.Update(dh);
        }
        public bool Update1(Donhang dh)
        {
            return db.Update1(dh);
        }
        public bool Update2(Donhang dh)
        {
            return db.Update2(dh);
        }
        public int tongdonhangtrongthang()
        {
            return db.tongdonhangtrongthang();
        }
        public int tongdoanhthu()
        {
            return db.tongdoanhthu();
        }
        public int sphienco()
        {
            return db.sphienco();
        }
    }
}