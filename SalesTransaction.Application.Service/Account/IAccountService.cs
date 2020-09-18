using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.DataAccessLayer;
using SalesTransaction.Application.Model;
using SalesTransaction.Application.Model.Account;

namespace SalesTransaction.Application.Service.Account
{
   public interface IAccountService
    {

        dynamic GetLogin(MvLogin login);

        dynamic GetUserDetail(string Json);


    }
}
