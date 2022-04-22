using System.Collections.Generic;
using PaymentCalculation.DomainModelLayer.Worked;
using PaymentCalculation.Helpers.Domain;

namespace PaymentCalculation.ApplicationLayer.Employee
{
    public class EmployeeService : IEmployeeService
    {
        IDomainService employeeDomainService;

        public EmployeeService(IDomainService employeeDomainService) 
        {            
            this.employeeDomainService = employeeDomainService;
        }

        public List<PaymentDTO> CalculatePayment(List<WorkedTimeDTO> workedTimes)
        {
            List<PaymentDTO> listPaymentDTO = new List<PaymentDTO>();

            foreach (WorkedTimeDTO workedTimeDTO in workedTimes) 
            {
                PaymentDTO paymentDTO = new PaymentDTO();
                paymentDTO.Name = workedTimeDTO.Name;

                PaymentCalculation.DomainModelLayer.Employees.Employee employee = new PaymentCalculation.DomainModelLayer.Employees.Employee();
                List<WorkedTime> listWorkedTime = new List<WorkedTime>();

                employee.Name = workedTimeDTO.Name;

                foreach (WorkedHourDTO workedHourDTO in workedTimeDTO.hours) 
                {
                    WorkedTime workedTime = new WorkedTime();
                    workedTime.Day = workedHourDTO.Day;
                    workedTime.InitialHour = workedHourDTO.InitialHour;
                    workedTime.FinalHour = workedHourDTO.FinalHour;
                    listWorkedTime.Add(workedTime);
                }

                paymentDTO.Value = this.employeeDomainService.CalculatePayment(employee, listWorkedTime).Value;

                listPaymentDTO.Add(paymentDTO);
            }

            return listPaymentDTO;

        }
    }
}
