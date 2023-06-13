using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Models;

namespace TodoList.Application.Contracts.Infrastraucture
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
