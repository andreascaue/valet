using System.Threading.Tasks;
using Devices.Domain;

namespace Devices.Persistence
{
    public interface IGeneralPersistence
    {          
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

    }
}