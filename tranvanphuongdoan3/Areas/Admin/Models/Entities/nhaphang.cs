using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tranvanphuongdoan3.Areas.Admin.Models.Entities
{
    public class nhaphang
    {
        public string mahoadonnhap { get; set; }
        public string mancc { get; set; }
        public DateTime ngaynhap { get; set; }
        public float thanhtien { get; set; }
    }
}