using System.Collections.Generic;
using System.Threading.Tasks;

namespace Willo.Logic
{
    public interface IMessageBroker
    {
        IEnumerable<IError> Command(ICommand command);
        Task<T> Query<T>(IQuery<T> query);
        void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        void RegisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
        void UnregisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        void UnregisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
    }
}