using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _1VALET.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {        
        public EventController()
        {
           
        }

        [HttpGet]
        public string Get()
        {
          return "value";
        }
    }
}
