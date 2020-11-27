using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Models.Entities;
namespace tranvanphuongdoan3.Models.DataAccess
{
    public class nhanModel
    {
        DataContext db = new DataContext();
        DBContext db1 = new DBContext();
        DataTable dt = new DataTable();
        public List<nhan> LaySanPhamTheoLoai(string maloai)
        {
            DataTable dt = db.getData("select *from nhan where( maloai='" + maloai + "')");
            List<nhan> sp = new List<nhan>();
            foreach (DataRow r in dt.Rows)
            {
                nhan p = new nhan();
                p.manhan = Convert.ToString(r[0]);
                p.maloai = Convert.ToString(r[1]);
                p.tennhan = Convert.ToString(r[2]);
                p.mausac = Convert.ToString(r[3]);
                p.chatlieu = Convert.ToString(r[4]);
                p.dongia = int.Parse(Convert.ToString(r[5]));
                p.image = Convert.ToString(r[7]);
                sp.Add(p);
            }
            return sp;
        }
        public nhan LaySanPhamMa(string ma)
        {
            DataTable dt = db.getData("Select * from nhan where manhan='" + ma + "'");
            nhan sp = new nhan();
            if (dt.Rows.Count > 0)
            {
                sp.manhan = Convert.ToString(dt.Rows[0][0]);
                sp.maloai = Convert.ToString(dt.Rows[0][1]);
                sp.tennhan = Convert.ToString(dt.Rows[0][2]);
                sp.mausac = Convert.ToString(dt.Rows[0][3]);
                sp.chatlieu = Convert.ToString(dt.Rows[0][4]);
                sp.dongia = int.Parse(Convert.ToString(dt.Rows[0][5]));
                sp.image = Convert.ToString(dt.Rows[0][7]);
            }
            else sp = null;
            return sp;
        }

        public List<nhan> LaySPham()
        {
            DataTable dt = db.getData("select * from nhan");//lấy tt từ bảng sp
            List<nhan> l = new List<nhan>();
            foreach (DataRow r in dt.Rows)//duyệt qua các đtg dòng của datarow
            {
                nhan sp = new nhan();
                sp.manhan = Convert.ToString(r[0]);
                sp.maloai = Convert.ToString(r[1]);
                sp.tennhan = Convert.ToString(r[2]);
                sp.mausac = Convert.ToString(r[3]);
                sp.chatlieu = Convert.ToString(r[4]);
                sp.dongia = int.Parse(Convert.ToString(r[5]));
                sp.image = Convert.ToString(r[7]);
                l.Add(sp);

            }
            return l;
        }
     
        public List<nhan> LaySPBanChay(int so, string ngaythang)
        {
            DataTable dt = db.StoreReader("LaySPBanChay", so, ngaythang);
            List<nhan> sp = new List<nhan>();
            foreach (DataRow r in dt.Rows)
            {
                nhan p = new nhan();
                p.manhan = Convert.ToString(r[0]);
                p.maloai = Convert.ToString(r[1]);
                p.tennhan = Convert.ToString(r[2]);
                p.mausac = Convert.ToString(r[3]);
                p.chatlieu = Convert.ToString(r[4]);
                p.dongia = int.Parse(Convert.ToString(r[5]));
                p.image = Convert.ToString(r[7]);
                sp.Add(p);
            }
            return sp;
        }
        public bool SuaSLSP(string masp, int sl)
        {
            try
            {
                string st = "Update nhan set soluong = soluong - " + sl + " where manhan = '" + masp + "'";
                return db1.ExcuteNonQuery(st);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}