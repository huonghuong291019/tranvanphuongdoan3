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
    public class loaiController : Controller
    {
        loaiBus db = new loaiBus();
        public ActionResult danhsachsanpham(string maloai, string tenloai, string tenSPTim, int? page = 1)
        {
            ViewBag.tenloai = tenloai;
            ViewBag.maloai = maloai;
            ViewBag.KeyWord = tenSPTim;
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            string xauTim = tenSPTim ?? "";
            //Lưu DL vào session
            List<nhan> l;
            if (Session["SanPham" + maloai] == null)
            {
                //Lấy từ CSDL về
                l = db.LaySanPhamTheoLoai(maloai);//LaySanPhamTheoLoai: phương thức lấy trong Bussiness- DanhsachsanphamBus
                Session["SanPham" + maloai] = l;//Ném Dl vào session
            }
            else
            {
                //Lấy ở trong Session
                l = Session["SanPham" + maloai] as List<nhan>;
            }
            ////bay loi
            //List<SanPhamtrangchu> l = db.LaySanPhamTheoLoai(maloai,gt);
            return View(l.FindAll(m => m.tennhan.ToLower().Contains(xauTim.ToLower())).ToPagedList(pnum, 9));//số bản ghi được lấy là 1
        }
    }
}