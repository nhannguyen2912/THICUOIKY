using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class KetQuaKnkt
{
    public int IdKetQuaKnkt { get; set; }

    public string KetrQuaKnkt { get; set; } = null!;

    public virtual ICollection<ChiTietKnkt> ChiTietKnkts { get; set; } = new List<ChiTietKnkt>();
}
