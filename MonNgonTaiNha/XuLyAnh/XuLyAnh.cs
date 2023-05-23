using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MonNgonTaiNha.XuLyAnh
{
    public class XuLyAnh
    {
        public string LuuAnh(HttpPostedFileBase fileAnh)
        {
            if (fileAnh == null)
            {
                return "";
            }
            if (fileAnh.ContentLength == 0)
            {
                return "";
            }

            var urlTuongDoi = "/Data/Images/";
            var urlTuyetDoi = HttpContext.Current.Server.MapPath(urlTuongDoi);
            string fullDuongDan = urlTuyetDoi + fileAnh.FileName;
            int i = 1;
            while (System.IO.File.Exists(fullDuongDan) == true)
            {
                string ten = Path.GetFileNameWithoutExtension(fileAnh.FileName);
                string duoi = Path.GetExtension(fileAnh.FileName);
                fullDuongDan = urlTuyetDoi + ten + "-" + i + duoi;
                i++;
            }
            fileAnh.SaveAs(fullDuongDan);
            return urlTuongDoi + fullDuongDan.Replace(urlTuyetDoi, "");
        }
    }
}