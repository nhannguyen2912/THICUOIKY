using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class BienBanKnkt
{
    public int IdBienBanKnkt { get; set; }

    public DateTime Thoigian { get; set; }

    public int IdCanBo { get; set; }

    public int? IdDonDeNghi { get; set; }

    public virtual ICollection<ChiTietKnkt> ChiTietKnkts { get; set; } = new List<ChiTietKnkt>();

    public virtual DonDeNghi? IdDonDeNghiNavigation { get; set; }
}
