using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class DeNghi
{
    public int IdDeNghi { get; set; }

    public string DeNghi1 { get; set; } = null!;

    public virtual ICollection<DonDeNghiTrangBi> DonDeNghiTrangBis { get; set; } = new List<DonDeNghiTrangBi>();
}
