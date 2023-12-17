using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class SoThucLucTrangBi
{
    public int IdSoThucLuc { get; set; }

    public int IdTrangBi { get; set; }

    public string Ghichu { get; set; } = null!;

    public virtual SoThucLuc IdSoThucLucNavigation { get; set; } = null!;

    public virtual TrangBi IdTrangBiNavigation { get; set; } = null!;
}
