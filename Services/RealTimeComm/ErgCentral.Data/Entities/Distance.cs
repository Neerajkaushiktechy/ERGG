using System;

namespace ErgCentral.Data.Entities
{
    public class Distance
    {
        public long Id { get; set; }

        public string RaceId { get; set; }

        public string ParticipantName { get; set; }

        public Guid ParticipantUserId { get; set; }

        public int MetersCompleted { get; set; }

        public int Position { get; set; }

        public double CurrentSpeed { get; set; }

        public double AverageSpeed { get; set; }

        public int StrokeRatesPerMinute { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }
    }
}