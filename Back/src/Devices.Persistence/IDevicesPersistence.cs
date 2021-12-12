using System.Threading.Tasks;
using Devices.Domain;

namespace Devices.Persistence
{
    public interface IDevicesPersistence
    {         
        Task<Device[]> GetAllDevicesByNameAsync(string name);

        Task<Device[]> GetAllDevicesAsync();

        Task<Device> GetDeviceByIdAsync(int DevicesId);
    }
}