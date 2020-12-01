using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
using System.Data;


namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class ChitietdonhangModel
    {
        DBContext db = new DBContext();
        List<Chitietdonhang> lldh = new List<Chitietdonhang>();
        DataTable dt;
        public List<Chitietdonhang> laydhma(string madh)
        {
            dt = db.FillDataTable("select * from chitietdonhang where madonhang='" + madh + "'");
            List<Chitietdonhang> sp = new List<Chitietdonhang>();
            foreach (DataRow r in dt.Rows)
            {
                Chitietdonhang dh = new Chitietdonhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.manhan = Convert.ToString(r[1]);
                dh.soluong = Convert.ToInt32(r[2]);
                dh.dongia = Convert.ToInt32(r[3]);
                sp.Add(dh);
            }
            return sp;
        }
        public List<Chitietdonhang> laydh()
        {
            dt = db.FillDataTable("select * from chitietdonhang");
            List<Chitietdonhang> sp = new List<Chitietdonhang>();
            foreach (DataRow r in dt.Rows)
            {
                Chitietdonhang dh = new Chitietdonhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.manhan = Convert.ToString(r[1]);
                dh.soluong = Convert.ToInt32(r[2]);
                dh.dongia = Convert.ToInt32(r[3]);
                sp.Add(dh);
            }
            return sp;
        }
    }
}