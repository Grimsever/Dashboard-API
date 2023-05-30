using System.Threading.Tasks;
using SecurityAPI.BLL.Contracts.Requests.Identity;
using SecurityAPI.BLL.Contracts.Responses.Identity;

namespace SecurityAPI.BLL.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(UserLoginRequest request);
        
        Task<AuthenticationResult> RegisterAsync(UserRegisterRequest request);
    }
}