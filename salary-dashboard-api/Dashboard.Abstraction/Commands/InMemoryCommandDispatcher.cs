using System;
using System.Threading.Tasks;
using Dashboard.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Abstraction.Commands
{
    internal sealed class InMemoryCommandDispatcher
        : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command)
        {
            using var scope = _serviceProvider.CreateScope();
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

            return await (Task<TResult>)handlerType
                .GetMethod(nameof(ICommandHandler<ICommand<TResult>, TResult>.HandleAsync))?
                .Invoke(handler, new[] { command });
        }

        public Task<TResult> DispatchAsync<TResult, TCommand>(TCommand command) where TCommand : class, ICommand<TResult>
        {
            throw new NotImplementedException();
        }
    }
}
