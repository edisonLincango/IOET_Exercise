﻿using System;

namespace PaymentCalculation.DomainModelLayer.HourlyCosts
{
    public class CostPerHourReadModel
    {
        public Guid Id { get; set; }
        public string Day { get; set; }
        public int InitialHour { get; set; }
        public int FinalHour { get; set; }
        public float Cost { get; set; }
    }
}
