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
        public DeviceController()
        {
           
        }

        IEnumerable<Device> _device =  new Device[] {
                new Device(1,"Device 01" 
                    ,1         
                    ,1  
                    ,"Smartphone Iphone 11" 
                    ,10     
                    ,true 
                    ,"smartpicture") {},

               new Device (2,"Device 02" 
                    ,10         
                    ,1  
                    ,"Smartphone Galaxy S20" 
                    ,10     
                    ,true 
                    ,"smartpicture") {},  

                    new Device ("Device 03" 
                    ,10         
                    ,1  
                    ,"Ipad Mini" 
                    ,10     
                    ,true 
                    ,"tabletpicture") {}, 
          };         

        [HttpGet]
        public IEnumerable<Device> Get()
        {
          return _device;           
        }
        

        [HttpGet("{id}")]
        public IEnumerable<Device> GetByID(int id)
        {
          return _device.Where(device => device.DeviceID == id);           
        }
       
    }
}
