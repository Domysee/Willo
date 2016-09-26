using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Infrastructure
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public async Task<CommandResult> Handle(ICommand command)
        {
            if (!(command is TCommand))
                throw new ArgumentException("The command type doesn't match");
            return await Handle((TCommand)command);
        }

        public abstract Task<CommandResult> Handle(TCommand command);
    }
}
