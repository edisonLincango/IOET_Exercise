using PaymentCalculation.DomainModelLayer.Employees;
using PaymentCalculation.DomainModelLayer.Payments;
using PaymentCalculation.DomainModelLayer.Worked;
using System.Collections.Generic;

namespace PaymentCalculation.Helpers.Domain
{
    public interface IDomainService
    {
        Payment CalculatePayment(Employee employee, List<WorkedTime> listWorkedTime);
    }
}
