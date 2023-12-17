using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class ChiTietKnkt
{
    public int IdBienBanKnkt { get; set; }

    public int IdTrangBi { get; set; }

    public int IdKetQuaKnkt { get; set; }

    public virtual BienBanKnkt IdBienBanKnktNavigation { get; set; } = null!;

    public virtual KetQuaKnkt IdKetQuaKnktNavigation { get; set; } = null!;

    public virtual TrangBi IdTrangBiNavigation { get; set; } = null!;
}
