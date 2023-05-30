using System.Threading.Tasks;
using SecurityAPI.BLL.Contracts.Responses.Identity;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.BLL.Interfaces
{
    public interface ITokenService
    {
        AuthenticationResult GenerateAuthenticationResultForUser(User user);
    }
}