using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class KhachhangModel
    {
        DBContext db = new DBContext();
        List<Khachhang> lloai = new List<Khachhang>();
        DataTable dt;
        public Khachhang LayLoaiMa(string makh)
        {
            DataView dv = db.LocDuLieu(dt, "makh='" + makh + "'");
            Khachhang l = new Khachhang();
            if (dv.Count >= 1)
            {
                l.sdt = Convert.ToString(dv[0][4]);
                l.tenkh = Convert.ToString(dv[0][1]);
                l.email = Convert.ToString(dv[0][2]);
                l.diachi = Convert.ToString(dv[0][3]);
            }
            else
                l = null;
            return l;

        }
        public List<Khachhang> layLoai()
        {
            dt = db.FillDataTable("select * from khachhang");
            List<Khachhang> sp = new List<Khachhang>();
            foreach (DataRow r in dt.Rows)
            {
                Khachhang p = new Khachhang();
                p.sdt = Convert.ToString(r[4]);
                p.tenkh = Convert.ToString(r[1]);
                p.email = Convert.ToString(r[2]);
                p.diachi = Convert.ToString(r[3]);
                sp.Add(p);
            }
            return sp;
        }
        public Boolean XoaLoai(string makh)
        {

            return db.ExcuteNonQuery("delete khachhang where makh='" + makh + "'");
        }
        public Boolean Insert(Khachhang l)
        {

            return db.ExcuteNonQuery("insert into khachhang values('" + l.sdt + "','" + l.tenkh + "','" + l.email + "','" + l.diachi + "','" + l.sdt + "')");
        }
        public Boolean Update(Khachhang l)
        {
            return db.ExcuteNonQuery("update khachhang set diachi='" + l.diachi + "',email='" + l.email + "', tenkh= '" + l.tenkh + "' where makh='" + l.makh + "'");
        }
    }
}