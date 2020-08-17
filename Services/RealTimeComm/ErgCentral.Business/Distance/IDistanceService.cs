using ErgCentral.Business.Distance.Dto;
using ErgCentral.Globals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErgCentral.Business.Distance
{
    public interface IDistanceService
    {
        Task<Result> AddOrUpdateDistance(NewDistance newDistance);

        Task<IEnumerable<PositionDto>> BuildUpdatedPositions(string raceId);
    }
}