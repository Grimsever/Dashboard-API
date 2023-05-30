using System.Threading.Tasks;

namespace Dashboard.Shared.Commands
{
    public interface ICommandDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command);
    }
}
