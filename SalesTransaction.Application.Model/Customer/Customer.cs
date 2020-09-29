using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesTransaction.Application.Model.Customer
{
    class Customer
    {
    }

    public class MvAddCustomer
    {
        //public int CustomerId { get; set; }

        public string firstName { get; set; }

        public string middleName { get; set; }

        public string lastName { get; set; }

        public  string phoneNumber { get; set; }

        public string email { get; set; }

        public int InsertPersonId { get; set; }

        public DateTime InsertDate { get; set; }
    }
    public class MvUpdateCustomer
    {
        [Required]
        public int CustomerId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string middleName { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }
    }
}
