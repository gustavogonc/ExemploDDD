using ExemploDDD.Application.UseCases.User.ListActiveUsers;
using ExemploDDD.Application.UseCases.User.Register;
using ExemploDDD.Communication.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExemploDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //[Authorize]
        [HttpPost]
        [Route("register-new-user")]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterUserUseCase useCase, RegisterUserRequest request)
        {
            await useCase.ExecuteAsync(request);
            return Created();
        }

        [HttpGet]
        [Route("recover-active-users")]
        public async Task<IActionResult> RecoverAllActiveUsers([FromServices] IRecoverActiveUsersUseCase useCase)
        {
            var results = await useCase.ExecuteAsync();
            return Ok(results);
        }
    }
}
