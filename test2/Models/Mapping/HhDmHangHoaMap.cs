namespace test2.Models.Mapping
{
    public class HhDmHangHoaMap
    {
        public long Id { get; set; }

        public string? IddonViTinh { get; set; }

        public string? IdhangSanXuat { get; set; }

        public string MaHangHoa { get; set; } = null!;

        public string TenHangHoa { get; set; } = null!;

        public string? NgaySanXuat { get; set; }

        public string? HanSuDung { get; set; }

        public string? SoLuong { get; set; }

        public bool? Active { get; set; }
    }
}
