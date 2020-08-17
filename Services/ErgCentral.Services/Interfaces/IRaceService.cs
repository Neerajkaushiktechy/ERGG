using ErgCentral.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Services.Interfaces
{
   public interface IRaceService
    {
        List<RaceModel> GetRaces();
        RaceModel GetById(long raceId);
        void CreateRace(RaceModel raceModel);
    }
}
