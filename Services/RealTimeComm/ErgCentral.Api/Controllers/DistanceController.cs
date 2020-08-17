using AutoMapper;
using ErgCentral.Api.Hubs;
using ErgCentral.Business.Distance;
using ErgCentral.Business.Distance.Dto;
using ErgCentral.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ErgCentral.Api.Controllers
{
    [Route("api/[controller]")]
    public class DistanceController : BaseController
    {
        private readonly IDistanceService _distanceService;
        private readonly IHubContext<ChatHub> _hub;

        public DistanceController(ILogger<DistanceController> logger, IMapper mapper, IDistanceService distanceService,
            IHubContext<ChatHub> hub) : base(logger, mapper)
        {
            _distanceService = distanceService;
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDistanceCovered([FromBody] DistanceCoveredRequest distanceCoveredRequest)
        {
            await _distanceService.AddOrUpdateDistance(Mapper.Map<DistanceCoveredRequest, NewDistance>(distanceCoveredRequest));

            var positions = await _distanceService.BuildUpdatedPositions(distanceCoveredRequest.RaceId);

            await _hub.Clients.All.SendAsync("messageReceived", JsonConvert.SerializeObject(positions, Formatting.Indented));

            return Ok();
        }
    }
}