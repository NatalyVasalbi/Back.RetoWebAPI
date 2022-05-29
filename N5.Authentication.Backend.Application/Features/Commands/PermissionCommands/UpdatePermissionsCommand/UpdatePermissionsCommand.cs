using MediatR;
using System;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand
{
    public class UpdatePermissionsCommand : IRequest<int>
    {
        public int Id { get; set; } 
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int? PermissionTypeId { get; set; }
        public DateTime? PermissionDate { get; set; }
    }
}
