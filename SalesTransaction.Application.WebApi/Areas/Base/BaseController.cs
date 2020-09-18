using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesTransaction.Application.WebApi.Areas.Base
{



    [Produces("application/json")]
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin"), Route("api/[controller]/[action]/{id?}")]
    public abstract class BaseController : Controller
    {
       
    }
}
