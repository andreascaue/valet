using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Devices.Domain;
using Devices.Persistence;

namespace Devices.Persistence
{
    public class DevicesPersistence : IDevicesPersistence
    {
        private readonly DevicesContext _context;
        public DevicesPersistence(DevicesContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Device[]> GetAllDevicesAsync()
        {
            IQueryable<Device> query = _context.Devices;           

            query = query.AsNoTracking().OrderBy(e => e.DeviceID);

            return await query.ToArrayAsync();
        }

        public async Task<Device[]> GetAllDevicesByNameAsync(string name)
        {
            IQueryable<Device> query = _context.Devices;
               

            query = query.AsNoTracking().OrderBy(e => e.DeviceID)
                         .Where(e => e.DeviceName.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(int deviceID)
        {
            IQueryable<Device> query = _context.Devices;
                           
            query = query.AsNoTracking().OrderBy(e => e.DeviceID)
                         .Where(e => e.DeviceID == deviceID);

            return await query.FirstOrDefaultAsync();
        }

    }
}