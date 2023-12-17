using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TrangBiSauKhacPhuc
{
    public int IdKhacPhuc { get; set; }

    public int IdTrangBi { get; set; }

    public int IdHienTrang { get; set; }

    public DateTime? NgayKhacPhuc { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public virtual HienTrang IdHienTrangNavigation { get; set; } = null!;

    public virtual TrangBi IdTrangBiNavigation { get; set; } = null!;
}
