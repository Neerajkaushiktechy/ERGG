using AutoMapper;
using ErgCentral.Business.Distance.Dto;

namespace ErgCentral.Business.Distance.MapProfiles
{
    public class PositionDto2Distance : Profile
    {
        public PositionDto2Distance()
        {
            CreateMap<PositionDto, Data.Entities.Distance>();
        }
    }
}