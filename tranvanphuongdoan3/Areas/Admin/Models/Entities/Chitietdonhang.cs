using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tranvanphuongdoan3.Areas.Admin.Models.Entities
{
    public class Chitietdonhang
    {
        public string madonhang { get; set; }
        public string manhan { get; set; }
        public int soluong { get; set; }
        public int dongia { get; set; }
    }
}