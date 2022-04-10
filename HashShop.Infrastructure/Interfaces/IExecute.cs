namespace HashShop.Infrastructure.Interfaces
{
    public interface IExecute<T, K>
    {
        T Execute(K k);
    }
}
