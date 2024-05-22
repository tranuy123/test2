using System;
using System.Collections.Generic;

namespace test2.Models.Entities;

public partial class HhDmDonViTinh
{
    public long Id { get; set; }

    public string? MaDvt { get; set; }

    public string? TenDvt { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<HhDmHangHoa> HhDmHangHoas { get; set; } = new List<HhDmHangHoa>();
}
