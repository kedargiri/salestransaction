using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesTransaction.Application.Model.SalesTransaction
{
    class SalesTransaction
    {
    }

    public class AddSalesTransaction
    {
        public int customerId { get; set; }

        public int productId { get; set; }

        public int productRateId { get; set; }

        public int Quantity { get; set; }

        public decimal rate { get; set; }
    }

    public class UpdateSalesTransaction
    {
        [Required]
        public int SalesTransactionId { get; set; }
        public int customerId { get; set; }

        public int productId { get; set; }

        public int productRateId { get; set; }

        public int Quantity { get; set; }

        public decimal rate { get; set; }
    }
}
