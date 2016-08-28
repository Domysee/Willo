using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic;
using Willo.View.Components.UserMessaging.Messaging;
using Willo.View.Infrastructure;

namespace Willo.View.Components.UserMessaging
{
    public class NotificationViewViewmodel : BindableBase
    {
        private IMessageBroker messageBroker;

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private MessageType? type;
        public MessageType? Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }
        public NotificationViewViewmodel(IMessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public void Initialize()
        {
            messageBroker.RegisterHandler(new LambdaCommandHandler<MessageUserCommand>(messageUserCommandHandler));
        }

        private IEnumerable<IError> messageUserCommandHandler(MessageUserCommand command)
        {
            Type = command.Type;
            Message = command.Message;

            Task.Delay(2000).ContinueWith(t =>
            {
                Type = null;
                Message = null;
            });

            return Enumerable.Empty<IError>();
        }
    }
}
