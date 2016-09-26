namespace Willo.Logic.Infrastructure
{
    public interface ICommandHandlerStore
    {
        ICommandHandler Get(ICommand query);
        void Register<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        void Unregister<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
    }
}