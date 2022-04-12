namespace HashShop.Handlers.Interfaces
{
    public interface IHandler<T>
    {
        void SetNext(IHandler<T> handler);
        void Handle(T request);
    }
}
