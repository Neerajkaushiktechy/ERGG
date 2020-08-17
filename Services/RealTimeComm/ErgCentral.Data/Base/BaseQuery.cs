using Microsoft.EntityFrameworkCore;

namespace ErgCentral.Data.Base
{
    public class BaseQuery<TContext> : IBaseQuery where TContext : DbContext
    {
        protected readonly TContext Ctx;

        public BaseQuery(TContext ctx)
        {
            Ctx = ctx;
        }
    }
}