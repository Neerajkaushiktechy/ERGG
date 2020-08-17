using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ErgCentral.Business.Base
{
    public class BaseService
    {
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;

        public BaseService(ILogger logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }
    }
}