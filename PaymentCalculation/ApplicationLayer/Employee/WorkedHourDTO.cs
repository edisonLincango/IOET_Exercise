using System;

namespace PaymentCalculation.ApplicationLayer.Employee
{
    public class WorkedHourDTO
    {
        public Guid Id { get; set; }
        public string Day { get; set; }
        public int InitialHour { get; set; }
        public int FinalHour { get; set; }
    }
}