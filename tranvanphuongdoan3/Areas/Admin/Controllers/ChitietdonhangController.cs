using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
using tranvanphuongdoan3.Areas.Bussiness;

namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class ChitietdonhangController : Controller
    {
        // GET: Admin/Chitietdonhang
        ChitietdonhangBus db = new ChitietdonhangBus();
        public ActionResult chitietdonhang(string madh)
        {
            List<Chitietdonhang> l = db.laydhma(madh);
            ViewBag.madonhang = madh;
            return View(l);
        }
        public ActionResult chitietdonhang1()
        {
            List<Chitietdonhang> l = db.laydh();
            return View(l);
        }
    }
}