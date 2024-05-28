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
            CreateMap<HhPhieuNhapMap, HhPhieuNhap>()
                .ForMember(dest => dest.NgayTao, otp => otp.MapFrom(src => src.NgayTao != "" ? DateTime.ParseExact(src.NgayTao, "dd-MM-yyyy", CultureInfo.InvariantCulture) : (DateTime?)null ));
          
        }
    }
}
