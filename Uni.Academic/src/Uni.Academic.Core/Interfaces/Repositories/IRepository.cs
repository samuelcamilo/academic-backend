using System.Linq;
using Uni.Academic.Core.Commons;

namespace Uni.Academic.Core.Interfaces.Repositories
{
    public interface IRepository<T> 
        where T : Entity
    {
        long Insert(T entity);
        void Update(T entity);
        void Remove(long id);
        bool Exists(long id);
        T Get(long id);
        T GetAsNoTracking(long id);
        IQueryable<T> GetAll(); 
    }
}
