using MediatR;
using N5.Authentication.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Features.Queries.PermissionQueries
{
    public class GetAllPermissionsQuery: IRequest<List<Permissions>>
    {
        public GetAllPermissionsQuery() { }
    }
}
