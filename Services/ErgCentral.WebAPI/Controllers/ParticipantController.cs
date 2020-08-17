using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErgCentral.Domain.Model;
using ErgCentral.Services.Interfaces;
using ErgCentral.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErgCentral.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        public ParticipantController (IParticipantService participantService)
        {
            _participantService = participantService;

        }
        [HttpPost]
        [Route("CreateParticipant")]
        public ActionResult CreateParticipant([FromBody]ParticipantModel participantModel)
        {
            try
            {
                return Ok(_participantService.CreateParticipant(participantModel));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ToString());
            }
        }

    }
}