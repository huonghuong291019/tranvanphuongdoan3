using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseController
    {
        // GET: Admin/HomeAdmin
        public ActionResult HomeAdmin()
        {
            return View();
        }
        public ActionResult GetAccount()
        {
            LoginAccount se = Session["User_Session"] as LoginAccount;
            return Json(new { account = se, success = true }, JsonRequestBehavior.AllowGet);

        }
    }
}