using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranvanphuongdoan3.Models.DataAccess;
using tranvanphuongdoan3.Models.Entities;
namespace tranvanphuongdoan3.Bussiness
{
    public class checkoutBus
    {
        public string SinhMa(string MHMax, string ngay)
        {
            int stt = 1;
            if (MHMax != "")
            { stt = Convert.ToInt16(MHMax.Substring(MHMax.Length - 4)) + 1; }
            string ma = stt.ToString();
            while (ma.Length < 4) { ma = "0" + ma; }
            ma = ngay + "." + ma;
            return ma;
        }
        public void MuaHang(Khachhang kh, int thanhtien, List<CTDHang> ds, string diachigh, string sdtgh, int trangthai)
        {
            KhachhangdathangModel kdb = new KhachhangdathangModel();
            kdb.ThemKhach(kh);
            string ngay = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            DonhangModel ddb = new DonhangModel();
            string MHMax = ddb.LayDonHangCungNgay(ngay);
            //xu ly sinh ma hoa don theo quy tac
            string ma = SinhMa(MHMax, ngay);
            //end 
            Donhang dh = new Donhang();
            dh.madonhang = ma;
            dh.makh = sdtgh;
            dh.diachigh = diachigh;
            dh.sdtgh = sdtgh;
            dh.ngaytao = DateTime.Now.ToString();
            dh.thanhtien = thanhtien;
            ddb.ThemDonHang(dh);
            ChiTietDonHangModel cdb = new ChiTietDonHangModel();
            foreach (CTDHang ct in ds)
            {
                ct.MaDHang = ma;
            }
            cdb.LuuDanhSachCTDH(ds);
        }
    }
}