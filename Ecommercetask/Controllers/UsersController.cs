using Ecommercetask.Core.Handlers.UsersHandler.Command.AddUsers;
using Ecommercetask.Core.Handlers.UsersHandler.Command.DeleteUsers;
using Ecommercetask.Core.Handlers.UsersHandler.Command.SignInUser;
using Ecommercetask.Core.Handlers.UsersHandler.Command.UpdateUsers;
using Ecommercetask.Core.Handlers.UsersHandler.Queries.GetAllUsers;
using Ecommercetask.Core.Handlers.UsersHandler.Queries.GetUserByEmail;
using Ecommercetask.Core.Handlers.UsersHandler.Queries.GetUserById;
using Ecommercetask.Core.Handlers.UsersHandler.Queries.LogOutUser;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    public class UsersController : AppApiController
    {
        public UsersController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator) { }

        [HttpPost("create-user")]
        public async Task<IActionResult> SignUp([FromBody] AddUsersCommand command, CancellationToken ct)
        {
            if (command == null)
                return BadRequest();
            var result = await _mediator.Send(command, ct);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(errors);
            }
            return Ok(result);
        }

        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery(), ct));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInUserCommand command, CancellationToken ct)
        {

            var status = await _mediator.Send(command, ct);
            if (status.Token == null)
            {
                return Unauthorized(status);
            }
            return Ok(status);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new LogOutUserQuery(), ct));
        }

        [HttpGet("get-user-byemail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetUserByEmailQuery { Email = email }, ct));
        }

        [HttpGet("get-user-byid/{Id}")]
        public async Task<IActionResult> GetUserById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-user-byid/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteUserByIdCommand { Id = Id }, ct));
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> Update(UsersModel usersModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateUserCommand { usersModel = usersModel }, ct));
        }
    }
}