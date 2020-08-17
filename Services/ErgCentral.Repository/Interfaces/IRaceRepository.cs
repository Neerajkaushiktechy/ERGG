using ErgCentral.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Repository.Interfaces
{
    public interface IRaceRepository
    {
        List<Races> GetRaces();
        Races GetById(long raceId);
        void CreateRace(Races races);
    }
}
