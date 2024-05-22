namespace SixOsDentalSoftware.Models.FunctionDB
{
    public class QL_KeHoachDieuTri_DanhSachBenhNhan
    {
        public long IDBenhNhan { get; set; }
        public long? IDVaoVien { get; set; }
        //public long IDGioiTinh { get; set; }
        public long? IDPhongBuong { get; set; }
        public string MaBenhNhan { get; set; }
        public string TenBenhNhan { get; set; }
        public string? NgaySinh { get; set; }
        public int NamSinh { get; set; }
        public string TenGioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public bool HieuLuc { get; set; }
    }
}
