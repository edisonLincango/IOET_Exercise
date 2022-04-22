using PaymentCalculation.DomainModelLayer.Worked;
using PaymentCalculation.DomainModelLayer.Employees;
using System;
using System.Collections.Generic;

namespace PaymentCalculation.DomainModelLayer.Payments
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; }    
        public List<WorkedTime> WorkedTimes { get; set; }
        public float Value { get; set; }
    }
}
