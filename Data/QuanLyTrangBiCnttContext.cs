using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public partial class QuanLyTrangBiCnttContext : DbContext
{
    public QuanLyTrangBiCnttContext()
    {
    }

    public QuanLyTrangBiCnttContext(DbContextOptions<QuanLyTrangBiCnttContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<BanGiao> BanGiaos { get; set; }

    public virtual DbSet<BanGiaoTrangBi> BanGiaoTrangBis { get; set; }

    public virtual DbSet<BienBanKnkt> BienBanKnkts { get; set; }

    public virtual DbSet<CanBo> CanBos { get; set; }

    public virtual DbSet<ChiTietDeNghiCapMoi> ChiTietDeNghiCapMois { get; set; }

    public virtual DbSet<ChiTietKnkt> ChiTietKnkts { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<DeNghi> DeNghis { get; set; }

    public virtual DbSet<DeNghiCapMoi> DeNghiCapMois { get; set; }

    public virtual DbSet<DonDeNghi> DonDeNghis { get; set; }

    public virtual DbSet<DonDeNghiTrangBi> DonDeNghiTrangBis { get; set; }

    public virtual DbSet<HienTrang> HienTrangs { get; set; }

    public virtual DbSet<KetQuaKnkt> KetQuaKnkts { get; set; }

    public virtual DbSet<PhanLoaiTtb> PhanLoaiTtbs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<SoThucLuc> SoThucLucs { get; set; }

    public virtual DbSet<SoThucLucTrangBi> SoThucLucTrangBis { get; set; }

    public virtual DbSet<TrangBi> TrangBis { get; set; }

    public virtual DbSet<TrangBiSauKhacPhuc> TrangBiSauKhacPhucs { get; set; }

    public virtual DbSet<ViTri> ViTris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NGUYENTHIENNHAN;Initial Catalog=QuanLyTrangBiCNTT;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.IdBan).HasName("PK__Ban__3839F264AC74879C");

            entity.ToTable("Ban");

            entity.Property(e => e.IdBan).HasColumnName("idBan");
            entity.Property(e => e.IdPhong).HasColumnName("idPhong");
            entity.Property(e => e.TenBan)
                .HasMaxLength(50)
                .HasColumnName("tenBan");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.Bans)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ban__idPhong__4D94879B");
        });

        modelBuilder.Entity<BanGiao>(entity =>
        {
            entity.HasKey(e => e.IdBanGiao);

            entity.ToTable("BanGiao");

            entity.Property(e => e.IdBanGiao)
                .ValueGeneratedNever()
                .HasColumnName("idBanGiao");
            entity.Property(e => e.IdCanBoGiao).HasColumnName("idCanBoGiao");
            entity.Property(e => e.IdCanBoNhan).HasColumnName("idCanBoNhan");
            entity.Property(e => e.IdDonVi).HasColumnName("idDonVi");
            entity.Property(e => e.ThoiGian).HasColumnType("date");
        });

        modelBuilder.Entity<BanGiaoTrangBi>(entity =>
        {
            entity.HasKey(e => new { e.IdBanGiao, e.IdTrangBi });

            entity.ToTable("BanGiao_TrangBi");

            entity.Property(e => e.IdBanGiao).HasColumnName("idBanGiao");
            entity.Property(e => e.IdTrangBi).HasColumnName("idTrangBi");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ghichu");

            entity.HasOne(d => d.IdBanGiaoNavigation).WithMany(p => p.BanGiaoTrangBis)
                .HasForeignKey(d => d.IdBanGiao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanGiao_TrangBi_BanGiao");

            entity.HasOne(d => d.IdTrangBiNavigation).WithMany(p => p.BanGiaoTrangBis)
                .HasForeignKey(d => d.IdTrangBi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanGiao_TrangBi_TrangBi");
        });

        modelBuilder.Entity<BienBanKnkt>(entity =>
        {
            entity.HasKey(e => e.IdBienBanKnkt);

            entity.ToTable("BienBanKNKT");

            entity.Property(e => e.IdBienBanKnkt)
                .ValueGeneratedNever()
                .HasColumnName("IdBienBanKNKT");
            entity.Property(e => e.Thoigian).HasColumnType("date");

            entity.HasOne(d => d.IdDonDeNghiNavigation).WithMany(p => p.BienBanKnkts)
                .HasForeignKey(d => d.IdDonDeNghi)
                .HasConstraintName("FK_BienBanKNKT_DonDeNghi");
        });

        modelBuilder.Entity<CanBo>(entity =>
        {
            entity.HasKey(e => e.IdCanBo).HasName("PK__CanBo__52046A6C39C9E007");

            entity.ToTable("CanBo");

            entity.Property(e => e.IdCanBo).HasColumnName("idCanBo");
            entity.Property(e => e.Chucvu).HasColumnName("chucvu");
            entity.Property(e => e.IdBan).HasColumnName("idBan");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("date")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Ten)
                .HasMaxLength(100)
                .HasColumnName("ten");

            entity.HasOne(d => d.ChucvuNavigation).WithMany(p => p.CanBos)
                .HasForeignKey(d => d.Chucvu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CanBo__chucvu__5165187F");

            entity.HasOne(d => d.IdBanNavigation).WithMany(p => p.CanBos)
                .HasForeignKey(d => d.IdBan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CanBo__idBan__52593CB8");
        });

        modelBuilder.Entity<ChiTietDeNghiCapMoi>(entity =>
        {
            entity.HasKey(e => new { e.IdDeNghiCapMoi, e.IdLoaiTtb });

            entity.ToTable("ChiTietDeNghiCapMoi");

            entity.Property(e => e.IdLoaiTtb).HasColumnName("IdLoaiTTB");

            entity.HasOne(d => d.IdDeNghiCapMoiNavigation).WithMany(p => p.ChiTietDeNghiCapMois)
                .HasForeignKey(d => d.IdDeNghiCapMoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDeNghiCapMoi_DeNghiCapMoi");

            entity.HasOne(d => d.IdLoaiTtbNavigation).WithMany(p => p.ChiTietDeNghiCapMois)
                .HasForeignKey(d => d.IdLoaiTtb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDeNghiCapMoi_PhanLoaiTTB");
        });

        modelBuilder.Entity<ChiTietKnkt>(entity =>
        {
            entity.HasKey(e => new { e.IdBienBanKnkt, e.IdTrangBi });

            entity.ToTable("ChiTietKNKT");

            entity.Property(e => e.IdBienBanKnkt).HasColumnName("IdBienBanKNKT");
            entity.Property(e => e.IdKetQuaKnkt).HasColumnName("IdKetQuaKNKT");

            entity.HasOne(d => d.IdBienBanKnktNavigation).WithMany(p => p.ChiTietKnkts)
                .HasForeignKey(d => d.IdBienBanKnkt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietKNKT_BienBanKNKT");

            entity.HasOne(d => d.IdKetQuaKnktNavigation).WithMany(p => p.ChiTietKnkts)
                .HasForeignKey(d => d.IdKetQuaKnkt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietKNKT_KetQuaKNKT");

            entity.HasOne(d => d.IdTrangBiNavigation).WithMany(p => p.ChiTietKnkts)
                .HasForeignKey(d => d.IdTrangBi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietKNKT_TrangBi");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.IdChucVu).HasName("PK__ChucVu__2765C9B50A0D1380");

            entity.ToTable("ChucVu");

            entity.Property(e => e.IdChucVu).HasColumnName("idChucVu");
            entity.Property(e => e.Chucvu1)
                .HasMaxLength(50)
                .HasColumnName("chucvu");
        });

        modelBuilder.Entity<DeNghi>(entity =>
        {
            entity.HasKey(e => e.IdDeNghi);

            entity.ToTable("DeNghi");

            entity.Property(e => e.IdDeNghi)
                .ValueGeneratedNever()
                .HasColumnName("idDeNghi");
            entity.Property(e => e.DeNghi1)
                .HasMaxLength(50)
                .HasColumnName("DeNghi");
        });

        modelBuilder.Entity<DeNghiCapMoi>(entity =>
        {
            entity.HasKey(e => e.IdDeNghiCapMoi);

            entity.ToTable("DeNghiCapMoi");

            entity.Property(e => e.IdDeNghiCapMoi).ValueGeneratedNever();
            entity.Property(e => e.Lydo).HasMaxLength(50);
        });

        modelBuilder.Entity<DonDeNghi>(entity =>
        {
            entity.HasKey(e => e.IdDonDeNghi);

            entity.ToTable("DonDeNghi");

            entity.Property(e => e.IdDonDeNghi)
                .ValueGeneratedNever()
                .HasColumnName("idDonDeNghi");
            entity.Property(e => e.IdDonVi).HasColumnName("idDonVi");
            entity.Property(e => e.LyDo).HasMaxLength(50);
            entity.Property(e => e.ThoiGian).HasColumnType("date");

            entity.HasOne(d => d.IdDonViNavigation).WithMany(p => p.DonDeNghis)
                .HasForeignKey(d => d.IdDonVi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonDeNghi_Ban");
        });

        modelBuilder.Entity<DonDeNghiTrangBi>(entity =>
        {
            entity.HasKey(e => new { e.IdTrangBi, e.IdDonDeNghi });

            entity.ToTable("DonDeNghi_TrangBi");

            entity.Property(e => e.IdTrangBi).HasColumnName("idTrangBi");
            entity.Property(e => e.IdDonDeNghi).HasColumnName("idDonDeNghi");
            entity.Property(e => e.IdDenghi).HasColumnName("idDenghi");

            entity.HasOne(d => d.IdDenghiNavigation).WithMany(p => p.DonDeNghiTrangBis)
                .HasForeignKey(d => d.IdDenghi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonDeNghi_TrangBi_DeNghi");

            entity.HasOne(d => d.IdDonDeNghiNavigation).WithMany(p => p.DonDeNghiTrangBis)
                .HasForeignKey(d => d.IdDonDeNghi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonDeNghi_TrangBi_DonDeNghi");

            entity.HasOne(d => d.IdTrangBiNavigation).WithMany(p => p.DonDeNghiTrangBis)
                .HasForeignKey(d => d.IdTrangBi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonDeNghi_TrangBi_TrangBi");
        });

        modelBuilder.Entity<HienTrang>(entity =>
        {
            entity.HasKey(e => e.IdHienTrang);

            entity.ToTable("HienTrang");

            entity.Property(e => e.IdHienTrang)
                .ValueGeneratedNever()
                .HasColumnName("idHienTrang");
            entity.Property(e => e.HienTrang1)
                .HasMaxLength(50)
                .HasColumnName("HienTrang");
        });

        modelBuilder.Entity<KetQuaKnkt>(entity =>
        {
            entity.HasKey(e => e.IdKetQuaKnkt);

            entity.ToTable("KetQuaKNKT");

            entity.Property(e => e.IdKetQuaKnkt)
                .ValueGeneratedNever()
                .HasColumnName("IdKetQuaKNKT");
            entity.Property(e => e.KetrQuaKnkt)
                .HasMaxLength(50)
                .HasColumnName("KetrQuaKNKT");
        });

        modelBuilder.Entity<PhanLoaiTtb>(entity =>
        {
            entity.HasKey(e => e.IdLoaiTtb).HasName("PK__PhanLoai__4ADB6E12D0783D44");

            entity.ToTable("PhanLoaiTTB");

            entity.HasIndex(e => e.TenLoaiTtb, "UQ_tenLoaiTTB").IsUnique();

            entity.Property(e => e.IdLoaiTtb).HasColumnName("idLoaiTTB");
            entity.Property(e => e.Donvitinh).HasColumnName("donvitinh");
            entity.Property(e => e.TenLoaiTtb)
                .HasMaxLength(50)
                .HasColumnName("tenLoaiTTB");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.IdPhong).HasName("PK__Phong__E540EED48C6F70D7");

            entity.ToTable("Phong");

            entity.HasIndex(e => e.TenPhong, "UQ_tenPhong").IsUnique();

            entity.Property(e => e.IdPhong).HasColumnName("idPhong");
            entity.Property(e => e.TenPhong)
                .HasMaxLength(50)
                .HasColumnName("tenPhong");
        });

        modelBuilder.Entity<SoThucLuc>(entity =>
        {
            entity.HasKey(e => e.IdSoThucLuc);

            entity.ToTable("SoThucLuc");

            entity.Property(e => e.IdSoThucLuc)
                .ValueGeneratedNever()
                .HasColumnName("idSoThucLuc");
            entity.Property(e => e.IdDonvi).HasColumnName("idDonvi");
            entity.Property(e => e.Nam).HasColumnType("date");

            entity.HasOne(d => d.IdDonviNavigation).WithMany(p => p.SoThucLucs)
                .HasForeignKey(d => d.IdDonvi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoThucLuc_Phong");
        });

        modelBuilder.Entity<SoThucLucTrangBi>(entity =>
        {
            entity.HasKey(e => new { e.IdSoThucLuc, e.IdTrangBi });

            entity.ToTable("SoThucLuc_TrangBi");

            entity.Property(e => e.IdSoThucLuc).HasColumnName("idSoThucLuc");
            entity.Property(e => e.IdTrangBi).HasColumnName("idTrangBi");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ghichu");

            entity.HasOne(d => d.IdSoThucLucNavigation).WithMany(p => p.SoThucLucTrangBis)
                .HasForeignKey(d => d.IdSoThucLuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoThucLuc_TrangBi_SoThucLuc");

            entity.HasOne(d => d.IdTrangBiNavigation).WithMany(p => p.SoThucLucTrangBis)
                .HasForeignKey(d => d.IdTrangBi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoThucLuc_TrangBi_TrangBi");
        });

        modelBuilder.Entity<TrangBi>(entity =>
        {
            entity.HasKey(e => e.IdTrangThietBi).HasName("PK__TrangBi__DD65F7510D1E7154");

            entity.ToTable("TrangBi");

            entity.HasIndex(e => e.Serial, "UQ_serial").IsUnique();

            entity.Property(e => e.IdTrangThietBi).HasColumnName("idTrangThietBi");
            entity.Property(e => e.Chip)
                .HasMaxLength(100)
                .HasColumnName("chip");
            entity.Property(e => e.Hangsanxuat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hangsanxuat");
            entity.Property(e => e.Hdd).HasColumnName("hdd");
            entity.Property(e => e.Hedieuhanh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hedieuhanh");
            entity.Property(e => e.IdLoaiTtb).HasColumnName("idLoaiTTB");
            entity.Property(e => e.IdViTri).HasColumnName("idViTri");
            entity.Property(e => e.Ip)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IP");
            entity.Property(e => e.Mac)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("MAC");
            entity.Property(e => e.Namsanxuat).HasColumnName("namsanxuat");
            entity.Property(e => e.Ngaykichhoat)
                .HasColumnType("date")
                .HasColumnName("ngaykichhoat");
            entity.Property(e => e.Nienhan).HasColumnName("nienhan");
            entity.Property(e => e.Ram).HasColumnName("ram");
            entity.Property(e => e.Serial)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("serial");
            entity.Property(e => e.TenTrangThietBi)
                .HasMaxLength(500)
                .HasColumnName("tenTrangThietBi");
            entity.Property(e => e.Trangthaisd).HasColumnName("trangthaisd");

            entity.HasOne(d => d.IdLoaiTtbNavigation).WithMany(p => p.TrangBis)
                .HasForeignKey(d => d.IdLoaiTtb)
                .HasConstraintName("FK__TrangBi__idLoaiT__4BAC3F29");

            entity.HasOne(d => d.IdViTriNavigation).WithMany(p => p.TrangBis)
                .HasForeignKey(d => d.IdViTri)
                .HasConstraintName("FK_TrangBi_ViTri");
        });

        modelBuilder.Entity<TrangBiSauKhacPhuc>(entity =>
        {
            entity.HasKey(e => e.IdKhacPhuc);

            entity.ToTable("TrangBiSauKhacPhuc");

            entity.Property(e => e.IdKhacPhuc)
                .ValueGeneratedNever()
                .HasColumnName("idKhacPhuc");
            entity.Property(e => e.IdHienTrang).HasColumnName("idHienTrang");
            entity.Property(e => e.IdTrangBi).HasColumnName("idTrangBi");
            entity.Property(e => e.NgayHoanThanh).HasColumnType("date");
            entity.Property(e => e.NgayKhacPhuc).HasColumnType("date");

            entity.HasOne(d => d.IdHienTrangNavigation).WithMany(p => p.TrangBiSauKhacPhucs)
                .HasForeignKey(d => d.IdHienTrang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrangBiSauKhacPhuc_HienTrang");

            entity.HasOne(d => d.IdTrangBiNavigation).WithMany(p => p.TrangBiSauKhacPhucs)
                .HasForeignKey(d => d.IdTrangBi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrangBiSauKhacPhuc_TrangBi");
        });

        modelBuilder.Entity<ViTri>(entity =>
        {
            entity.HasKey(e => e.IdVitri);

            entity.ToTable("ViTri");

            entity.Property(e => e.IdVitri)
                .ValueGeneratedNever()
                .HasColumnName("idVitri");
            entity.Property(e => e.Vitri1)
                .HasMaxLength(50)
                .HasColumnName("Vitri");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
