using Microsoft.EntityFrameworkCore;
using OngProject.Core.Models;
using OngProject.DataAccess;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext<T> _dbContext;

        public Repository(DbContext<T> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(T entity)
        {
            T existing = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existing == null)
                return;

            _dbContext.Set<T>().Remove(existing);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync<T>(x => x.Id == id);
        }

        public async Task Insert(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
