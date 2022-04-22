using System;

namespace PaymentCalculation.DomainModelLayer.Worked
{
    public class WorkedTime
    {
        public Guid Id { get; set; }
        public string Day { get; set; }
        public int InitialHour { get; set; }
        public int FinalHour { get; set; }
    }
}
