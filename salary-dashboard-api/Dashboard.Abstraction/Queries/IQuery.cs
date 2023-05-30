namespace Dashboard.Abstraction.Queries
{
    public interface IQuery
    {
    }

    public interface IQuery<TResult>
        : IQuery
    {
    }
}
