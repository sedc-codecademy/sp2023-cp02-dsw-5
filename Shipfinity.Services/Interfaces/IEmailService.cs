using Shipfinity.DTOs.EmailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto request);

    }
}
