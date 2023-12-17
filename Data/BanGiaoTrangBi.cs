using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class BanGiaoTrangBi
{
    public int IdBanGiao { get; set; }

    public int IdTrangBi { get; set; }

    public string Ghichu { get; set; } = null!;

    public virtual BanGiao IdBanGiaoNavigation { get; set; } = null!;

    public virtual TrangBi IdTrangBiNavigation { get; set; } = null!;
}
