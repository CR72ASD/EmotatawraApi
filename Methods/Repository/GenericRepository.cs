using DataBase.Context;
using DataBase.Entity;
using Methods.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace Methods.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DBAContext _context;

        public GenericRepository(DBAContext context)
        {
            _context = context;
        }

        public void Add(T entity)
            => _context.Set<T>().Add(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

    }
}