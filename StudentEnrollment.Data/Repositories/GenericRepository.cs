using StudentEnrollment.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollment.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly StudentEnrollmentDbContext _context;

        public GenericRepository(StudentEnrollmentDbContext context)
        {
            _context = context;
        }


        public async  Task<TEntity> GetAsync(int id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);
            return result;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async  Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id); 
            _context.Set<TEntity>().Remove(entity);
            var result= await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _context.Set<TEntity>().AnyAsync(x => x.Id == id);
            return result;
        }
    }
}
