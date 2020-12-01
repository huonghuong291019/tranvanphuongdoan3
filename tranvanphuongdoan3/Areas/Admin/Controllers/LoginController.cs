using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;
using tranvanphuongdoan3.Areas.Admin.Models.DataAccess;
using System.Data;
using System.Configuration;
using tranvanphuongdoan3.Areas.Admin.Models;
using tranvanphuongdoan3.Areas.Admin.Common;

namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        AccountModel db = new AccountModel();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        // GET: Administratior/Login
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LoginAccount l)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var lk = db.CheckAcount(l.UserName, Encrypter.MD5Hash(l.PassWord));
        //        var result = Convert.ToInt32(lk[0]);
        //        switch (result)
        //        {
        //            case 0:
        //                ModelState.AddModelError("", "Tài khoản không tồn tại");
        //                break;
        //            case 1:

        //                LoginAccount ac = lk[1] as LoginAccount;
        //                Session.Add("User_Session", ac);
        //                return RedirectToAction("Thongke", "thongke", ac);
        //            case -1:
        //                ModelState.AddModelError("", "Tài khoản đang bị khóa");
        //                break;
        //            case -2:
        //                ModelState.AddModelError("", "Mật khẩu không đúng");
        //                break;
        //            default:
        //                ModelState.AddModelError("", "User name và mật khẩu không đúng");
        //                break;
        //        };
        //    }
        //    else ModelState.AddModelError("", "User name và mật khẩu không đúng");
        //    return View(l);

        //}

    }
}