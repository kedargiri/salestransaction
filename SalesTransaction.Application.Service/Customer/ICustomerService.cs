using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.Customer;

namespace SalesTransaction.Application.Service.Customer
{
  public  interface ICustomerService
    {

        dynamic AddCustomerDetail(MvAddCustomer customer);


        dynamic UpdateCustomerDetail(MvUpdateCustomer customer);

        //dynamic UpdateCustomerDetail(string json);

        //dynamic getCustomerDetail();

    }
}
