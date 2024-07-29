using AutoMapper;
using R1.Services.API.Data;
using R1.Services.API.Models.User;
using R1.Services.API.Models.Data;
using R1.Services.API.Models.Dto;

namespace R1.Services.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<SessionLapTime, SessionLapTime>().ReverseMap();
            
            //CreateMap<ApiUser, UserDto>().ReverseMap();
            CreateMap<UserSetting, UserSetting>().ReverseMap();

            CreateMap<Chassis, Chassis>().ReverseMap();
            CreateMap<Driver, Driver>().ReverseMap();
            CreateMap<DriverSetting, DriverSetting>().ReverseMap();
            CreateMap<Engine, Engine>().ReverseMap();
            CreateMap<Gearbox, Gearbox>().ReverseMap();
            CreateMap<Practice, Practice>().ReverseMap();
            CreateMap<PracticeLapTime, PracticeLapTime>().ReverseMap();
            CreateMap<RaceGrid, RaceGrid>().ReverseMap();
            CreateMap<RaceSplit, RaceSplit>().ReverseMap();
            CreateMap<RaceTyre, RaceTyre>().ReverseMap();
            CreateMap<Series, Series>().ReverseMap();
            CreateMap<SeriesPoint, SeriesPoint>().ReverseMap();
            CreateMap<Session, Session>().ReverseMap();
            CreateMap<SessionLapTime, SessionLapTime>().ReverseMap();
            CreateMap<SessionStatus, SessionStatus>().ReverseMap();
            CreateMap<Team, Team>().ReverseMap();
            CreateMap<StaffDto, StaffDto>().ReverseMap();
            CreateMap<TeamDevelopment, TeamDevelopment>().ReverseMap();
            CreateMap<TeamDriver, TeamDriver>().ReverseMap();
            CreateMap<Transaction, Transaction>().ReverseMap();
            CreateMap<World, World>().ReverseMap();
            CreateMap<StatusDto, StatusDto>().ReverseMap();

        }
    }
}
