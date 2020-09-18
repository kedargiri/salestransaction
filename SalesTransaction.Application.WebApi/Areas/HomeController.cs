
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesTransaction.Application.WebApi.Areas
{


    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public string get()
        {
            return "hello";
        }
    }
}
