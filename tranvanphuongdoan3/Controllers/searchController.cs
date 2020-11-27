using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Bussiness;
using PagedList;

namespace tranvanphuongdoan3.Controllers
{
    public class searchController : Controller
    {
        // GET: search
        public ActionResult search(string tenSPTim, int? page = 1)
        {
            loaiBus db = new loaiBus();
            ViewBag.KeyWord = tenSPTim;
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            string xauTim = tenSPTim ?? "";
            //Lưu DL vào session
            List<nhan> l = db.LaySanPhamTK(tenSPTim);
            return View(l.ToPagedList(pnum, 9));//số bản ghi được lấy là 1
        }
    }
}