using ErgCentral.Data.Base;
using ErgCentral.Data.Entities;
using ErgCentral.Globals;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgCentral.Data.Command
{
    public class DistanceCommand : BaseCommand<TelemetryContext>, IDistanceCommand
    {
        private readonly TelemetryContext _ctx;

        public DistanceCommand(TelemetryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Result> AddOrUpdateDistance(Distance distance)
        {
            var playerExists = await _ctx.Distance.AsNoTracking().AnyAsync(r => r.ParticipantUserId == distance.ParticipantUserId);
            //save
            if (!playerExists)
            {
                _ctx.Add(distance);
                return await _ctx.SaveChangesAsync() > 0
                    ? Result.Success : Result.Error("Nothing to add");
            }

            return await _ctx.Database.ExecuteSqlRawAsync(
                       $"UPDATE Distance SET MetersCompleted = {distance.MetersCompleted} WHERE ParticipantUserId='{distance.ParticipantUserId}'") > 0
                            ? Result.Success : Result.Error("Distance was not updated");
        }

        public async Task UpdatePosition(IEnumerable<Distance> positions)
        {
            var updateCommand = new List<string>();
            for (var i = 1; i <= positions.Count(); i++)
            {
                updateCommand.Add(
                    $"update {nameof(TelemetryContext.Distance)} SET {nameof(Distance.Position)} = {i} WHERE {nameof(Distance.Id)} = '{positions.ElementAt(i - 1).Id}'");
            }

            var rawSqlString = string.Join(";\n", updateCommand);
            await _ctx.Database.ExecuteSqlRawAsync(rawSqlString);
        }
    }
}