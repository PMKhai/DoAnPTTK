//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTV_MVVM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuTra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuTra()
        {
            this.ChiTietTraSaches = new HashSet<ChiTietTraSach>();
        }
    
        public int IDPt { get; set; }
        public int IDPm { get; set; }
        public string UserName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTraSach> ChiTietTraSaches { get; set; }
        public virtual PhieuMuon PhieuMuon { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
