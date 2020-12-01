using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Controllers
{
    public class BaseController : Controller 
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filtercontext)//phuong thuc xay ra khi mot action nao do dang thuc hien
        {
            var usec = (LoginAccount)Session["User_Session"];
            if (usec == null)//dtg session chua ton tai
            {
                filtercontext.Result = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                (new { Controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filtercontext);
        }
    }
}