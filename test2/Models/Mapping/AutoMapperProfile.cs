using AutoMapper;
using test2.Models.Entities;
using System.Globalization;

namespace test2.Models.Mapping
{
    public class AutoMapperProfile : Profile
    {
        //chuyển từ IFormFile sang string
        public AutoMapperProfile()
        {
            CreateMap<HhChiTietPhieuNhapMap, HhChiTietPhieuNhap>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id != 0 ? src.Id : (long?)null))
            .ForMember(dest => dest.IdhangHoa, opt => opt.MapFrom(src => src.IdhangHoa != "" ? long.Parse(src.IdhangHoa) : (long?)null))
            .ForMember(dest => dest.IdphieuNhap, opt => opt.MapFrom(src => src.IdphieuNhap != "" ? long.Parse(src.IdphieuNhap) : (long?)null))
            .ForMember(dest => dest.SoLuong, opt => opt.MapFrom(src => src.SoLuong != "" ? double.Parse(src.SoLuong.Replace(",", "")) : (double?)null))
            .ForMember(dest => dest.DonGia, opt => opt.MapFrom(src => src.DonGia != "" ? double.Parse(src.DonGia.Replace(",", "")) : (double?)null));
            CreateMap<HhPhieuNhapMap, HhPhieuNhap>()
                .ForMember(dest => dest.NgayTao, otp => otp.MapFrom(src => src.NgayTao != "" ? DateTime.ParseExact(src.NgayTao, "dd-MM-yyyy", CultureInfo.InvariantCulture) : (DateTime?)null ));
        }
    }
}
