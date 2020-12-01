using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;


namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class SanphamModel
    {
        DBContext db = new DBContext();
        List<Sanpham> lloai = new List<Sanpham>();
        DataTable dt;
        public Sanpham LayLoaiMa(string manhan)
        {
            DataView dv = db.LocDuLieu(dt, "manhan='" + manhan + "'");
            Sanpham l = new Sanpham();
            if (dv.Count >= 1)
            {
                l.manhan = Convert.ToString(dv[0][0]);
                l.maloai = Convert.ToString(dv[0][1]);
                l.tennhan = Convert.ToString(dv[0][2]);
                l.mausac = Convert.ToString(dv[0][3]);
                l.chatlieu = Convert.ToString(dv[0][4]);
                l.dongia = Convert.ToInt32(dv[0][5]);
                l.soluong = Convert.ToInt32(dv[0][6]);
            }
            else
                l = null;
            return l;

        }
        public List<Sanpham> layLoai( string maloai)
        {
            dt = db.FillDataTable("select * from nhan where (maloai = '" + maloai + "')");
            List<Sanpham> sp = new List<Sanpham>();
            foreach (DataRow r in dt.Rows)
            {
                Sanpham p = new Sanpham();
                p.manhan = Convert.ToString(r[0]);
                p.maloai = Convert.ToString(r[1]);
                p.tennhan = Convert.ToString(r[2]);
                p.mausac = Convert.ToString(r[3]);
                p.chatlieu = Convert.ToString(r[4]);
                p.dongia = Convert.ToInt32(r[5]);
                p.soluong = Convert.ToInt32(r[6]);
                sp.Add(p);
            }
            return sp;
        }
        public Boolean XoaLoai(string manhan)
        {
            return db.ExcuteNonQuery("delete nhan where manhan='" + manhan + "'");
        }
        public Boolean Insert(Sanpham l)
        {

            return db.ExcuteNonQuery("insert into nhan values ('" + l.manhan + "','" + l.maloai + "','" + l.tennhan + "','" + l.mausac + "','" + l.chatlieu + "','" + l.dongia + "','" + l.soluong + "','" + l.image + "')");
        }
        public Boolean Update(Sanpham l)
        {
            return db.ExcuteNonQuery("update nhan set soluong='"+l.soluong+ "',chatlieu='" + l.chatlieu + "',dongia='" + l.dongia + "',mausac='" + l.mausac + "',tennhan='" + l.tennhan + "' where manhan=N'" + l.manhan + "'");
        }
    }
}