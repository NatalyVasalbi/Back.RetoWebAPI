using FluentValidation;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand
{
    public class CreatePermissionsCommandValidator : AbstractValidator<CreatePermissionsCommand>
    {
        public CreatePermissionsCommandValidator()
        {
            RuleFor(p => p.EmployeeName)
                .NotEmpty().WithMessage("{EmployeeName} no puede ser vacío")
                .NotNull();
            RuleFor(p => p.EmployeeLastName)
              .NotEmpty().WithMessage("{EmployeeLastName} no puede ser vacío")
              .NotNull();
            RuleFor(p => p.PermissionTypeId)
              .NotEmpty().WithMessage("{PermissionTypeId} no puede ser vacío")
              .NotNull()
              .NotEqual(0);
            RuleFor(p => p.PermissionDate)
              .NotEmpty().WithMessage("{PermissionDate} no puede ser vacío")
              .NotNull();


        }
    }
}
