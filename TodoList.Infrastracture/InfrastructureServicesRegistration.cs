using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contracts.Infrastraucture;
using TodoList.Application.Contracts.Persistence;
using TodoList.Application.Models;
using TodoList.Infrastracture.Mail;
using todoTest.Application.Contracts.Persistence;

namespace TodoList.Infrastracture
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
