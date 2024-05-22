﻿using System;
using System.Collections.Generic;

namespace test2.Models.Entities;

public partial class HhHangHoa
{
    public long Id { get; set; }

    public string MaHangHoa { get; set; } = null!;

    public string TenHangHoa { get; set; } = null!;

    public DateTime? NgaySanXuat { get; set; }

    public DateTime? HanSuDung { get; set; }

    public double? SoLuong { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<HhChiTietPhieuNhap> HhChiTietPhieuNhaps { get; set; } = new List<HhChiTietPhieuNhap>();
}
