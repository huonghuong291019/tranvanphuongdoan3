using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Bussiness;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class XacthucthanhtoanController : Controller
    {
        // GET: Admin/Xacthucthanhtoan
        DonhangBus db = new DonhangBus();

        public ActionResult xacthucthanhtoan()
        {
            List<Donhang> l = db.xacthucthanhtoan();
            return View(l);
        }
    }
}