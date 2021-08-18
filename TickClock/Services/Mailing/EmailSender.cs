using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickClock.Services.Interfaces;

namespace TickClock.Services.Mailing
{
    public class EmailSender:IEmailSender
    {
        public Task SendEmailAsync(string email,string subject,string message)
        {
            return Task.CompletedTask;
        }
    }
}
