using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class ChiTietDeNghiCapMoi
{
    public int IdDeNghiCapMoi { get; set; }

    public int IdLoaiTtb { get; set; }

    public int SoLuong { get; set; }

    public virtual DeNghiCapMoi IdDeNghiCapMoiNavigation { get; set; } = null!;

    public virtual PhanLoaiTtb IdLoaiTtbNavigation { get; set; } = null!;
}
