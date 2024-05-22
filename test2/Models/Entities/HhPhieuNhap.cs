using System;
using System.Collections.Generic;

namespace test2.Models.Entities;

public partial class HhPhieuNhap
{
    public long Id { get; set; }

    public string SoPhieuNhap { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<HhChiTietPhieuNhap> HhChiTietPhieuNhaps { get; set; } = new List<HhChiTietPhieuNhap>();
}
