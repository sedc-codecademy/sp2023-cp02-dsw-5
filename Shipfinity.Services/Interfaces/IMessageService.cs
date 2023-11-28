using Shipfinity.Domain.Models;
using Shipfinity.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message> SendMessageAsync(MessageDto messageDto, string role);
    }
}
