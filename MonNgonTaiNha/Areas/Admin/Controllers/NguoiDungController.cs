using MonNgonTaiNha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonNgonTaiNha.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();

        // GET: Admin/NguoiDung
        public ActionResult DanhSachNguoiDung(int page = 1, string keyWord = null)

        {
            List<NGUOIDUNG> list;
            int limit = 10;
            if (string.IsNullOrEmpty(keyWord))
            {
                list = db.NGUOIDUNGs.ToList();
            }
            else
            {
                list = db.NGUOIDUNGs.Where(u => u.hoTen.Contains(keyWord)
                                            || u.soCMND.Contains(keyWord)
                                            || u.diaChi.Contains(keyWord)
                                            || u.QUYENTRUYCAP.tenQuyen.Contains(keyWord)).ToList();
            }


            int total = list.Count();
            int maxPage = (int)Math.Ceiling(total / (float)limit);
            if (page > maxPage)
                page = maxPage;

            if (page < 1)
                page = 1;

            var selectedList = list.Skip((page - 1) * limit).Take(limit).ToList();

            ViewBag.page = page;

            return View(selectedList);
        }

        public ActionResult ThemNguoiDung()
        {

            return View();
        }
        public ActionResult XoaNguoiDung(int id)
        {
            var model = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachNguoiDung");
        }

        [HttpPost]
        public ActionResult Them(NguoiDungForm form)
        {
            XuLyAnh.XuLyAnh xuLyAnh = new XuLyAnh.XuLyAnh();

            if (ModelState.IsValid)
            {
                NGUOIDUNG nd = new NGUOIDUNG
                {
                    anhDaiDien = xuLyAnh.LuuAnh(form.AnhDaiDien),
                    tenDangNhap = form.TenDangNhap,
                    matKhau = form.MatKhau,
                    hoTen = form.HoTen,
                    diaChi = string.Concat(form.DiaChi, " - ", form.TinhThanh),
                    soCMND = form.SoCMND,
                    ngaySinh = form.NgaySinh,
                    idQuyen = form.Quyen,
                    soXu = 0,
                    soTaiKhoan = form.SoTaiKhoan,
                    idTaiKhoan = form.NganHang
                };

                db.NGUOIDUNGs.Add(nd);
                db.SaveChanges();

            }

            return RedirectToAction("DanhSachNguoiDung");
        }

        public ActionResult SuaNguoiDung(int id)
        {
            var ndModel = db.NGUOIDUNGs.Find(id);

            ViewBag.ndModel = ndModel;

            return View();
        }
    }

    public class NguoiDungForm
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string NhapLaiMatKhau { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string TinhThanh { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCMND { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public int Quyen { get; set; }
        public HttpPostedFileBase AnhDaiDien { get; set; }
        public string SoTaiKhoan { get; set; }
        public int NganHang { get; set; }
    }
}