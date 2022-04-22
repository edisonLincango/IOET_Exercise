using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentCalculation.DomainModelLayer.Employees;
using PaymentCalculation.DomainModelLayer.HourlyCosts;
using PaymentCalculation.DomainModelLayer.Payments;
using PaymentCalculation.DomainModelLayer.Services;
using PaymentCalculation.DomainModelLayer.Worked;
using PaymentCalculation.InfrastructureLayer;
using System.Collections.Generic;

namespace PaymentCalculation.Tests
{
    [TestClass]
    public class EmployeeDomainServiceTest
    {
        [TestMethod, TestCategory("Unit")]
        public void CalculatePayment_HoursWorkedReneTotal215_ReturnCorrectPayment()
        {
            float expectedPayment = 215;

            Mock<Employee> employee = new Mock<Employee>() { Name = "RENE"};            
            Mock<List<WorkedTime>> listWorkedTime = new Mock<List<WorkedTime>>();

            listWorkedTime.Object.Add(new WorkedTime() { Day = "MO", InitialHour = 10, FinalHour = 12 });
            listWorkedTime.Object.Add(new WorkedTime() { Day = "TU", InitialHour = 10, FinalHour = 12 });
            listWorkedTime.Object.Add(new WorkedTime() { Day = "TH", InitialHour = 1, FinalHour = 3 });
            listWorkedTime.Object.Add(new WorkedTime() { Day = "SA", InitialHour = 14, FinalHour = 18 });
            listWorkedTime.Object.Add(new WorkedTime() { Day = "SU", InitialHour = 20, FinalHour = 21 });

            MemoryRepository<CostPerHour> memRepository = new MemoryRepository<CostPerHour>();
            ICostPerHourRepository costPerHourRepository = new CostPerHourRepository(memRepository);

            EmployeeDomainService employeeDomainService = new EmployeeDomainService(costPerHourRepository);

            Payment payment = employeeDomainService.CalculatePayment(employee.Object, listWorkedTime.Object);

            Assert.AreEqual(expectedPayment, payment.Value);
        }

        [TestMethod, TestCategory("Unit")]
        public void CalculatePayment_HoursWorkedAstridTotal85_ReturnCorrectPayment()
        {
            float expectedPayment = 85;

            Mock<Employee> employee = new Mock<Employee>() { Name = "RENE" };
            Mock<List<WorkedTime>> listWorkedTime = new Mock<List<WorkedTime>>();

            listWorkedTime.Object.Add(new WorkedTime() { Day = "MO", InitialHour = 10, FinalHour = 12 });
            listWorkedTime.Object.Add(new WorkedTime() { Day = "TU", InitialHour = 12, FinalHour = 14 });
            listWorkedTime.Object.Add(new WorkedTime() { Day = "SU", InitialHour = 20, FinalHour = 21 });

            MemoryRepository<CostPerHour> memRepository = new MemoryRepository<CostPerHour>();
            ICostPerHourRepository costPerHourRepository = new CostPerHourRepository(memRepository);

            EmployeeDomainService employeeDomainService = new EmployeeDomainService(costPerHourRepository);

            Payment payment = employeeDomainService.CalculatePayment(employee.Object, listWorkedTime.Object);

            Assert.AreEqual(expectedPayment, payment.Value);
        }

    }
}
