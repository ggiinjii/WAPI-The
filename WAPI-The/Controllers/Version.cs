using Microsoft.AspNetCore.Mvc;
using System;

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
            return Ok(new String($"Api Version: {ApiVersion.Default}"));
        }


    }
}
