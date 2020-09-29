using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.ProductRate;

namespace SalesTransaction.Application.Service.ProductRate
{
  public  interface IProductRateService
    {

        dynamic AddProductRateDetails(MvAddProductRate productRate);

        dynamic UpdateProductRateDetails(MvUpdateProductRate productRate);

        dynamic GetProductRateDetails();

    }
}
