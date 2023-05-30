using System.Threading.Tasks;

namespace Dashboard.Abstraction.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
