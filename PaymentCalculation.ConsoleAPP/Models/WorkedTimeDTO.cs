using System;
using System.Collections.Generic;

namespace PaymentCalculation.ConsoleAPP.Models
{
    public class WorkedTimeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<WorkedHourDTO> hours { get; set; }
    }
}