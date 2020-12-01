using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;


namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class NhaphangController : Controller
    {
        // GET: Admin/Nhaphang
        NhaphangBus db = new NhaphangBus();
        [HttpGet]
        public ActionResult nhaphang()
        {

            List<nhaphang> l = db.layLoai();
            return View(l);
        }  
        public ActionResult Index1()
        {
            List<nhaphang> ll = db.layLoai();
            return View(ll);

        }
        public ActionResult XoaLoaiSP1(string id)
        {
            db.XoaLoai(id);
            return View("Index");
        }

        [HttpPost]
        public ActionResult XoaLoaiSP(string id)
        {

            if (db.XoaLoai(id))
            {
                return Json(new { success = true, ms = "xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, ms = "Xóa không thành công" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ThemLoaiSP(string mahoadonnhap, string mancc, DateTime ngaynhap, int thanhtien)
        {
            nhaphang l = new nhaphang();
            l.mahoadonnhap = mahoadonnhap;
            l.mancc = mancc;
            l.ngaynhap = ngaynhap;
            l.thanhtien = thanhtien;
            if (db.Insert(l))
                return Json(new { success = true, ms = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, ms = "Thêm không thành công" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SuaLoaiSP(string mahoadonnhap, string mancc, DateTime ngaynhap, int thanhtien)
        {
            nhaphang l = new nhaphang();
            l.mahoadonnhap = mahoadonnhap;
            l.mancc = mancc;
            l.ngaynhap = ngaynhap;
            l.thanhtien = thanhtien;
            if (db.Update(l))
                return Json(new { success = true, loai = l, ms = "cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, loai = l, ms = "cập nhật không thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}