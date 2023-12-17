using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class HienTrang
{
    public int IdHienTrang { get; set; }

    public string HienTrang1 { get; set; } = null!;

    public virtual ICollection<TrangBiSauKhacPhuc> TrangBiSauKhacPhucs { get; set; } = new List<TrangBiSauKhacPhuc>();
}
