using System.Collections.Generic;

namespace PaymentCalculation.ApplicationLayer.Employee
{
    public interface IEmployeeService
    {
        List<PaymentDTO>  CalculatePayment(List<WorkedTimeDTO> workedTimes); 
    }
}
