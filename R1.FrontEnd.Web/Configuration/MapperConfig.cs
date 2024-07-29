using AutoMapper;
using R1.FrontEnd.Web.Models.Data;


namespace R1.FrontEnd.Web.Configurations
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
