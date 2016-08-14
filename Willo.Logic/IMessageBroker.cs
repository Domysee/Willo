namespace Willo.Logic
{
    public interface IMessageBroker
    {
        T Query<T>(IQuery<T> query);
        void RegisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
        void UnregisterHandler<TQuery, TReturn>(IQueryHandler<TQuery, TReturn> handler) where TQuery : IQuery<TReturn>;
    }
}