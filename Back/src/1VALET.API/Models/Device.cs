//using BuildingMaterialsStore.Domain.Validations;

namespace _1VALET.API.Controllers
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
                    ,string imageURL)
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
                    ,string imageURL) :

            this(deviceName,
                temperature,         
                categoryID,
                details,
                usage,     
                deviceStatus,
                imageURL)
        {
            DeviceID = deviceID;            
        }    

        public int DeviceID { get; private set; }
        public string DeviceName { get; private set; }
        public int? Temperature { get; private set; }
        public int? CategoryID { get; private set; }
        public string Details { get; private set; }
        public decimal? Usage { get; private set; }       
        public bool DeviceStatus { get; private set; }
        public string ImageURL { get; private set; }
    }


    /* 
    public override bool IsValid()
    {
        ValidationResult = new ProductValidation().Validate(this);
        return ValidationResult.IsValid;           
    }
    */
}