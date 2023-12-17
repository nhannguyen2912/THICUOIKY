using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class SoThucLuc
{
    public int IdSoThucLuc { get; set; }

    public int IdDonvi { get; set; }

    public DateTime Nam { get; set; }

    public virtual Phong IdDonviNavigation { get; set; } = null!;

    public virtual ICollection<SoThucLucTrangBi> SoThucLucTrangBis { get; set; } = new List<SoThucLucTrangBi>();
}
