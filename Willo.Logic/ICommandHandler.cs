using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public interface ICommandHandler
    {
        Task<IEnumerable<IError>> Handle(ICommand command);
    }

    public interface ICommandHandler<TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        /// <summary>
        /// handles the command
        /// </summary>
        /// <param name="command"></param>
        /// <returns>a list of errors, null if no error occurred</returns>
        Task<IEnumerable<IError>> Handle(TCommand command);
    }
}
