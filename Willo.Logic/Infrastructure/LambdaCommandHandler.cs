using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Infrastructure
{
    public class LambdaCommandHandler<TCommand> : CommandHandlerBase<TCommand>
        where TCommand : ICommand
    {
        private Func<TCommand, CommandResult> func;

        public LambdaCommandHandler(Func<TCommand, CommandResult> func)
        {
            this.func = func;
        }

        public override Task<CommandResult> Handle(TCommand command)
        {
            var result = func(command);
            return Task.FromResult(result);
        }
    }
}
