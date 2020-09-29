using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.Product;

namespace SalesTransaction.Application.Service.Product
{
    public interface IProductService
    {
        dynamic AddProductDetails(MvAddProduct product);

        dynamic UpdateProductDetails(MvUpdateProduct product);

        dynamic GetProductDetails();


    }
}
