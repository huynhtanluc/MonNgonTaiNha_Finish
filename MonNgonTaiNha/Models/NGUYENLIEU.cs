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
    
    public partial class NGUYENLIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUYENLIEU()
        {
            this.CHITIETCONGTHUCs = new HashSet<CHITIETCONGTHUC>();
        }
    
        public int idNguyenLieu { get; set; }
        public string tenNguyenLieu { get; set; }
        public string anhMinhHoa { get; set; }
        public Nullable<double> soLuong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETCONGTHUC> CHITIETCONGTHUCs { get; set; }
    }
}
