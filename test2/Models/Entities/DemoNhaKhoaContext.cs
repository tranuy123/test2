using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace test2.Models.Entities;

public partial class DemoNhaKhoaContext : DbContext
{
    public DemoNhaKhoaContext()
    {
    }

    public DemoNhaKhoaContext(DbContextOptions<DemoNhaKhoaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HhChiTietPhieuNhap> HhChiTietPhieuNhaps { get; set; }

    public virtual DbSet<HhDmDonViTinh> HhDmDonViTinhs { get; set; }

    public virtual DbSet<HhDmHangHoa> HhDmHangHoas { get; set; }

    public virtual DbSet<HhDmHangSanXuat> HhDmHangSanXuats { get; set; }

    public virtual DbSet<HhPhieuNhap> HhPhieuNhaps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HhChiTietPhieuNhap>(entity =>
        {
         /sadddddddddddddd///
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdhangHoa).HasColumnName("IDHangHoa");
            entity.Property(e => e.IdphieuNhap).HasColumnName("IDPhieuNhap");
/
            entity.HasOne(d => d.IdphieuNhapNavigation).WithMany(p => p.HhChiTietPhieuNhaps)
                .HasForeignKey(d => d.IdphieuNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HH_ChiTie__IDPhi__5BAD9CC8");
        });

        modelBuilder.Entity<HhDmDonViTinh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DM_DonViTinh");

            entity.ToTable("HH_DM_DonViTinh");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaDvt)
                .HasMaxLength(50)
                .HasColumnName("MaDVT");
            entity.Property(e => e.TenDvt)
                .HasMaxLength(500)
                .HasColumnName("TenDVT");
        });

        modelBuilder.Entity<HhDmHangHoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HH_HangH__3214EC275CDD9886");

            entity.ToTable("HH_DM_HangHoa");

            entity.HasIndex(e => e.MaHangHoa, "UQ__HH_HangH__9737FBA93233204F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.HanSuDung).HasColumnType("datetime");
            entity.Property(e => e.IddonViTinh).HasColumnName("IDDonViTinh");
            entity.Property(e => e.IdhangSanXuat).HasColumnName("IDHangSanXuat");
            entity.Property(e => e.MaHangHoa).HasMaxLength(50);
            entity.Property(e => e.NgaySanXuat).HasColumnType("datetime");
            entity.Property(e => e.TenHangHoa).HasMaxLength(100);

            entity.HasOne(d => d.IddonViTinhNavigation).WithMany(p => p.HhDmHangHoas)
                .HasForeignKey(d => d.IddonViTinh)
                .HasConstraintName("FK_HH_DM_HangHoa_HH_DM_DonViTinh");

            entity.HasOne(d => d.IdhangSanXuatNavigation).WithMany(p => p.HhDmHangHoas)
                .HasForeignKey(d => d.IdhangSanXuat)
                .HasConstraintName("FK_HH_DM_HangHoa_HH_DM_HangSanXuat");
        });

        modelBuilder.Entity<HhDmHangSanXuat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HH_DM_Ha__3214EC27512DFBEF");

            entity.ToTable("HH_DM_HangSanXuat");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaHsx)
                .HasMaxLength(50)
                .HasColumnName("MaHSX");
            entity.Property(e => e.TenHsx)
                .HasMaxLength(500)
                .HasColumnName("TenHSX");
        });

        modelBuilder.Entity<HhPhieuNhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HH_Phieu__3214EC27B3365701");

            entity.ToTable("HH_PhieuNhap");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.SoPhieuNhap).HasMaxLength(50);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
