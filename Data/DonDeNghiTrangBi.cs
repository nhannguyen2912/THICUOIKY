using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class DonDeNghiTrangBi
{
    public int IdTrangBi { get; set; }

    public int IdDonDeNghi { get; set; }

    public int IdDenghi { get; set; }

    public virtual DeNghi IdDenghiNavigation { get; set; } = null!;

    public virtual DonDeNghi IdDonDeNghiNavigation { get; set; } = null!;

    public virtual TrangBi IdTrangBiNavigation { get; set; } = null!;
}
