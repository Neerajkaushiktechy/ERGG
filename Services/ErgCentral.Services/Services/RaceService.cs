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
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepository;
        public RaceService(IRaceRepository raceRepository) {
            _raceRepository = raceRepository;
        }
        public void CreateRace(RaceModel raceModel)
        {
            Races races = new Races() {
                Id = raceModel.Id,
                CreatedBy = raceModel.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = raceModel.ModifiedBy,
                ModifiedDate = DateTime.UtcNow
            };
            _raceRepository.CreateRace(races);
        }

        public RaceModel GetById(long raceId)
        {
           Races raceData = _raceRepository.GetById(raceId);
            RaceModel raceModel = new RaceModel(raceData.Id);
            if (raceModel == null)
                return null;
            return raceModel;
        }

        public List<RaceModel> GetRaces()
        {
            IList<Races> raceData = _raceRepository.GetRaces();
            IList<RaceModel> raceModel = new List<RaceModel>();
                foreach (var data in raceData) {
                raceModel.Add(new RaceModel(data.Id));
            }
            return raceModel.ToList();
        }
       
    }
}
