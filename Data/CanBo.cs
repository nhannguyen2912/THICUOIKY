using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class CanBo
{
    public int IdCanBo { get; set; }

    public string Ten { get; set; } = null!;

    public int Chucvu { get; set; }

    public DateTime Ngaysinh { get; set; }

    public int IdBan { get; set; }

    public virtual ChucVu ChucvuNavigation { get; set; } = null!;

    public virtual Ban IdBanNavigation { get; set; } = null!;
}
