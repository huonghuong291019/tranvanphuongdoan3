using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
using System.Data;

namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class DonhangModel
    {
        DBContext db = new DBContext();
        List<Donhang> lloai = new List<Donhang>();
        DataTable dt;
        public Donhang LayLoaiMa(string madh)
        {
            DataView dh= db.LocDuLieu(dt, "madonhang='" +madh + "'");
            Donhang nh = new Donhang();
            if (dh.Count >= 1)
            {
                nh.madonhang = Convert.ToString(dh[0][0]);
                nh.ngaytao = Convert.ToDateTime(dh[0][1]);
                nh.thanhtien = Convert.ToInt32(dh[0][2]);
                nh.diachigh = Convert.ToString(dh[0][3]);
                nh.sdtgh = Convert.ToString(dh[0][4]);
                nh.makh= Convert.ToString(dh[0][5]);
                nh.trangthai = Convert.ToInt32(dh[0][6]);

            }
            else
                nh = null;
            return nh;
        }
        public List<Donhang> layLoai()
        {
            dt = db.FillDataTable("select * from donhang");
            List<Donhang> sp = new List<Donhang>();
            foreach (DataRow r in dt.Rows)
            {
                Donhang dh = new Donhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.ngaytao = Convert.ToDateTime(r[1]);
                dh.thanhtien = Convert.ToInt32(r[2]);
                dh.diachigh = Convert.ToString(r[3]);
                dh.sdtgh = Convert.ToString(r[4]);
                dh.makh = Convert.ToString(r[5]);
                dh.trangthai = Convert.ToInt32(r[6]);
                sp.Add(dh);
            }
            return sp;
        }
        public List<Donhang> Laydonhangdaxacthuc()
        {
            DataTable dt = db.StoreReader("Laydonhangdaxacthuc");
            List<Donhang> sp = new List<Donhang>();
            foreach (DataRow r in dt.Rows)
            {
                Donhang dh = new Donhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.ngaytao = Convert.ToDateTime(r[1]);
                dh.thanhtien = Convert.ToInt32(r[2]);
                dh.diachigh = Convert.ToString(r[3]);
                dh.sdtgh = Convert.ToString(r[4]);
                dh.makh = Convert.ToString(r[5]);
                dh.trangthai1 = Convert.ToInt32(r[6]);
                sp.Add(dh);
            }
            return sp;
        }
        public List<Donhang> Laydonhangchuaxacthuc()
        {
            DataTable dt = db.StoreReader("Laydonhangchuaxacthuc");
            List<Donhang> sp = new List<Donhang>();
            foreach (DataRow r in dt.Rows)
            {
                Donhang dh = new Donhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.ngaytao = Convert.ToDateTime(r[1]);
                dh.thanhtien = Convert.ToInt32(r[2]);
                dh.diachigh = Convert.ToString(r[3]);
                dh.sdtgh = Convert.ToString(r[4]);
                dh.makh = Convert.ToString(r[5]);
                dh.trangthai = Convert.ToInt32(r[6]);
                sp.Add(dh);
            }
            return sp;
        }
        public List<Donhang> Laydonhangdagiao()
        {
            DataTable dt = db.StoreReader("Laydonhangdagiao");
            List<Donhang> sp = new List<Donhang>();
            foreach (DataRow r in dt.Rows)
            {
                Donhang dh = new Donhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.ngaytao = Convert.ToDateTime(r[1]);
                dh.thanhtien = Convert.ToInt32(r[2]);
                dh.diachigh = Convert.ToString(r[3]);
                dh.sdtgh = Convert.ToString(r[4]);
                dh.makh = Convert.ToString(r[5]);
                dh.trangthai = Convert.ToInt32(r[6]);
                sp.Add(dh);
            }
            return sp;
        }
        public List<Donhang> xacthucthanhtoan()
        {
            DataTable dt = db.StoreReader("xacthucthanhtoan");
            List<Donhang> sp = new List<Donhang>();
            foreach (DataRow r in dt.Rows)
            {
                Donhang dh = new Donhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.ngaytao = Convert.ToDateTime(r[1]);
                dh.thanhtien = Convert.ToInt32(r[2]);
                dh.diachigh = Convert.ToString(r[3]);
                dh.sdtgh = Convert.ToString(r[4]);
                dh.makh = Convert.ToString(r[5]);
                sp.Add(dh);
            }
            return sp;
        }
        public List<Donhang> huy()
        {
            DataTable dt = db.StoreReader("huy");
            List<Donhang> sp = new List<Donhang>();
            foreach (DataRow r in dt.Rows)
            {
                Donhang dh = new Donhang();
                dh.madonhang = Convert.ToString(r[0]);
                dh.ngaytao = Convert.ToDateTime(r[1]);
                dh.thanhtien = Convert.ToInt32(r[2]);
                dh.diachigh = Convert.ToString(r[3]);
                dh.sdtgh = Convert.ToString(r[4]);
                dh.makh = Convert.ToString(r[5]);
                sp.Add(dh);
            }
            return sp;
        }
        public Boolean Update(Donhang l)
        {
            return db.ExcuteNonQuery("update DONHANG set trangthai='" + l.trangthai + "' where madonhang='" + l.madonhang + "'");
        }
        public Boolean Update1(Donhang l)
        {
            return db.ExcuteNonQuery("update DONHANG set trangthai1='" + l.trangthai1 + "' where madonhang='" + l.madonhang + "'");
        }
        public Boolean Update2(Donhang l)
        {
            return db.ExcuteNonQuery("update DONHANG set trangthai2='" + l.trangthai2 + "' where madonhang='" + l.madonhang + "'");
        }
        public int tongdonhangtrongthang()
        {
            return int.Parse(db.FillDataTable("tongdonhangtrongthang").Rows[0][0].ToString());
        }
        public int tongdoanhthu()
        {
            return int.Parse(db.FillDataTable("tongdoanhthu").Rows[0][0].ToString());
        }
        public int sphienco()
        {
            return int.Parse(db.FillDataTable("sphienco").Rows[0][0].ToString());
        }
    }
}