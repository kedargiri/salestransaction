using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.WebApi.Areas.Base;
using SalesTransaction.Application.Service.Customer;
using SalesTransaction.Application.Model.Customer;

namespace SalesTransaction.Application.WebApi.Areas.Customer
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerservice;

        public CustomerController(ICustomerService customerService)
        {
            _customerservice = customerService;
        }


        [HttpPost]
        public IActionResult InsertCustomer([FromBody] MvAddCustomer customer)
        {
            try
            {
                dynamic jsonString = _customerservice.AddCustomerDetail(customer);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpPost]
        public IActionResult UpdateCustomer([FromBody] MvUpdateCustomer customer)
        {
            try
            {
                dynamic jsonString = _customerservice.UpdateCustomerDetail(customer);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
