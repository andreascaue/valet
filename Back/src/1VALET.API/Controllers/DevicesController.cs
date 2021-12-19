using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Devices.Application;
using Devices.Domain;
using Microsoft.AspNetCore.Http;
using Devices.Application.DTO;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace _1VALET.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {        
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
           _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          try 
          {
              var devices = await _deviceService.GetAllDevicesAsync();
              if(devices == null) return NotFound("Devices not found.");
              
              return Ok(devices);
          }
          catch(Exception ex) 
          {
              return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error to return devices. Error: { ex.Message }");
          }                     
        }
        

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var device = await _deviceService.GetDeviceByIdAsync(id);
                if (device == null) return NoContent();

                return Ok(device);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to return devices. Error: {ex.Message}");
            }
        }

        [HttpGet("{name}/name")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var device = await _deviceService.GetAllDevicesByNameAsync(name);
                if (device == null) return NoContent();

                return Ok(device);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to return Devices. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Device model)
        {
            try
            {
                var device = await _deviceService.AddDevices(model);
                if (device == null) return NoContent();

                return Ok(device);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to try to add devices. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Device model)
        {
            try
            {
                var device = await _deviceService.UpdateDevice(id, model);
                if (device == null) return NoContent();

                 return Ok(new { message = "Updated" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to try to update devices. Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var device = await _deviceService.GetDeviceByIdAsync(id);
                if (device == null) return NoContent();

                if (await _deviceService.DeleteDevice(id))
                {                   
                    return Ok(new { message = "Deteled" });
                }
                else
                {
                    throw new Exception("There was a problem trying to delete Device.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to try to delete Devices. Error: {ex.Message}");
            }
        }
       
    }
}
