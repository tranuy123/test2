using test2.Models.Entities;

namespace test2.Models.FunctionDB
{
    public class Sto_ReadByStrored
    {
        public long Id { get; set; }

        public string SoPhieuNhap { get; set; } = null!;

        public DateTime NgayTao { get; set; }

        public string? GhiChu { get; set; }

        //public virtual ICollection<HhChiTietPhieuNhap> HhChiTietPhieuNhaps { get; set; } = new List<HhChiTietPhieuNhap>();
    }
}
