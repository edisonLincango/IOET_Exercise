using PaymentCalculation.Helpers.Domain;
using System;

namespace PaymentCalculation.DomainModelLayer.HourlyCosts
{
    public class CostPerHour : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Day { get; set; }
        public int InitialHour { get; set; }
        public int FinalHour { get; set; }
        public float Cost { get; set; }
    }
}
