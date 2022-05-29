using Autofac;
using MediatR;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.DeletePermissionsCommand;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand;
using N5.Authentication.Backend.Application.Features.Queries.PermissionQueries;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace N5.Authentication.Backend.Application.Configuration
{
    [ExcludeFromCodeCoverage]
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(CreatePermissionsCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdatePermissionsCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeletePermissionsCommand).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetPermissionsQuery).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetAllPermissionTypesQuery).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetPermissionTypesByIdQuery).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(GetAllPermissionsQuery).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));
            
        }
    }
}
