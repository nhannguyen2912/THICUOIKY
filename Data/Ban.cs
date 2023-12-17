using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Ban
{
    public int IdBan { get; set; }

    public string TenBan { get; set; } = null!;

    public int IdPhong { get; set; }

    public virtual ICollection<CanBo> CanBos { get; set; } = new List<CanBo>();

    public virtual ICollection<DonDeNghi> DonDeNghis { get; set; } = new List<DonDeNghi>();

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
