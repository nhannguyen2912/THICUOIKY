using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class ChucVu
{
    public int IdChucVu { get; set; }

    public string Chucvu1 { get; set; } = null!;

    public virtual ICollection<CanBo> CanBos { get; set; } = new List<CanBo>();
}
