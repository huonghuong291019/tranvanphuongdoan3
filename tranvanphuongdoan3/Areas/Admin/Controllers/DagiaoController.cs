using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class DagiaoController : Controller
    {
        // GET: Admin/Dagiao
        DonhangBus db = new DonhangBus();
        public ActionResult dagiao()
        {
            List<Donhang> l = db.laydonhangdagiao();
            return View(l);
        }
        [HttpPost]
        public ActionResult SuaDonHang(string madonhang, DateTime ngaytao, int thanhtien, string diachigh, string sdtgh, int trangthai)
        {
            Donhang l = new Donhang();
            l.madonhang = madonhang;
            l.ngaytao = ngaytao;
            l.thanhtien = thanhtien;
            l.diachigh = diachigh;
            l.sdtgh = sdtgh;
            l.makh = sdtgh;
            l.trangthai = trangthai;
            if (db.Update(l))
                return Json(new { success = true, loai = l, ms = "cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false, loai = l, ms = "cập nhật không thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}