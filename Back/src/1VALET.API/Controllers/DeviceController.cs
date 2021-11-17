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
    public class DeviceController : ControllerBase
    {        

        private readonly DataContext _context;

        public DeviceController(DataContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IEnumerable<Device> Get()
        {
          return _context.Devices;           
        }
        

        [HttpGet("{id}")]
        public IEnumerable<Device> GetByID(int id)
        {
          return _context.Devices.Where(device => device.DeviceID == id);           
        }
       
    }
}
