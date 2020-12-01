using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class NhacungcapModel
    {
        DBContext db = new DBContext();
        List<Nhacungcap> lloai = new List<Nhacungcap>();
        DataTable dt;
        public Nhacungcap LayLoaiMa(string mancc)
        {
            DataView dv = db.LocDuLieu(dt, "MaNcc='" + mancc + "'");
            Nhacungcap l = new Nhacungcap();
            if (dv.Count >= 1)
            {
                l.mancc = Convert.ToString(dv[0][0]);
                l.tenncc = Convert.ToString(dv[0][1]);
                l.email = Convert.ToString(dv[0][2]);
               l.diachi = Convert.ToString(dv[0][3]);
                l.sdt = Convert.ToString(dv[0][4]);
            }
            else
                l = null;
            return l;

        }
        public List<Nhacungcap> layLoai()
        {
            dt = db.FillDataTable("select * from NHACUNGCAP");
            List<Nhacungcap> sp = new List<Nhacungcap>();
            foreach (DataRow r in dt.Rows)
            {
                Nhacungcap p = new Nhacungcap();
                p.mancc = Convert.ToString(r[0]);
                p.tenncc = Convert.ToString(r[1]);
                p.email = Convert.ToString(r[2]);
               p.diachi = Convert.ToString(r[3]);
                p.sdt = Convert.ToString(r[4]);
                sp.Add(p);
            }
            return sp;
        }
        public Boolean XoaLoai(string mancc)
        {

            return db.ExcuteNonQuery("delete NHACUNGCAP where mancc='" + mancc + "'");
        }
        public Boolean Insert(Nhacungcap l)
        {

            return db.ExcuteNonQuery("insert into NHACUNGCAP values('" + l.mancc + "','" + l.tenncc + "','" + l.email + "','" + l.diachi + "','" + l.sdt + "')");
        }
        //public bool InsertList(List<Loai> lst)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("maloai");
        //    dt.Columns.Add("tenloai");
        //    dt.Columns.Add("mota");
        //    foreach (Loai item in lst)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr[0] = item.maloai;
        //        dr[1] = item.tenloai;
        //        dr[2] = item.mota;
        //        dt.Rows.Add(dr);
        //    }
        //    return db.UpdateDataBase(dt, "Select * from LOAINUOCHOA");

        //}
        public Boolean Update(Nhacungcap l)
        {
            return db.ExcuteNonQuery("update NHACUNGCAP set sdt='" + l.sdt + "',diachi='" + l.diachi + "',email='" + l.email + "', tenncc= '" + l.tenncc + "' where mancc='" + l.mancc + "'");
        }
    }
}