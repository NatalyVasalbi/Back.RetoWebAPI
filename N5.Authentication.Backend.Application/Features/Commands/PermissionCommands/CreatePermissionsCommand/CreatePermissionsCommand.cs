using MediatR;
using System;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand
{
    public class CreatePermissionsCommand : IRequest<int>
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int? PermissionTypeId { get; set; }
        public DateTime? PermissionDate { get; set; }
    }
}
