using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using N5.Authentication.Backend.Application.Features.Queries.PermissionQueries;
using N5.Authentication.Backend.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace N5.Auth.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionTypesController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILogger<PermissionTypesController> _logger;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public PermissionTypesController(ILogger<PermissionTypesController> logger)
        {
            _logger = logger;          
        }

        [HttpGet(Name = "GetAllPermissionTypes")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetAllPermissionTypes()
        {
            var query = new GetAllPermissionTypesQuery();
            var permissions = await Mediator.Send(query);
            return Ok(permissions);
        }
        [HttpGet("{permissionTypeId}", Name = "GetPermissionTypesById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetPermissionTypesById(int permissionTypeId)
        {
            var query = new GetPermissionTypesByIdQuery(permissionTypeId);
            var permissions = await Mediator.Send(query);
            return Ok(permissions);
        }
    }
}
