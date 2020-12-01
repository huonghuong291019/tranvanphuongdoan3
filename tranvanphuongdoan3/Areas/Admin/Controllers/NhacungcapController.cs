using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;


namespace DA.Areas.Admin.Controllers
{
    public class NhacungcapController : Controller
    {
        // GET: Admin/Nhacungcap
        NhacungcapBus db = new NhacungcapBus();
       [HttpGet]
        public ActionResult nhacungcap()
        {
            List<Nhacungcap> l = db.layLoai();
            return View(l);
        }
        //public ActionResult Index1()
        //{
        //    List<Nhacungcap> ll = db.layLoai();
        //    return View(ll);

        //}
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
        public ActionResult ThemLoaiSP(string mancc, string tenncc, string email,string diachi,string sdt)
        {
            Nhacungcap l = new Nhacungcap();
            l.mancc = mancc;
            l.tenncc = tenncc;
            l.email = email;
            l.diachi = diachi;
            l.sdt = sdt;
            if (db.Insert(l))
                return Json(new { success = true, ms = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, ms = "Thêm không thành công" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SuaLoaiSP(string mancc, string tenncc, string email,string diachi, string sdt)
        {
            Nhacungcap l = new Nhacungcap();
            l.mancc = mancc;
            l.tenncc = tenncc;
            l.email = email;
            l.diachi = diachi;
            l.sdt = sdt ;
            if (db.Update(l))
                return Json(new { success = true, loai = l, ms = "cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, loai = l, ms = "cập nhật không thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}