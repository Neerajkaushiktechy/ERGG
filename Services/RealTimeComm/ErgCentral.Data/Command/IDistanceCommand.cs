using ErgCentral.Data.Entities;
using ErgCentral.Globals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErgCentral.Data.Command
{
    public interface IDistanceCommand
    {
        Task<Result> AddOrUpdateDistance(Distance distance);

        Task UpdatePosition(IEnumerable<Distance> positions);
    }
}