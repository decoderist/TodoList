using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;
using TodoList.Domain.Common;

namespace TodoList.Persistence
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> Options) : base(Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>()
             .Property(e => e.Tags)
             .HasConversion(t => string.Join(',', t),
              t => t.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }



        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
