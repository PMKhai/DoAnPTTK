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
    
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.ChiTietNhapSaches = new HashSet<ChiTietNhapSach>();
            this.ChiTietPhieuMuons = new HashSet<ChiTietPhieuMuon>();
            this.ChiTietTraSaches = new HashSet<ChiTietTraSach>();
        }
    
        public int IDSach { get; set; }
        public int IDLoai { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public System.DateTime NamXB { get; set; }
        public string NhaXB { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapSach> ChiTietNhapSaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTraSach> ChiTietTraSaches { get; set; }
        public virtual LoaiSach LoaiSach { get; set; }
        public string TenLoaiSach { get; internal set; }
    }
}
