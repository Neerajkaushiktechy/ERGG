using ErgCentral.Repository.Entity;
using ErgCentral.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgCentral.Repository.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly IBaseRepository<Races> _raceRepository;

        public RaceRepository(IBaseRepository<Races> raceRepository)
        {

            _raceRepository = raceRepository;
        }
        public void CreateRace(Races race)
        {
            _raceRepository.Insert(race);
        }

        public Races GetById(long raceId)
        {
            Races races = _raceRepository.Get().FirstOrDefault(x => x.Id == raceId);
            return races;
        }

        public List<Races> GetRaces()
        {
            List<Races> races = _raceRepository.GetAll().ToList();
            return races;
        }

    }
}
