using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TrangBi
{
    public int IdTrangThietBi { get; set; }

    public string TenTrangThietBi { get; set; } = null!;

    public string Serial { get; set; } = null!;

    public int Trangthaisd { get; set; }

    public int Namsanxuat { get; set; }

    public string Hangsanxuat { get; set; } = null!;

    public DateTime? Ngaykichhoat { get; set; }

    public int Nienhan { get; set; }

    public string Chip { get; set; } = null!;

    public int Hdd { get; set; }

    public int Ram { get; set; }

    public string Hedieuhanh { get; set; } = null!;

    public string? Mac { get; set; }

    public string? Ip { get; set; }

    public int? IdLoaiTtb { get; set; }

    public int? IdViTri { get; set; }

    public virtual ICollection<BanGiaoTrangBi> BanGiaoTrangBis { get; set; } = new List<BanGiaoTrangBi>();

    public virtual ICollection<ChiTietKnkt> ChiTietKnkts { get; set; } = new List<ChiTietKnkt>();

    public virtual ICollection<DonDeNghiTrangBi> DonDeNghiTrangBis { get; set; } = new List<DonDeNghiTrangBi>();

    public virtual PhanLoaiTtb? IdLoaiTtbNavigation { get; set; }

    public virtual ViTri? IdViTriNavigation { get; set; }

    public virtual ICollection<SoThucLucTrangBi> SoThucLucTrangBis { get; set; } = new List<SoThucLucTrangBi>();

    public virtual ICollection<TrangBiSauKhacPhuc> TrangBiSauKhacPhucs { get; set; } = new List<TrangBiSauKhacPhuc>();
}
