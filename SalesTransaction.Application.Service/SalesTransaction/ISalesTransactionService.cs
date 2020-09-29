using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.SalesTransaction;

namespace SalesTransaction.Application.Service.SalesTransaction
{
  public  interface ISalesTransactionService
    {
        dynamic AddSalesTransaction(AddSalesTransaction sales);

        dynamic UpdateSalesTransaction(UpdateSalesTransaction sales);

        dynamic GetAllSalesTransaction();
    }
}
