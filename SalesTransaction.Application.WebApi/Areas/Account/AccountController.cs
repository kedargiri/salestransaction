using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.WebApi.Areas.Base;
using SalesTransaction.Application.Service.Account;
using SalesTransaction.Application.Model.Account;


namespace SalesTransaction.Application.WebApi.Areas.Account
{
    public class AccountController : BaseController
        {
        private readonly IAccountService _accountservice;

        public AccountController(IAccountService accountService)
        {
            _accountservice = accountService;
        }

        [HttpPost]

        public IActionResult Login([FromBody] MvLogin login)
        {
            try
            {
                var jsonString = _accountservice.GetLogin(login);
                return (jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public IActionResult UserDetails(string json)
        {
            try
            {
                var jsonString = _accountservice.GetUserDetail(json);
                return (jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        }
    }

