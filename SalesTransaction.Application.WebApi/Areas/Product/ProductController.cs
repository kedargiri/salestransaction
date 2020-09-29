using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.WebApi.Areas.Base;
using SalesTransaction.Application.Service.Product;
using SalesTransaction.Application.Model.Product;

namespace SalesTransaction.Application.WebApi.Areas.Product
{
    public class ProductController : BaseController
    {

        private readonly IProductService _productservice;

        public ProductController(IProductService productService)
        {
            _productservice = productService;
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] MvAddProduct product)
        {
            try
            {
                dynamic jsonString = _productservice.AddProductDetails(product);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public IActionResult UpdateProduct([FromBody] MvUpdateProduct product)
        {
            try
            {
                dynamic jsonString = _productservice.UpdateProductDetails(product);
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet]
        public IActionResult GetAllProductDetails()
        {
            try
            {
                dynamic jsonString = _productservice.GetProductDetails();
                return Ok(jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
