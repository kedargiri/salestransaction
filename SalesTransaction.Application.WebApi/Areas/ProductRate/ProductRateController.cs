using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.WebApi.Areas.Base;
using SalesTransaction.Application.Service.ProductRate;
using SalesTransaction.Application.Model.ProductRate;

namespace SalesTransaction.Application.WebApi.Areas.ProductRate
{
    public class ProductRateController : BaseController
    {
        private readonly IProductRateService _productrateservice;

        public ProductRateController(IProductRateService productRateService)
        {
            _productrateservice = productRateService;
        }
        [HttpPost]
        public IActionResult InsertProductRate([FromBody] MvAddProductRate productRate)
        {
            try
            {
                dynamic jsonString = _productrateservice.AddProductRateDetails(productRate);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public IActionResult UpdateProductRate([FromBody] MvUpdateProductRate productRate)
        {
            try
            {
                dynamic jsonString = _productrateservice.UpdateProductRateDetails(productRate);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public IActionResult GetProductRateDetails()
        {
            try
            {
                dynamic jsonString = _productrateservice.GetProductRateDetails();
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
