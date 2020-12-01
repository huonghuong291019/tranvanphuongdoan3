using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;


namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class SanphamAdminController : Controller
    {
        // GET: Admin/SanphamAdmin
        SanphamAdminBus db = new SanphamAdminBus();
        ChitietdonhangBus db1 = new ChitietdonhangBus();
        [HttpGet]
        public ActionResult sanphamadmin(string maloai,string tenloai)
        {
            ViewBag.tenloai = tenloai;
            ViewBag.maloai = maloai;
            List<Sanpham> l = db.layLoai(maloai);
            return View(l);
        }
        [HttpPost]
        public ActionResult ThemSP(string manhan, string maloai, string tennhan, string mausac, string chatlieu,int dongia,int soluong, string image)
        {
            Sanpham l = new Sanpham();
            l.manhan = manhan;
            l.maloai = maloai;
            l.tennhan = tennhan;
            l.mausac = mausac;
            l.chatlieu = chatlieu;
            l.dongia = dongia;
            l.soluong = soluong;
            string[] tmp = image.Split('\\');
            l.image = tmp[tmp.Length - 1];
            if (db.Insert(l))
                return Json(new { success = true, ms = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, ms = "Thêm không thành công" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SuaLoaiSP(string manhan, string maloai, string tennhan, string mausac, string chatlieu, int dongia, int soluong, string image)
        {
            Sanpham l = new Sanpham();
            l.manhan = manhan;
            l.maloai = maloai;
            l.tennhan = tennhan;
            l.mausac = mausac;
            l.chatlieu = chatlieu;
            l.dongia = dongia;
            l.soluong = soluong;
            string[] tmp = image.Split('\\');
            l.image = tmp[tmp.Length - 1];
            List<Chitietdonhang> ct = db1.laydh();
            string ms = "Cập nhật thành công";
            var valueFind = ct.FindIndex(x => x.manhan == l.manhan);
            
            if (valueFind<0)
            {
                if (db.Update(l))
                    return Json(new { success = true, loai = l, ms = "cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ms = "Cập nhật không thành công";
            }
            return Json(new { success = false, loai = l, ms =ms }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult XoaLoaiSP(string id)
        {
            string ms = "Xóa thành công";
            List<Chitietdonhang> ct = db1.laydh();
            var valueFind = ct.FindIndex(x => x.manhan == id);
            if (valueFind < 0)
            {
                if (db.XoaLoai(id))
                    return Json(new { success = true, ms = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ms = "Xóa không thành công";
            }
            return Json(new { success = false, ms = ms }, JsonRequestBehavior.AllowGet);
        }
    }
}