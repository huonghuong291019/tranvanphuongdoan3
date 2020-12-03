using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class LoaiNhanController : Controller
    {
        // GET: Admin/Loai
        LoaiBus db = new LoaiBus();
        ChitietdonhangBus db1 = new ChitietdonhangBus();
        [HttpGet]
        public ActionResult loainhan()
        {
            List<Loai> l = db.layLoai();
            return View(l);
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
        public ActionResult ThemLoaiSP(string maloai, string tenloai, string mota)
        {
            Loai l = new Loai();
            l.maloai = maloai;
            l.tenloai = tenloai;
            l.mota = mota;
            if (db.Insert(l))
                return Json(new { success = true, ms = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, ms = "Thêm không thành công" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SuaLoaiSP(string maloai, string tenloai, string mota)
        {
            Loai l = new Loai();
            l.maloai = maloai;
            l.tenloai = tenloai;
            l.mota = mota;
            if (db.Update(l))
                return Json(new { success = true, loai = l, ms = "cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, loai = l, ms = "cập nhật không thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}