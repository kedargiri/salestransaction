using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesTransaction.Application.Model.ProductRate
{
    class ProductRate
    {
    }

    public class MvAddProductRate
    {
        public decimal productRate { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

     }

    public class MvUpdateProductRate
    {
        [Required]
        public int productRateId { get; set; }

        public decimal productRate { get; set; }
        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
