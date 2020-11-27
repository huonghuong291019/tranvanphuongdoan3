using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tranvanphuongdoan3.Models.Entities
{
    public class CTDHang
    {
        public string MaDHang { get; set; }
        public string MaSP { get; set; }

        public string TenSP { get; set; }

        public string HinhAnh { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }
        public string strDonGia { get; set; }
    }
}