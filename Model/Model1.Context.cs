﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLTVEntities : DbContext
    {
        public QLTVEntities()
            : base("name=QLTVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietNhapSach> ChiTietNhapSaches { get; set; }
        public virtual DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
        public virtual DbSet<ChiTietTraSach> ChiTietTraSaches { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<NhaPhanPhoi> NhaPhanPhois { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<PhieuTra> PhieuTras { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThamSo> ThamSoes { get; set; }
    }
}
