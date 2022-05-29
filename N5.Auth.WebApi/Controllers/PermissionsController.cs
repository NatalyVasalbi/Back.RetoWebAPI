using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand;
using N5.Authentication.Backend.Application.Features.Queries.PermissionQueries;
using N5.Authentication.Backend.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.DeletePermissionsCommand;
using Microsoft.AspNetCore.Http;

namespace N5.Auth.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionsController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILogger<PermissionsController> _logger;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public PermissionsController(ILogger<PermissionsController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CreatePermissions")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreatePermission([FromBody] CreatePermissionsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut(Name = "UpdatePermissions")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdatePermission([FromBody] UpdatePermissionsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{userName}", Name = "GetPermissions")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetPermissionsByUserName(string userName)
        {
            var query = new GetPermissionsQuery(userName);
            var permissions = await Mediator.Send(query);
            return Ok(permissions);
        }
        [HttpGet(Name = "GetAllPermissions")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetAllPermissions()
        {
            var query = new GetAllPermissionsQuery();
            var permissions = await Mediator.Send(query);
            return Ok(permissions);
        }        

        [HttpDelete("{id}", Name = "DeletePermissions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePermissions(int id)
        {
            var command = new DeletePermissionsCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
}
}
