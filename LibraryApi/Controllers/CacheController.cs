using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class CacheController : Controller
    {

        [HttpGet("/time")]
        [ResponseCache(Duration =130, Location =ResponseCacheLocation.Any)] //any is public; client is private; none = no cache
        public ActionResult<string> GetTime()
        {
            return Ok(new { data = $"the time is {DateTime.Now.ToLongTimeString()}" });
        }


    }
}
