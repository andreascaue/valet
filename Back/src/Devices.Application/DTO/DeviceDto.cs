using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Devices.Application.DTO
{
    public class DeviceDto
    {
        public int DeviceID { get; set; }     
        public string DeviceName { get; set; }        
        public int? CategoryID { get;  set; }
        public string Details { get;  set; }
        public decimal? Usage { get; set; }       
        public bool DeviceStatus { get; set; }
        public System.DateTime? Date { get; set; }
        public string ImageURL { get; set; }
    }
}