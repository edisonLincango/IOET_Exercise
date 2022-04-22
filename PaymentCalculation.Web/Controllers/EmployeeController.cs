using Microsoft.AspNetCore.Mvc;
using PaymentCalculation.ApplicationLayer.Employee;
using PaymentCalculation.Web.Models;
using System;
using System.Collections.Generic;


namespace PaymentCalculation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public Response<List<PaymentDTO>> Post(List<WorkedTimeDTO> workedTimes) {

            Response<List<PaymentDTO>> response = new Response<List<PaymentDTO>>();
            try
            {
                response.Object = this.employeeService.CalculatePayment(workedTimes);                
            }
            catch (Exception ex)
            {                
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

    }
    
}