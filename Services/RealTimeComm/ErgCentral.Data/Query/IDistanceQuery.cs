using ErgCentral.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ErgCentral.Data.Query
{
    public interface IDistanceQuery
    {
        IQueryable<Distance> Get(Expression<Func<Distance, bool>> whereExpression);
    }
}