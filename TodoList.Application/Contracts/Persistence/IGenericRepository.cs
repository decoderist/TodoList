using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Domain.Common;

namespace todoTest.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetItem(Guid id);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exist(Guid id);
    }
}
