using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Phong
{
    public int IdPhong { get; set; }

    public string TenPhong { get; set; } = null!;

    public virtual ICollection<Ban> Bans { get; set; } = new List<Ban>();

    public virtual ICollection<SoThucLuc> SoThucLucs { get; set; } = new List<SoThucLuc>();
}
