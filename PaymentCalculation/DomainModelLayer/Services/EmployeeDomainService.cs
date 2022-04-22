using PaymentCalculation.DomainModelLayer.Employees;
using PaymentCalculation.DomainModelLayer.HourlyCosts;
using PaymentCalculation.DomainModelLayer.Payments;
using PaymentCalculation.DomainModelLayer.Worked;
using PaymentCalculation.Helpers.Domain;
using System.Collections.Generic;

namespace PaymentCalculation.DomainModelLayer.Services
{
    public class EmployeeDomainService : IDomainService
    {
        readonly ICostPerHourRepository costPerHourRepository;

        public EmployeeDomainService(ICostPerHourRepository costPerHourRepository) 
        {
            this.costPerHourRepository = costPerHourRepository;
        }

        public Payment CalculatePayment(Employee employee, List<WorkedTime> listWorkedTime ) {

            Payment payment = new Payment();

            payment.Employee = employee;
            payment.WorkedTimes = listWorkedTime;
            payment.Value = 0;
            float paymentValue = 0;

            foreach (WorkedTime workedTime in listWorkedTime) {

                CostPerHour costPerHour = this.costPerHourRepository.FindOne(new CostPerHourSpec(workedTime.Day, workedTime.InitialHour, workedTime.FinalHour));
                
                if (costPerHour != null) {
                    int hours = workedTime.FinalHour - workedTime.InitialHour;
                    paymentValue += costPerHour.Cost * hours;
                }                
            }

            payment.Value = paymentValue;

            return payment;                             
        }

    }
}
