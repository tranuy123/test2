using System;
using System.Collections.Generic;

namespace test2.Models.Entities;

public partial class HhChiTietPhieuNhap
{
    public long Id { get; set; }

    public long? IdhangHoa { get; set; }

    public long IdphieuNhap { get; set; }

    public double? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public virtual HhDmHangHoa? IdhangHoaNavigation { get; set; }

    public virtual HhPhieuNhap IdphieuNhapNavigation { get; set; } = null!;
}
