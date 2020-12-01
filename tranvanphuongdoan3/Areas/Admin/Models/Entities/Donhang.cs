using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tranvanphuongdoan3.Areas.Admin.Models.Entities
{
    public class Donhang
    {
        public string madonhang { get; set; }
        public DateTime ngaytao { get; set; }
        public int thanhtien { get; set; }
        public string diachigh { get; set; }
        public string sdtgh { get; set; }
        public string makh { get; set; }
        public int trangthai { get; set; }
        public int trangthai1 { get; set; }
        public int trangthai2 { get; set; }
    }
}