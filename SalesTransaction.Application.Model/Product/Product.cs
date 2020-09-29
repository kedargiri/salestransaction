using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesTransaction.Application.Model.Product
{
    class Product
    {
    }
    public class MvAddProduct
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductRateId { get; set; }

        public int QuantityStock { get; set; }

      }
    public class MvUpdateProduct
    {
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductRateId { get; set; }

        public int QuantityStock { get; set; }
    }

}
