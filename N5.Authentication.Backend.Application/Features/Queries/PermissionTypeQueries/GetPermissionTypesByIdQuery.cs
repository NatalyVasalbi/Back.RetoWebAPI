using MediatR;
using N5.Authentication.Backend.Domain;

namespace N5.Authentication.Backend.Application.Features.Queries.PermissionQueries
{
    public class GetPermissionTypesByIdQuery : IRequest<PermissionTypes>
    {
        public int permissionTypeId  { get; set; }

        public GetPermissionTypesByIdQuery(int permissionTypeId)
        {
            this.permissionTypeId = permissionTypeId;
        }
    }
}
