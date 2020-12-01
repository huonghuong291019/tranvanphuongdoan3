using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tranvanphuongdoan3.Areas.Admin.Models.Entities
{
    public class Sanpham
    {
        public string manhan { get; set; }

        public string tennhan { get; set; }

        public string mausac { get; set; }

        public string maloai { get; set; }

        public string chatlieu { get; set; }

        public int dongia { get; set; }

        public int soluong { get; set; }

        public string image { get; set; }
    }
}