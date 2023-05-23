using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonNgonTaiNha.Models;

namespace MonNgonTaiNha.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        MonNgonTaiNha.Models.MonNgonTaiNhaEntities db = new Models.MonNgonTaiNhaEntities();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {

            if (Session["NguoiDung"] == null)
            {
                return RedirectToAction("DangNhap");

            }
            else
            {
                return View();
            }

        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string tenDangNhap, string password)
        {
            //check DB

            //check code
            NGUOIDUNG nd = db.NGUOIDUNGs.FirstOrDefault(u => u.tenDangNhap == tenDangNhap);
            if (nd != null && nd.matKhau.Equals(password))
            {
                Session["NguoiDung"] = nd;
                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                TempData["error"] = "Tai khoan dang nhap khong dung";
                return View();
            }

        }

        public ActionResult Dangki()
        {
            return View();
        }
    }
}