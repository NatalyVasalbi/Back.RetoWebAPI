using FluentValidation;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand
{
    public class UpdatePermissionsCommandValidator : AbstractValidator<UpdatePermissionsCommand>
    {
        public UpdatePermissionsCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEqual(0).WithMessage("{Id} no puede ser 0")
                .NotNull();
            RuleFor(p => p.EmployeeName)
                .NotEmpty().WithMessage("{EmployeeForename} no puede estar en blanco")
                .NotNull();
            RuleFor(p => p.EmployeeLastName)
              .NotEmpty().WithMessage("{EmployeeSurname} no puede estar en blanco")
              .NotNull();
            RuleFor(p => p.PermissionTypeId)
              .NotEmpty().WithMessage("{PermissionTypeId} no puede estar en blanco")
              .NotNull();
            RuleFor(p => p.PermissionDate)
              .NotEmpty().WithMessage("{PermissionDate} no puede estar en blanco")
              .NotNull();
           

        }
    }
}
