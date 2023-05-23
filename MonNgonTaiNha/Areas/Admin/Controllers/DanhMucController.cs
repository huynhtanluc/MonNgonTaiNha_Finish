using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonNgonTaiNha.Models;
namespace MonNgonTaiNha.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: Admin/DanhMuc
        public ActionResult QuanLyDanhMuc()
        {
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();
            List<DANHMUC> ds = db.DANHMUCs.ToList();
            return View(ds);

        }
        public ActionResult ThemMoi()
        {

            return View(new DANHMUC());
        }
        [HttpPost]
        public ActionResult ThemMoi(DANHMUC danhMuc, HttpPostedFileBase fileAnh)
        {
            if (string.IsNullOrEmpty(danhMuc.tenDanhMuc) == true)
            {
                ModelState.AddModelError("", "Tên sản phẩm không được để trống");
                return View(danhMuc);
            }
            if (string.IsNullOrEmpty(danhMuc.moTa) == true)
            {
                ModelState.AddModelError("", "Mô tả không được để trống");
                return View(danhMuc);
            }
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();
            db.DANHMUCs.Add(danhMuc);
            db.SaveChanges();
            if (fileAnh != null && fileAnh.ContentLength > 0)
            {
                int id = int.Parse(db.DANHMUCs.ToList().Last().idDanhMuc.ToString());

                string _FileName = "";
                int index = fileAnh.FileName.IndexOf('.');
                _FileName = "dm" + id.ToString() + "." + fileAnh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Data/images"), _FileName);
                fileAnh.SaveAs(_path);

                DANHMUC unv = db.DANHMUCs.FirstOrDefault(x => x.idDanhMuc == id);
                unv.anh = _FileName;
                db.SaveChanges();
            }
            if (danhMuc.idDanhMuc > 0)
            {
                return RedirectToAction("QuanLyDanhMuc");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi không lưu vào đc data");
                return View(danhMuc);
            }
        }

        public ActionResult CapNhat(int id)
        {
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();
            var danhMucModel = db.DANHMUCs.Find(id);
            return View(danhMucModel);
        }
        [HttpPost]
        public ActionResult CapNhat(DANHMUC danhMuc)
        {
            if (string.IsNullOrEmpty(danhMuc.tenDanhMuc) == true)
            {
                ModelState.AddModelError("", "Tên sản phẩm không được để trống");
                return View(danhMuc);
            }
            if (string.IsNullOrEmpty(danhMuc.moTa) == true)
            {
                ModelState.AddModelError("", "Mô tả không được để trống");
                return View(danhMuc);
            }
            if (string.IsNullOrEmpty(danhMuc.anh) == true)
            {
                ModelState.AddModelError("", "Ảnh không được để trống");
                return View(danhMuc);
            }
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();

            var updateDanhMuc = db.DANHMUCs.Find(danhMuc.idDanhMuc);
            updateDanhMuc.tenDanhMuc = danhMuc.tenDanhMuc;
            updateDanhMuc.moTa = danhMuc.moTa;
            updateDanhMuc.anh = danhMuc.anh;
            var id = db.SaveChanges();
            if (id > 0)
            {
                return RedirectToAction("QuanLyDanhMuc");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi không lưu vào đc data");
                return View(danhMuc);
            }
        }

        public ActionResult Xoa(int id)
        {
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();
            var danhMucModel = db.DANHMUCs.Find(id);
            db.SaveChanges();
            return RedirectToAction("QuanLyDanhMuc");
        }
    }
}