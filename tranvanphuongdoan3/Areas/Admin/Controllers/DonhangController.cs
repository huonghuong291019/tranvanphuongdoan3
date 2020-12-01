using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;


namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class DonhangController : Controller
    {
        DonhangBus db = new DonhangBus();
        [HttpGet]
        public ActionResult donhang()
        {
            //List<Donhang> l = db.layLoai();
            return View();
        }
        //public ActionResult Index1()
        //{
        //    List<nhaphang> ll = db.layLoai();
        //    return View(ll);

        //}
        //public ActionResult XoaLoaiSP1(string id)
        //{
        //    db.XoaLoai(id);
        //    return View("Index");
        //}

        //[HttpPost]
        //public ActionResult XoaLoaiSP(string id)
        //{

        //    if (db.XoaLoai(id))
        //    {
        //        return Json(new { success = true, ms = "xóa thành công" }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //        return Json(new { success = false, ms = "Xóa không thành công" }, JsonRequestBehavior.AllowGet);
        //}
        ////[HttpPost]
        //public ActionResult ThemLoaiSP(string mahoadonnhap, string mancc, DateTime ngaynhap, int thanhtien)
        //{
        //    nhaphang l = new nhaphang();
        //    l.mahoadonnhap = mahoadonnhap;
        //    l.mancc = mancc;
        //    l.ngaynhap = ngaynhap;
        //    l.thanhtien = thanhtien;
        //    if (db.Insert(l))
        //        return Json(new { success = true, ms = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        //    else
        //        return Json(new { success = false, ms = "Thêm không thành công" }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult SuaLoaiSP(string madonhang,DateTime ngaytao, int thanhtien,string diachigh, string sdtgh, string makh, int trangthai)
        //{
        //    Donhang l = new Donhang();
        //    l.madonhang = madonhang;
        //    l.ngaytao = ngaytao;
        //    l.thanhtien = thanhtien;
        //    l.diachigh = diachigh;
        //    l.sdtgh = sdtgh;
        //    l.makh = makh;
        //    l.trangthai = trangthai;
        //    if (db.Update(l))
        //        return Json(new { success = true, loai = l, ms = "cập nhật thành công" }, JsonRequestBehavior.AllowGet);
        //    else
        //        return Json(new { success = false, loai = l, ms = "cập nhật không thành công" }, JsonRequestBehavior.AllowGet);
        //}
    }
}