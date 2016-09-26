namespace Willo.Logic.Infrastructure
{
    public interface IQueryHandlerStore
    {
        IQueryHandler Get(IQuery query);
        void Register<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
        void Unregister<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
    }
}