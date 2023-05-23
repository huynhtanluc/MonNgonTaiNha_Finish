using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonNgonTaiNha.Models;

namespace MonNgonTaiNha.Areas.Admin.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: Admin/BaiViet
        public ActionResult DanhSachBaiViet()
        {
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();

            //Lấy các danh sách sản phẩm

            

            return View();
        }

        public ActionResult ThemMoi()
        {
            return View(new BAIVIET());
        }
        [HttpPost]
        public ActionResult ThemMoi(BAIVIET model)
        {
            //Lưu dữ liệu vào db
            if(string.IsNullOrEmpty(model.tieuDe) == true)
            {
                ModelState.AddModelError("", "Tên tiêu đề không được để trống!");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.anhMinhHoa) == true)
            {
                ModelState.AddModelError("", "Ảnh không được để trống!");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.video) == true)
            {
                ModelState.AddModelError("", "Video không được để trống!");
                return View(model);
            }
            if (string.IsNullOrEmpty(model.noiDung) == true)
            {
                ModelState.AddModelError("", "Nội dung không được để trống!");
                return View(model);
            }
            //Lưu
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();
            db.BAIVIETs.Add(model);
            //Lưu bài viết
            db.SaveChanges();
            if(model.idBaiDang > 0)
            {
                return RedirectToAction("DanhSachBaiViet");
            } else
            {
                ModelState.AddModelError("", "Lỗi thêm mới");
                return View(model);
            }
        }

        
        public ActionResult CapNhat(int id)
        {
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();
            var baiViet = db.BAIVIETs.Find(id);
            return View(baiViet);
        }
        [HttpPost]
        public ActionResult CapNhat(BAIVIET model)
        {
            //Lưu
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();

            //1. Tìm đối tượng cần sửa
            var updateModel = db.BAIVIETs.Find(model.idBaiViet);

            //2. Gắn giá trị mới cho đối tượng
            /*updateModel.tieuDe = model.tieuDe;
            updateModel.anhMinhHoa = model.anhMinhHoa;
            updateModel.video = model.video;
            updateModel.idBaiDang = model.idBaiDang;
            updateModel.idNguoiDang = model.idNguoiDang;*/
            updateModel.idTinhTrang = model.idTinhTrang;
            updateModel.idNguoiDuyet = model.idNguoiDuyet;
            /*updateModel.noiDung = model.noiDung;*/

            var id = db.SaveChanges();
            if (id > 0)
            {
                return RedirectToAction("DanhSachBaiViet");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi cập nhật");
                return View(model);
            }
        }

        public ActionResult Xoa(int id)
        {
            MonNgonTaiNhaEntities db = new MonNgonTaiNhaEntities();
            var xoa = db.BAIVIETs.Find(id);
            db.BAIVIETs.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("DanhSachBaiViet");
        }
    }
}