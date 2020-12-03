using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Models;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;
using tranvanphuongdoan3.Bussiness;
using PagedList;

namespace tranvanphuongdoan3.Controllers
{
    public class nhanController : Controller
    {

        nhanBus db = new nhanBus();
        public JsonResult sanpham()
        {
            List<nhan> lsp = db.LaySPham();
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult index(int? page = 1)
        {
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            List<nhan> lsp = db.LaySPham();
            return View(lsp.ToPagedList(pnum, 8));//ds sp trên view
        }
    
        public ActionResult sanphambanchay(int so, string ngaythang, int? page = 1)
        {
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            nhanModel db = new nhanModel();
            List<nhan> ds = db.LaySPBanChay(so, ngaythang).ToList();
            return PartialView(ds.ToPagedList(pnum, 8));
        }
    }
}