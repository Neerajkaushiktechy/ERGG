using AutoMapper;
using ErgCentral.Business.Distance.Dto;

namespace ErgCentral.Business.Distance.MapProfiles
{
    public class Distance2PositionDto : Profile
    {
        public Distance2PositionDto()
        {
            CreateMap<Data.Entities.Distance, PositionDto>();
        }
    }
}