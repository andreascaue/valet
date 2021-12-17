using System.Threading.Tasks;
using Devices.Persistence.Context;

namespace Devices.Persistence
{
    public class GeneralPersistence : IGeneralPersistence
    {
        private readonly DevicesContext _deviceContext;

        public GeneralPersistence(DevicesContext deviceContext)
        {
            this._deviceContext = deviceContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _deviceContext.Add(entity);         
        }

        public void Update<T>(T entity) where T : class
        {
            _deviceContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _deviceContext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _deviceContext.RemoveRange(entityArray);
        }       

        public async Task<bool> SaveChangesAsync()
        {
            return (await _deviceContext.SaveChangesAsync()) > 0;
        }
    }
}