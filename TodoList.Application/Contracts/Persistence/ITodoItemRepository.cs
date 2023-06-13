﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Domain.Common;
using todoTest.Application.Contracts.Persistence;

namespace TodoList.Application.Contracts.Persistence
{
    public interface ITodoItemRepository:IGenericRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItems(ApplicationUser currentUser);
        Task<IEnumerable<TodoItem>> GetCompleteItems(ApplicationUser currentUser);
        Task<IEnumerable<TodoItem>> GetItemsByTag(ApplicationUser currentUser, string tag);
        Task<bool> UpdateDone(Guid id, ApplicationUser currentUser);
        Task<IEnumerable<TodoItem>> GetRecentlyAddedItems(ApplicationUser currentUser);

    }
}