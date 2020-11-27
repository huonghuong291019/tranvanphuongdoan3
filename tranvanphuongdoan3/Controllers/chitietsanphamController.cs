using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranvanphuongdoan3.Models.Entities;
using tranvanphuongdoan3.Models.DataAccess;
using tranvanphuongdoan3.Bussiness;

namespace tranvanphuongdoan3.Controllers
{
    public class chitietsanphamController : Controller
    {
        // GET: ChiTietSanPham
        chitietsanphamBus db = new chitietsanphamBus();

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
        //public ActionResult postimg(string masp)
        //{
        //    ImgModel ig = new ImgModel();
        //    List<Img> ds = ig.postimg().Where(x => x.masp == masp).Take(3).ToList();
        //    return PartialView(ds);
        //}
        //public ActionResult sprelative(string maloai)
        //{
        //    SanphamtrangchuModel db = new SanphamtrangchuModel();
        //    List<SanPhamtrangchu> ds = db.LaySPham().Where(x => x.maloai == maloai).Take(3).ToList();
        //    return PartialView(ds);
        //}
        //public ActionResult spother(string masp)
        //{
        //    spotherModel ig = new spotherModel();
        //    List<other> ds = ig.spother().Where(x => x.masp == masp).Take(3).ToList();
        //    return PartialView(ds);
        //}
    }
}