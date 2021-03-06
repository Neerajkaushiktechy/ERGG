﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ErgCentral.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;

        public BaseController(ILogger logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }
    }
}