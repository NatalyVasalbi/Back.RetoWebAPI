using MediatR;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.DeletePermissionsCommand
{
    public class DeletePermissionsCommand : IRequest
    {
        public int Id { get; set; }
    }
}
