﻿using System;

namespace ErgCentral.Business.Distance.Dto
{
    public class NewDistance
    {
        public string RaceId { get; set; }

        public Guid ParticipantUserId { get; set; }

        public int MetersCompleted { get; set; }

        public double CurrentSpeed { get; set; }

        public double AverageSpeed { get; set; }

        public int StrokeRatesPerMinute { get; set; }
    }
}