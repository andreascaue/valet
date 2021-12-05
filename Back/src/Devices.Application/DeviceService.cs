using System;
using System.Threading.Tasks;
using Devices.Domain;
using Devices.Persistence;
using Devices.Application.DTO;
using AutoMapper;

namespace Devices.Application
{
    public class DeviceService : IDeviceService
    {

         private readonly IGeneralPersistence _generalPersistence;
        private readonly IDevicesPersistence _devicesPersistence;
      
        public DeviceService(IGeneralPersistence generalPersistence,
                             IDevicesPersistence devicesPersistence)
        {
            _generalPersistence = generalPersistence;
            _devicesPersistence = devicesPersistence;            
        }
        public async Task<Device> AddDevices(Device model)
        {
            try
            {
                _generalPersistence.Add<Device>(model);
                if(await _generalPersistence.SaveChangesAsync())
                {
                    return await _devicesPersistence.GetDeviceByIdAsync(model.DeviceID);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

       public async Task<bool> DeleteDevice(int deviceId)
    {
        try
        {
            var device = await _devicesPersistence.GetDeviceByIdAsync(deviceId);
            if (device == null) throw new Exception("Event to Delete not found.");

            _generalPersistence.Delete<Device>(device);
            return await _generalPersistence.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

        public async Task<Device> GetDeviceByIdAsync(int devicesId)
        {
            try
            {
                var device = await _devicesPersistence.GetDeviceByIdAsync(devicesId);
                if (device == null) return null;
                
                var result = device;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Device[]> GetAllDevicesAsync()
        {
            try
            {
                var devices = await _devicesPersistence.GetAllDevicesAsync();
                if (devices == null) return null;

                var result = devices;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Device[]> GetAllDevicesByNameAsync(string name)
        {
            try
            {
                var devices = await _devicesPersistence.GetAllDevicesByNameAsync(name);
                if (devices == null) return null;

                var result = devices;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Device> UpdateDevice(int deviceId, Device model)
        {
           try
           {
                var device = await _devicesPersistence.GetDeviceByIdAsync(deviceId);
                if(device == null) return null;

                model.DeviceID = device.DeviceID;

                _generalPersistence.Update(model);
                if(await _generalPersistence.SaveChangesAsync()){
                    return await _devicesPersistence.GetDeviceByIdAsync(model.DeviceID);
                }
                return null;
           }
           catch (System.Exception)
           {
               
               throw;
           }
        }
    }
}