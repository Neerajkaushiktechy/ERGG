using System;
using System.Collections.Generic;
using System.Text;

namespace ErgCentral.Domain.Model
{
    public class ParticipantModel
    {
        public ParticipantModel()
        {

        }

        public ParticipantModel(long Id,long ParticipantId,long RaceId,string ParticipantName,string ParticipantEmail,DateTime CreateDate,Int32? CreateBy,Int32? ModifiedBy,DateTime ModifiedDate) {
            this.ParticipantId = ParticipantId;
            this.RaceId = RaceId;
            this.ParticipantName = ParticipantName;
            this.ParticipantEmail = ParticipantEmail;
            this.CreatedDate = CreateDate;
            this.CreatedBy = CreateBy;
            this.ModifiedBy = ModifiedBy;
            this.ModifiedDate = ModifiedDate;
        }
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
