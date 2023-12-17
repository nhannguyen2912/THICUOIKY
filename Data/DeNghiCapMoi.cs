using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class DeNghiCapMoi
{
    public int IdDeNghiCapMoi { get; set; }

    public int IdDonVi { get; set; }

    public string Lydo { get; set; } = null!;

    public virtual ICollection<ChiTietDeNghiCapMoi> ChiTietDeNghiCapMois { get; set; } = new List<ChiTietDeNghiCapMoi>();
}
