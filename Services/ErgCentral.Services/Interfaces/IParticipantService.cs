using ErgCentral.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Services.Interfaces
{
   public interface IParticipantService
    {
        List<ParticipantModel> GetParticipants();
        ParticipantModel GetById(long participantId);
        long CreateParticipant(ParticipantModel participantModel);
        void DeleteParticipant(ParticipantModel participantModel);
    }
}
