using test2.Models.Entities;

namespace test2.Models.Mapping
{
    public class HhChiTietPhieuNhapMap
    {
        public long Id { get; set; }

        public string? IdhangHoa { get; set; }

        public string? IdphieuNhap { get; set; }

        public string? SoLuong { get; set; }

        public string? DonGia { get; set; }

        public virtual HhDmHangHoa? IdhangHoaNavigation { get; set; }

        public virtual HhPhieuNhap IdphieuNhapNavigation { get; set; } = null!;
    }
}
