using System.Threading.Tasks;
using Devices.Domain;
using Devices.Application.DTO;

namespace Devices.Application
{
    public interface IDeviceService
    {
        Task<Device> AddDevices(Device model);
        
        Task<Device> UpdateDevice(int deviceId, Device model);

        Task<bool> DeleteDevice(int deviceId);

        Task<DeviceDto[]> GetAllDevicesByNameAsync(string name);

        Task<DeviceDto[]> GetAllDevicesAsync();

        Task<DeviceDto> GetDeviceByIdAsync(int DevicesId);
    }
}
