using System;
using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Repositories;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands.Handlers
{
    public class AddUserHandler
        : ICommandHandler<AddUser, User>
    {
        private readonly IUserRepository _repository;

        public AddUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> HandleAsync(AddUser command)
        {
            var (firstName, lastName, middleName) = command;

            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
            };

            var result = await _repository.AddAsync(user);

            return result;
        }
    }
}
