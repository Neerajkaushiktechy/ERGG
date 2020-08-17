using ErgCentral.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Repository.Interfaces
{
    public interface IParticipantRepository
    {
        List<Participants> GetParticipants();
        Participants GetById(long participantId);
        long CreateParticipant(Participants participant);
        void DeleteParticipant(Participants participant);

    }
}
