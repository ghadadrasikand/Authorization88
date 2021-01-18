using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("GetBody")]
        public IActionResult GetBody([FromBody] string name)
        {
            string result = name;
            return Ok(result);
        }

        [HttpGet]
        [Route("GetQuery")]
        public IActionResult GetQuery([FromQuery] string name)
        {
            string result = name;
            return Ok(result);
        }

        [HttpGet]
        [Route("GetRoute/{name}")]
        public IActionResult GetRoute([FromRoute] string name)
        {
            string result = name;
            return Ok(result);
        }


        [HttpGet]
        [Route("GetHeader")]
        public IActionResult GetHeader([FromHeader] string name)
        {
            string result = name;
            return Ok(result);
        }

    }
}
