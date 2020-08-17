using ErgCentral.Data.Base;
using ErgCentral.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ErgCentral.Data.Query
{
    public class DistanceQuery : BaseQuery<TelemetryContext>, IDistanceQuery
    {
        public DistanceQuery(TelemetryContext ctx) : base(ctx)
        {
        }

        public IQueryable<Distance> Get(Expression<Func<Distance, bool>> whereExpression)
        {
            return Ctx.Distance.AsNoTracking().Where(whereExpression).OrderByDescending(x => x.MetersCompleted);
        }
    }
}