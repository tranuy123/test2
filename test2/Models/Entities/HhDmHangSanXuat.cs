using System;
using System.Collections.Generic;

namespace test2.Models.Entities;

public partial class HhDmHangSanXuat
{
    public long Id { get; set; }

    public string? MaHsx { get; set; }

    public string? TenHsx { get; set; }

    public int? ThongTu { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<HhDmHangHoa> HhDmHangHoas { get; set; } = new List<HhDmHangHoa>();
}
