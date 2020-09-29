using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.WebApi.Areas.Base;
using SalesTransaction.Application.Service.SalesTransaction;
using SalesTransaction.Application.Model.SalesTransaction;



namespace SalesTransaction.Application.WebApi.SalesTransaction
{
    public class SalesTransactionController : BaseController
    {
        private readonly ISalesTransactionService _salestransactionservice;

        public SalesTransactionController(ISalesTransactionService salestransactionservice)
        {
            _salestransactionservice = salestransactionservice;
        }
        [HttpPost]
        public IActionResult InsertSalesTransaction([FromBody] AddSalesTransaction sales)
        {
            try
            {
                dynamic jsonString = _salestransactionservice.AddSalesTransaction(sales);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
