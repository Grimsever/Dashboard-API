using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityAPI.BLL.Contracts.Requests;
using SecurityAPI.BLL.Contracts.Responses;
using SecurityAPI.BLL.Interfaces;
using SecurityAPI.Domain.Enums;
using SecurityAPI.WEB.Attributes;

namespace SecurityAPI.WEB.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AuthorizeRoles(Role.User, Role.Admin)]
        public async Task<ActionResult<List<UserDto>>> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        [AuthorizeRoles(Role.User, Role.Admin)]
        public async Task<ActionResult<UserDto>> GetByIdAsync([FromRoute]int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }
        
        [HttpPost]
        [AuthorizeRoles(Role.Admin)]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody]CreateUserRequest request)
        {
            return Ok(await _userService.CreateAsync(request));
        }
        
        [HttpPut]
        [AuthorizeRoles(Role.Admin)]
        public async Task<ActionResult<UserDto>> UpdateAsync([FromBody]UpdateUserRequest request)
        {
            return Ok(await _userService.UpdateAsync(request));
        }
        
        [HttpDelete("{id}")]
        [AuthorizeRoles(Role.Admin)]
        public async Task<ActionResult<int>> UpdateAsync([FromRoute]int id)
        {
            return Ok(await _userService.DeleteAsync(id));
        }
    }
}