using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn()
        {
            var res = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            if (!res.Succeeded)
            {
                return Unauthorized();
            }

            var claims = res.Principal.Identities.FirstOrDefault()
                .Claims.Select(x =>
            new
            {
                x.Issuer,
                x.OriginalIssuer,
                x.Type,
                x.Value
            });

            return Ok(claims);
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return Ok();
        }
    }
}
