using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class ThongkeController : Controller
    {
        // GET: Admin/Thongke
        DonhangBus db = new DonhangBus();
        public ActionResult thongke()
        {
            ViewBag.tongdonhang = db.tongdonhangtrongthang();
            ViewBag.tongdoanhthu = db.tongdoanhthu();
            ViewBag.sphienco = db.sphienco();
            return View();
        }
    }
}