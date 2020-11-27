using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tranvanphuongdoan3.Models.Entities
{
    public class Donhang
    {
        public string madonhang { get; set; }
        public string ngaytao { get; set; }
        public int thanhtien { get; set; }
        public string diachigh { get; set; }
        public string sdtgh { get; set; }
        public string makh { get; set; }
        public int trangthai { get; set; }
    }
}