using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Models.Entities;

namespace tranvanphuongdoan3.Models.DataAccess
{
    public class loaiModel
    {
        DataContext db = new DataContext();
        public List<loai> getLoai()
        {
            DataTable dt = db.getData("Select * from loainhan");
            List<loai> sp = new List<loai>();
            foreach (DataRow r in dt.Rows)
            {
                loai p = new loai();
                p.maloai = Convert.ToString(r[0]);
                p.tenloai = Convert.ToString(r[1]);
                p.mota = Convert.ToString(r[2]);
                sp.Add(p);
            }
            return sp;
        }
    }
}