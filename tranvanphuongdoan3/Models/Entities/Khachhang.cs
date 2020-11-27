using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tranvanphuongdoan3.Models.Entities
{
    public class Khachhang
    {
        public string makh { get; set; }
        public string tenkh { get; set; }
        public string email { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public int trangthai { get; set; }

    }
}