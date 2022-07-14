using Ecommercetask.Core.Handlers.AddressHandler.Command.AddAdress;
using Ecommercetask.Core.Handlers.AddressHandler.Command.DeleteAdress;
using Ecommercetask.Core.Handlers.AddressHandler.Command.UpdateAddress;
using Ecommercetask.Core.Handlers.AddressHandler.Queries.GetAddressById;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    
    public class AddressController : AppApiController
    {
        public AddressController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator) {}

        [HttpPost("add-address")]
        public async Task<IActionResult> Add([FromBody] AddAddressCommand command, CancellationToken ct)
        {
            return  Ok(await _mediator.Send(command, ct));
        }

        //[HttpGet("get-all-address")]
        //public Task<IEnumerable<AddressModel>> GetAll(CancellationToken ct)
        //{
        //    return _mediator.Send(new GetAllAddressQuery(), ct);
        //}

        [HttpGet("get-addressbyid/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAddressByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-address/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteAddressCommand { Id = Id }, ct));
        }

        [HttpPut("update-address")]
        public async Task<IActionResult> Update(AddressModel addressModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateAddressCommand { addressModel = addressModel }, ct));
        }
    }
}