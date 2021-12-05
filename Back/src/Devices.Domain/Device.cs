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
        public string DeviceName { get; private set; }
        public int? Temperature { get; private set; }
        public int? CategoryID { get; private set; }
        public string Details { get; private set; }
        public decimal? Usage { get; private set; }       
        public bool DeviceStatus { get; private set; }
        public System.DateTime? Date { get; private set; }
        public string ImageURL { get; private set; }
    }
  }