using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Persistence.Configurations.Entities
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasData(
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = "a58633c9-3c6a-4580-8ad1-0720b582094f",
                    CreatedDate = DateTime.Now,
                    Done = false,
                    Title = "Title1",
                    Content = "Content1",
                    Tags = new List<string>()
                    {
                        "Daily"
                    }
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = "a58633c9-3c6a-4580-8ad1-0720b582094f",
                    CreatedDate = DateTime.Now,
                    Done = true,
                    Title = "Title2",
                    Content = "Content2",
                    Tags = new List<string>()
                    {
                        "Monthly"
                    }
                }
                );
        }
    }
}
