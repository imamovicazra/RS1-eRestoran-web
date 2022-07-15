﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments);
        Task SendEmailAsync(IEnumerable<string> to, string subject, string content);
    }
}
