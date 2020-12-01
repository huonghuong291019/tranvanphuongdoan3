using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class NhaphangModel
    {
        DBContext db = new DBContext();
        List<nhaphang> lloai = new List<nhaphang>();
        DataTable dt;
        public nhaphang LayLoaiMa(string maloai)
        {
            DataView dv = db.LocDuLieu(dt, "mahoadonnhap='" + maloai + "'");
            nhaphang nh = new nhaphang();
            if (dv.Count >= 1)
            {
                nh.mahoadonnhap = Convert.ToString(dv[0][0]);
                nh.mancc = Convert.ToString(dv[0][1]);
                nh.ngaynhap = Convert.ToDateTime(dv[0][2]);
                nh.thanhtien = Convert.ToInt32(dv[0][3]);
            }
            else
                nh= null;
            return nh;

        }
        public List<nhaphang> layLoai()
        {
            dt = db.FillDataTable("select * from NHAPHANG");
            List<nhaphang> sp = new List<nhaphang>();
            foreach (DataRow r in dt.Rows)
            {
                nhaphang p = new nhaphang();
                p.mahoadonnhap = Convert.ToString(r[0]);
                p.mancc = Convert.ToString(r[1]);
                p.ngaynhap = Convert.ToDateTime(r[2]);
                p.thanhtien = Convert.ToInt32(r[3]);
                sp.Add(p);
            }
            return sp;
        }
        public Boolean XoaLoai(string maloai)
        {

            return db.ExcuteNonQuery("delete NHAPHANG where mahoadonnhap='" + maloai + "'");
        }
        public Boolean Insert(nhaphang l)
        {

            return db.ExcuteNonQuery("insert into NHAPHANG values('" + l.mahoadonnhap + "','" + l.mancc + "','" + l.ngaynhap + "','" + l.thanhtien + "')");
        }
        public Boolean Update(nhaphang l)
        {
            return db.ExcuteNonQuery("update NHAPHANG set thanhtien='" + l.thanhtien + "', ngaynhap= '" + l.ngaynhap + "',mancc='" + l.mancc + "' where mahoadonnhap='" + l.mahoadonnhap + "'");
        }

    }
}