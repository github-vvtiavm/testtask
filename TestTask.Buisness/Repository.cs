using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Common.Abstract;

namespace TestTask.Buisness
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityKey
    {
        private readonly IDbContext _context;

        public Repository(IDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() => _context.Set<TEntity>().Add(entity));

        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() => _context.Set<TEntity>().AsQueryable());
        }
    }
}
