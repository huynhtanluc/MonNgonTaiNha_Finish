//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonNgonTaiNha.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DANHGIA
    {
        public int idNguoiDanhGia { get; set; }
        public int idCongThuc { get; set; }
        public Nullable<int> soSao { get; set; }
        public Nullable<System.DateTime> ngayDanhGia { get; set; }
    
        public virtual CONGTHUC CONGTHUC { get; set; }
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
