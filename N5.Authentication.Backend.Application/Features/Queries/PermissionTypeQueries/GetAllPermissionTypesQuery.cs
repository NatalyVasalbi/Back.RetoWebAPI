using MediatR;
using N5.Authentication.Backend.Domain;
using System.Collections.Generic;

namespace N5.Authentication.Backend.Application.Features.Queries.PermissionQueries
{
    public class GetAllPermissionTypesQuery : IRequest<List<PermissionTypes>>
    {
        public GetAllPermissionTypesQuery()
        {
        }
    }
}
