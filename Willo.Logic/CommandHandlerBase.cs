using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public IEnumerable<IError> Handle(ICommand command)
        {
            if (!(command is TCommand))
                throw new ArgumentException("The command type doesn't match");
            return Handle((TCommand)command);
        }

        public abstract IEnumerable<IError> Handle(TCommand command);
    }
}
