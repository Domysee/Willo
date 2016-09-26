using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic.Infrastructure
{
    public class CommandResult
    {
        public ResultState State { get; private set; }
        public IEnumerable<IError> Errors { get; private set; }

        private CommandResult() { }

        public static CommandResult Create(IEnumerable<IError> errors)
        {
            if (errors == null || errors.Count() == 0)
                return CommandResult.CreateSuccess();
            else
                return CommandResult.CreateFailure(errors);
        }

        public static CommandResult CreateSuccess()
        {
            return new CommandResult
            {
                State = ResultState.Success,
                Errors = Enumerable.Empty<IError>()
            };
        }

        public static CommandResult CreateFailure(IEnumerable<IError> errors)
        {
            return new CommandResult
            {
                State = ResultState.Failure,
                Errors = errors
            };
        }
    }
}
