using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using  Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace SalesTransaction.Application.WebApi.Areas.Base
{

    [Produces("application/json")]
    [EnableCors("AllowOrigin"), Route("api/[controller]/[action]/{id?}")]
    public class BaseController : Controller
    {
    }
}
