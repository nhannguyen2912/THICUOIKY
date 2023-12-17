using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class PhanLoaiTtb
{
    public int IdLoaiTtb { get; set; }

    public string TenLoaiTtb { get; set; } = null!;

    public int Donvitinh { get; set; }

    public virtual ICollection<ChiTietDeNghiCapMoi> ChiTietDeNghiCapMois { get; set; } = new List<ChiTietDeNghiCapMoi>();

    public virtual ICollection<TrangBi> TrangBis { get; set; } = new List<TrangBi>();
}
