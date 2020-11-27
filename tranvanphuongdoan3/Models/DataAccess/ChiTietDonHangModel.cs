using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;
using System.Data;

namespace tranvanphuongdoan3.Models.DataAccess
{
    public class ChiTietDonHangModel
    {
        DBContext db = new DBContext();
        public void LuuDanhSachCTDH(List<CTDHang> ds)
        {
            List<nhan> ds1 = new List<nhan>();
            DataTable dt = new DataTable();
            dt.Columns.Add("madonhang");
            dt.Columns.Add("manhan");
            dt.Columns.Add("soluong");
            dt.Columns.Add("dongia");
            foreach (CTDHang item in ds)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.MaDHang;
                dr[1] = item.MaSP;
                dr[2] = item.SoLuong;
                dr[3] = item.DonGia;
                dt.Rows.Add(dr);
            }
            db.UpdateDataBase(dt, "chitietdonhang");
        }
    }
}