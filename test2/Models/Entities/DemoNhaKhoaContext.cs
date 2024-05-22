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

    public virtual DbSet<HhHangHoa> HhHangHoas { get; set; }

    public virtual DbSet<HhPhieuNhap> HhPhieuNhaps { get; set; }

    public virtual DbSet<TestView> TestViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HhChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HH_ChiTi__3214EC27C7CFFDFD");

            entity.ToTable("HH_ChiTietPhieuNhap");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdhangHoa).HasColumnName("IDHangHoa");
            entity.Property(e => e.IdphieuNhap).HasColumnName("IDPhieuNhap");

            entity.HasOne(d => d.IdhangHoaNavigation).WithMany(p => p.HhChiTietPhieuNhaps)
                .HasForeignKey(d => d.IdhangHoa)
                .HasConstraintName("FK__HH_ChiTie__IDHan__5AB9788F");

            entity.HasOne(d => d.IdphieuNhapNavigation).WithMany(p => p.HhChiTietPhieuNhaps)
                .HasForeignKey(d => d.IdphieuNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HH_ChiTie__IDPhi__5BAD9CC8");
        });

        modelBuilder.Entity<HhHangHoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HH_HangH__3214EC275CDD9886");

            entity.ToTable("HH_HangHoa");

            entity.HasIndex(e => e.MaHangHoa, "UQ__HH_HangH__9737FBA93233204F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.HanSuDung).HasColumnType("datetime");
            entity.Property(e => e.MaHangHoa).HasMaxLength(50);
            entity.Property(e => e.NgaySanXuat).HasColumnType("datetime");
            entity.Property(e => e.TenHangHoa).HasMaxLength(100);
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

        modelBuilder.Entity<TestView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TestView");

            entity.Property(e => e.HanSuDung).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MaHangHoa).HasMaxLength(50);
            entity.Property(e => e.NgaySanXuat).HasColumnType("datetime");
            entity.Property(e => e.TenHangHoa).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
