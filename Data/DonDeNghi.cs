using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class DonDeNghi
{
    public int IdDonDeNghi { get; set; }

    public DateTime ThoiGian { get; set; }

    public int IdDonVi { get; set; }

    public string LyDo { get; set; } = null!;

    public virtual ICollection<BienBanKnkt> BienBanKnkts { get; set; } = new List<BienBanKnkt>();

    public virtual ICollection<DonDeNghiTrangBi> DonDeNghiTrangBis { get; set; } = new List<DonDeNghiTrangBi>();

    public virtual Ban IdDonViNavigation { get; set; } = null!;
}
