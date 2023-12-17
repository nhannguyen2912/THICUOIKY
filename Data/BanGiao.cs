using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class BanGiao
{
    public int IdBanGiao { get; set; }

    public DateTime ThoiGian { get; set; }

    public int IdCanBoGiao { get; set; }

    public int IdCanBoNhan { get; set; }

    public int IdDonVi { get; set; }

    public virtual ICollection<BanGiaoTrangBi> BanGiaoTrangBis { get; set; } = new List<BanGiaoTrangBi>();
}
