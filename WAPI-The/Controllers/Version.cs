using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;
using System.Reflection;

namespace WAPI_The.Controllers
{
    [ApiVersion("2.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Version : Controller
    {
        // GET: Version
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public ActionResult Index()
        {

            return Ok( new String($"Api Version: {ApiVersion.Default}"));
        }


    }
}
