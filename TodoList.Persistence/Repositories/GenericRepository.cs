using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Common;
using todoTest.Application.Contracts.Persistence;

namespace TodoList.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TodoListDbContext _dbContext;

        public GenericRepository(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetItem(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> Exist(Guid id)
        {
            var entity = await GetItem(id);
            return entity != null;
        }
    }
}
