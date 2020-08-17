using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Domain.Model
{
    public class RaceModel
    {
        public RaceModel(long raceId) {
            Id = raceId;
        }
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32? CreatedBy { get; set; }
        public Int32? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IList<ParticipantModel> ParticipantModels { get; set; }
    }
}
