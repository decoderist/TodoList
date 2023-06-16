using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contracts.Persistence;
using TodoList.Domain;
using TodoList.Application.Models.Identity;

namespace TodoList.Persistence.Repositories
{
    public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        private readonly TodoListDbContext _dbContext;

        public TodoItemRepository(TodoListDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TodoItem>> GetCompleteItems(ApplicationUser currentUser)
        {
            return await _dbContext.TodoItems
                .Where(t => t.Done && t.CreatedBy == currentUser.Id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItems(ApplicationUser currentUser)
        {
            return await _dbContext.TodoItems
                .Where(t => !t.Done && t.CreatedBy == currentUser.Id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetItemsByTag(ApplicationUser currentUser, string tag)
        {
            return await _dbContext.TodoItems
                .Where(t => t.Tags.Contains(tag) && t.CreatedBy == currentUser.Id)
                .ToArrayAsync();
        }

        public async Task<bool> AddItem(TodoItem todo, ApplicationUser curretUser)
        {
            todo.Id = Guid.NewGuid();
            todo.Done = false;
            todo.CreatedDate = DateTime.Now;
            todo.CreatedBy = curretUser.Id;

            _dbContext.TodoItems.Add(todo);

            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> UpdateItem(TodoItem editedTodo, ApplicationUser currentUser)
        {
            var todo = await _dbContext.TodoItems
                .Where(t => t.Id == editedTodo.Id && t.CreatedBy == currentUser.Id)
                .SingleOrDefaultAsync();

            if (todo == null) return false;

            todo.Title = editedTodo.Title;
            todo.Content = editedTodo.Content;
            todo.Tags = editedTodo.Tags;

            var saved = await _dbContext.SaveChangesAsync();
            return saved == 1;
        }

        public async Task<bool> UpdateDone(Guid id, ApplicationUser currentUser)
        {
            var todo = await _dbContext.TodoItems
                .Where(t => t.Id == id && t.CreatedBy == currentUser.Id)
                .SingleOrDefaultAsync();

            if (todo == null) return false;
            todo.Done = !todo.Done;

            var saved = await _dbContext.SaveChangesAsync();
            return saved == 1;
        }

        public async Task<bool> DeleteItem(Guid id, ApplicationUser currentUser)
        {
            var todo = await _dbContext.TodoItems
                //.Include(t => t.File)
                .Where(t => t.Id == id && t.CreatedBy == currentUser.Id)
                .SingleOrDefaultAsync();

            _dbContext.TodoItems.Remove(todo);

            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
