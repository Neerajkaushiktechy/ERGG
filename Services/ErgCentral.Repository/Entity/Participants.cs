using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Repository.Entity
{
    public class Participants
    {
        public long Id { get; set; }
        public long ParticipantId { get; set; }
        public long RaceId { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32? CreatedBy { get; set; }
        public Int32? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
