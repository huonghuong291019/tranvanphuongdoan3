using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;
using tranvanphuongdoan3.Bussiness;
using PagedList;
namespace tranvanphuongdoan3.Controllers
{
    public class chitietsanphamController : Controller
    {
        // GET: ChiTietSanPham
        chitietsanphamBus db = new chitietsanphamBus();
        public JsonResult detail(string masp)
        {
            nhan sp = db.Laysp(masp);
            return Json(sp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult chitietsanpham(string masp, string maloai)
        {
            try
            {
                nhan sp = db.Laysp(masp);
                return View(sp);
            }
            catch
            {
                return Content("Hihii");
            }
        }
        public ActionResult sprelative(string maloai)
        {
            nhanModel db = new nhanModel();
            List<nhan> ds = db.LaySPham().Where(x => x.maloai == maloai).Take(10).ToList();
            return PartialView(ds);
        }
    }
}