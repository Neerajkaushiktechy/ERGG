using ErgCentral.Domain.Model;
using ErgCentral.Repository.Entity;
using ErgCentral.Repository.Interfaces;
using ErgCentral.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgCentral.Services.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        public ParticipantService(IParticipantRepository participantRepository) {
            _participantRepository = participantRepository;
        }

        public long CreateParticipant(ParticipantModel participantModel)
        {
            Participants participants = new Participants() {
                Id = participantModel.Id,
                ParticipantName = participantModel.ParticipantName,
                ParticipantEmail = participantModel.ParticipantEmail,
                RaceId = participantModel.RaceId,
                CreatedBy = participantModel.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = participantModel.ModifiedBy,
                ModifiedDate = DateTime.UtcNow              

            };

          return  _participantRepository.CreateParticipant(participants);
        }

        public void DeleteParticipant(ParticipantModel participantModel)
        {
            Participants participants = new Participants()
            {
                ParticipantName = participantModel.ParticipantName,
                ParticipantEmail = participantModel.ParticipantEmail,
                RaceId = participantModel.RaceId,
                CreatedBy = participantModel.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = participantModel.ModifiedBy,
                ModifiedDate = DateTime.UtcNow,
                ParticipantId = participantModel.ParticipantId
            };
            _participantRepository.DeleteParticipant(participants);
        }

        public ParticipantModel GetById(long participantId)
        {
            Participants participants = _participantRepository.GetById(participantId);
            return new ParticipantModel(participants.Id,participants.ParticipantId, participants.RaceId, participants.ParticipantName, participants.ParticipantEmail, participants.CreatedDate, participants.CreatedBy, participants.ModifiedBy, participants.ModifiedDate);
        }

        public List<ParticipantModel> GetParticipants()
        {
            List<ParticipantModel> participantModels = new List<ParticipantModel>();
            List<Participants> participantsList = _participantRepository.GetParticipants();
            foreach (var participant in participantsList) {
                participantModels.Add(new ParticipantModel(participant.Id,participant.ParticipantId, participant.RaceId, participant.ParticipantName, participant.ParticipantEmail, participant.CreatedDate, participant.CreatedBy, participant.ModifiedBy, participant.ModifiedDate));
            }
            return participantModels.ToList();
        }
    }
}
