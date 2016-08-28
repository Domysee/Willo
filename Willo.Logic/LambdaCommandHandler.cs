using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public class LambdaCommandHandler<TCommand> : CommandHandlerBase<TCommand>
        where TCommand : ICommand
    {
        private Func<TCommand, IEnumerable<IError>> func;

        public LambdaCommandHandler(Func<TCommand, IEnumerable<IError>> func)
        {
            this.func = func;
        }

        public override Task<IEnumerable<IError>> Handle(TCommand command)
        {
            var result = func(command);
            return Task.FromResult(result);
        }
    }
}
