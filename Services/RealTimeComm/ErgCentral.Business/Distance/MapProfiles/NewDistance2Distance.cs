using AutoMapper;
using ErgCentral.Business.Distance.Dto;

namespace ErgCentral.Business.Distance.MapProfiles
{
    public class NewDistance2Distance : Profile
    {
        public NewDistance2Distance()
        {
            CreateMap<NewDistance, Data.Entities.Distance>();
        }
    }
}