using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityAPI.BLL.Contracts.Requests.Identity;
using SecurityAPI.BLL.Contracts.Responses.Identity;
using SecurityAPI.BLL.Interfaces;

namespace SecurityAPI.WEB.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public AuthController(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors,
                });
            }

            var authSuccess = _mapper.Map<AuthSuccessResponse>(authResponse);
            return Ok(authSuccess);
        }
        
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors,
                });
            }

            var authSuccess = _mapper.Map<AuthSuccessResponse>(authResponse);
            return Ok(authSuccess);
        }
    }
}