using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class ViTri
{
    public int IdVitri { get; set; }

    public string? Vitri1 { get; set; }

    public virtual ICollection<TrangBi> TrangBis { get; set; } = new List<TrangBi>();
}
