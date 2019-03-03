using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Common.Abstract
{
    public interface IRepository<TEntity> where TEntity : EntityKey
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
    }
}
