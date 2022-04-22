using System;

namespace PaymentCalculation.ConsoleAPP.Models
{
    public class WorkedHourDTO
    {
        public Guid Id { get; set; }
        public string Day { get; set; }
        public int InitialHour { get; set; }
        public int FinalHour { get; set; }
    }
}