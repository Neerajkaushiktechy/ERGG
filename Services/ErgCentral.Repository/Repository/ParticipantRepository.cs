using ErgCentral.Repository.Entity;
using ErgCentral.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ErgCentral.Repository.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly IBaseRepository<Participants> _participantsRepository;

        public ParticipantRepository(IBaseRepository<Participants> participantsRepository)
        {

            _participantsRepository = participantsRepository;
        }
        public long CreateParticipant(Participants participant)
        {
            _participantsRepository.Insert(participant);
            return participant.ParticipantId;
        }

        public void DeleteParticipant(Participants participant)
        {
            _participantsRepository.Delete(participant);
        }

        public Participants GetById(long participantId)
        {
            return _participantsRepository.Get().FirstOrDefault(x => x.ParticipantId == participantId);
        }

        public List<Participants> GetParticipants()
        {
            return _participantsRepository.GetAll().ToList();
        }

       
    }
}
