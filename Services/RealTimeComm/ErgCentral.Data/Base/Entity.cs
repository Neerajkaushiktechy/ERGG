using System;

namespace ErgCentral.Data.Base
{
    public class Entity : IHasCreatedLastModified
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }
    }
}