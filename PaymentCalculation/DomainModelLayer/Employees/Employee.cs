using PaymentCalculation.DomainModelLayer.Payments;
using PaymentCalculation.DomainModelLayer.Worked;
using System;
using System.Collections.Generic;

namespace PaymentCalculation.DomainModelLayer.Employees
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public List<WorkedTime> WorkedTimes { get; set; }
        public Payment Payment { get; set; }

    }
}
