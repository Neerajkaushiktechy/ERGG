using AutoMapper;
using AutoMapper.QueryableExtensions;
using ErgCentral.Business.Base;
using ErgCentral.Business.Distance.Dto;
using ErgCentral.Data.Command;
using ErgCentral.Data.Query;
using ErgCentral.Globals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErgCentral.Business.Distance
{
    public class DistanceService : BaseService, IDistanceService
    {
        private readonly IDistanceCommand _distanceCommand;
        private readonly IDistanceQuery _distanceQuery;

        public DistanceService(ILogger<DistanceService> logger, IMapper mapper,
            IDistanceCommand distanceCommand, IDistanceQuery distanceQuery) : base(logger, mapper)
        {
            _distanceCommand = distanceCommand;
            _distanceQuery = distanceQuery;
        }

        public Task<Result> AddOrUpdateDistance(NewDistance newDistance)
        {
            return _distanceCommand.AddOrUpdateDistance(Mapper.Map<NewDistance, Data.Entities.Distance>(newDistance));
        }

        public async Task<IEnumerable<PositionDto>> BuildUpdatedPositions(string raceId)
        {
            var positions = await _distanceQuery.Get(r => r.RaceId == raceId)
                .ProjectTo<PositionDto>(Mapper.ConfigurationProvider)
                .ToListAsync();

            await _distanceCommand.UpdatePosition(Mapper.Map<List<PositionDto>, IEnumerable<Data.Entities.Distance>>(positions));

            return positions;
        }
    }
}