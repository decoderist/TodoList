using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Contracts.Persistence;
using TodoList.Persistence.Repositories;
using todoTest.Application.Contracts.Persistence;

namespace TodoList.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoListDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("TodoListConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ITodoItemRepository, TodoItemRepository>();


            return services;
        }

    }
}
