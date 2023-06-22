using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Models.Identity;
using TodoList.Domain;
using todoTest.Application.Contracts.Persistence;

namespace TodoList.Application.Contracts.Persistence
{
    public interface ITodoItemRepository:IGenericRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItems(ApplicationUser currentUser);
        Task<IEnumerable<TodoItem>> GetCompleteItems(ApplicationUser currentUser);
        Task<IEnumerable<TodoItem>> GetItemsByTag(ApplicationUser currentUser, string tag);
        Task<IEnumerable<TodoItem>> GetRecentlyAddedItems(ApplicationUser currentUser);
        Task<IEnumerable<TodoItem>> GetDueTo2DaysItems(ApplicationUser user);
        Task<IEnumerable<TodoItem>> GetMonthlyItems(ApplicationUser user, int Month);
        Task<bool> UpdateDone(Guid id, ApplicationUser currentUser);
        Task<bool> AddItem(TodoItem todo, ApplicationUser currentUser);
        Task<bool> UpdateItem(TodoItem editedTodo, ApplicationUser currentUser);
        Task<bool> DeleteItem(Guid id, ApplicationUser currentUser);



    }
}
