using System;

namespace Devices.Domain
{
    public class Device
    {

        public Device(){

        }
        public Device(string deviceName 
                    ,int? temperature         
                    ,int? categoryID 
                    ,string details 
                    ,decimal? usage     
                    ,bool deviceStatus 
                    ,DateTime? date
                    ,string imageURL
                    )
        {           
            DeviceName = deviceName; 
            Temperature = temperature;         
            CategoryID = categoryID;
            Details = details;
            Usage = usage;     
            DeviceStatus = deviceStatus;
            ImageURL = imageURL;
        }

        public Device(int deviceID 
                    ,string deviceName 
                    ,int? temperature         
                    ,int? categoryID 
                    ,string details 
                    ,decimal? usage     
                    ,bool deviceStatus 
                    ,DateTime? date
                    ,string imageURL) :

            this(deviceName,
                temperature,         
                categoryID,
                details,
                usage,     
                deviceStatus,
                date,
                imageURL)
        {
            DeviceID = deviceID;            
        }    

        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public int? Temperature { get; set; }
        public int? CategoryID { get; set; }
        public string Details { get; set; }
        public decimal? Usage { get; set; }       
        public bool DeviceStatus { get; set; }
        public System.DateTime? Date { get; set; }
        public string ImageURL { get; set; }
    }
  }