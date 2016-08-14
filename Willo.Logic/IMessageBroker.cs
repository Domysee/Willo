using System.Collections.Generic;

namespace Willo.Logic
{
    public interface IMessageBroker
    {
        IEnumerable<IError> Command(ICommand command);
        T Query<T>(IQuery<T> query);
        void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        void RegisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
        void UnregisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        void UnregisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
    }
}