using AutoMapper;
using R1.FrontEnd.WA.Models.Data;


namespace R1.FrontEnd.WA.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<SessionLapTime, SessionLapTime>().ReverseMap();
            
            //CreateMap<ApiUser, UserDto>().ReverseMap();
            //CreateMap<Shareholder, ShareholderDto>().ReverseMap();
        }
    }
}
