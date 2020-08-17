using AutoMapper;
using ErgCentral.Business.Distance.Dto;
using ErgCentral.Contracts;

namespace ErgCentral.Api.MapProfiles
{
    public class DistanceCoveredRequest2NewDistance : Profile
    {
        public DistanceCoveredRequest2NewDistance()
        {
            CreateMap<DistanceCoveredRequest, NewDistance>();
        }
    }
}