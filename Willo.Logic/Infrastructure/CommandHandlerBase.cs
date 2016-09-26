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
        public async Task<IEnumerable<IError>> Handle(ICommand command)
        {
            if (!(command is TCommand))
                throw new ArgumentException("The command type doesn't match");
            return await Handle((TCommand)command);
        }

        public abstract Task<IEnumerable<IError>> Handle(TCommand command);
    }
}
