using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic;
using Willo.Logic.Infrastructure;

namespace Willo.View.Components.UserMessaging.Messaging
{
    public class MessageUserCommand : ICommand
    {
        public string Message { get; }
        public MessageType Type { get; }

        public MessageUserCommand(string message, MessageType type)
        {
            Message = message;
            Type = type;
        }
    }
}
