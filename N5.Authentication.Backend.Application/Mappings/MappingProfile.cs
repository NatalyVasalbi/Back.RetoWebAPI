using AutoMapper;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand;
using N5.Authentication.Backend.Domain;

namespace N5.Authentication.Backend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdatePermissionsCommand, Permissions>().ReverseMap();
            CreateMap<CreatePermissionsCommand, Permissions>().ReverseMap();
            
        }
    }
}
