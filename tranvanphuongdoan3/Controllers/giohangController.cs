using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;
namespace tranvanphuongdoan3.Controllers
{
    public class giohangController : Controller
    {
        // GET: giohang
        nhanModel db = new nhanModel();
        public ActionResult giohang()
        {
            List<CTDHang> gh = null;
            int tongtien = 0;
            ViewBag.tongtien = "";
            int count = 0;
            if (Session["giohang"] != null)
            {
                gh = (List<CTDHang>)Session["giohang"];
                foreach (CTDHang a in gh)
                {
                    tongtien += a.SoLuong * a.DonGia;
                }
                count = gh.Count;
            }
            ViewBag.count = count;
            ViewBag.tongtien = tongtien;
            return View(gh);
        }
        public ActionResult loadgiohang()
        {
            List<CTDHang> gh = null;
            if (Session["giohang"] != null)
            {
                gh = (List<CTDHang>)Session["giohang"];
            }
            int tongtien = 0;
            int soluong = 0;
            foreach (CTDHang sp in gh)
            {
                tongtien += sp.SoLuong * sp.DonGia;
            }
            soluong = gh.Count;
            return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddCart(string masp, int dongia, string tensp, string hinhanh)
        {
            if (Session["giohang"] == null)//nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CTDHang>();//Khởi tạo Session["giohang"] là 1 list<CartItem>
            }
            List<CTDHang> giohang = Session["giohang"] as List<CTDHang>;//Gán qua biến giohang
            //Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa
            if (giohang.Find(m => m.MaSP == masp) == null)
            {
                CTDHang d = new CTDHang();
                d.MaSP = masp;
                d.SoLuong = 1;
                d.DonGia = dongia;
                d.strDonGia = string.Format("{0:#,##0}", dongia);
                d.TenSP = tensp;
                d.HinhAnh = hinhanh;
                giohang.Add(d);
            }
            else
                giohang.Find(m => m.MaSP == masp).SoLuong = giohang.Find(m => m.MaSP == masp).SoLuong + 1;
            double tongtien = 0;
            for (int i = 0; i < giohang.Count; i++)
            {
                tongtien += giohang[i].DonGia * giohang[i].SoLuong;
            }
            return Json(new { success = true, ms = "Đã thêm vào giỏ hàng", tong = tongtien, ssp = giohang.Count }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SuaCTDH(string masp, int sl)
        {
            List<CTDHang> l = Session["GioHang"] as List<CTDHang>;
            l.Find(m => m.MaSP == masp).SoLuong = sl;
            double tongtien = 0;
            for (int i = 0; i < l.Count; i++)
            {
                tongtien += l[i].DonGia * l[i].SoLuong;
            }
            return Json(new { success = true, sl = l.Count, tong = tongtien, ms = "Sua sản phẩm thành công" }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult tongtien1()
        {
            List<CTDHang> ds = null;
            int tongtien = 0;
            ViewBag.tongtien = 0;
            if (Session["giohang"] != null)
            {
                ds = (List<CTDHang>)Session["giohang"];
                foreach (CTDHang sp in ds)
                {
                    tongtien += sp.SoLuong * sp.DonGia;
                }
                ViewBag.tongtien = tongtien;
            }
            return Json(new { success = true, tongtien = tongtien }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XoaCTDH(string masp)
        {

            if (Session["giohang"] == null)//nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CTDHang>();//Khởi tạo Session["giohang"] là 1 list<CartItem>
            }
            List<CTDHang> giohang = Session["giohang"] as List<CTDHang>;//Gán qua biến giohang
            double tongtien = 0;
            int sldem = 0;
            try
            {
                giohang.Remove(giohang.Find(m => m.MaSP == masp));
                for (int i = 0; i < giohang.Count; i++)
                {
                    tongtien += giohang[i].DonGia * giohang[i].SoLuong;
                    sldem = giohang.Count;
                }
                return Json(new { success = true, sldem = sldem, tong1 = tongtien, ms = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, ms = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCard()
        {
            double thanhtien = 0;
            int sl = 0;
            List<CTDHang> ds = new List<CTDHang>();
            if (Session["GioHang"] == null)
            {
                Session["GioHang"] = new List<CTDHang>();
                thanhtien = 0;
            }
            else
            {
                ds = Session["GioHang"] as List<CTDHang>;
                thanhtien = Convert.ToDouble(ds.Sum(s => s.DonGia * s.SoLuong));
                sl = ds.Count;
            }
            if (ds.Count > 0)
            {
                return Json(new { LCTDH = ds, Thanhtien = thanhtien, soluong = sl }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}