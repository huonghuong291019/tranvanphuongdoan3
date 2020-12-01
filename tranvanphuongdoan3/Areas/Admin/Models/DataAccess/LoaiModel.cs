using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class LoaiModel
    {
        DBContext db = new DBContext();
        List<Loai> lloai = new List<Loai>();
        DataTable dt;
        public Loai LayLoaiMa(string maloai)
        {
            DataView dv = db.LocDuLieu(dt, "maloai='" + maloai + "'");
            Loai l = new Loai();
            if (dv.Count >= 1)
            {
                l.maloai = Convert.ToString(dv[0][0]);
                l.tenloai = Convert.ToString(dv[0][1]);
                l.mota = Convert.ToString(dv[0][2]);
            }
            else
                l = null;
            return l;

        }

        public List<Loai> layLoai()
        {
            dt = db.FillDataTable("select * from loainhan");
            List<Loai> sp = new List<Loai>();
            foreach (DataRow r in dt.Rows)
            {
                Loai p = new Loai();
                p.maloai = Convert.ToString(r[0]);
                p.tenloai = Convert.ToString(r[1]);
                p.mota = Convert.ToString(r[2]);
                sp.Add(p);
            }
            return sp;
        }
        public Boolean XoaLoai(string maloai)
        {

            return db.ExcuteNonQuery("delete loainhan where maloai='" + maloai + "'");
        }
        public Boolean Insert(Loai l)
        {

            return db.ExcuteNonQuery("insert into loainhan values(N'" + l.maloai + "',N'" + l.tenloai + "',N'" + l.mota+ "')");
        }
        public Boolean Update(Loai l)
        {
            return db.ExcuteNonQuery("update loainhan set mota=N'" + l.mota + "', tenloai= N'" + l.tenloai + "' where maloai=N'" + l.maloai + "'");
        }

    }
}