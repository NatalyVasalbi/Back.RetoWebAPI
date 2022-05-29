using MediatR;
using N5.Authentication.Backend.Domain;
using System;
using System.Collections.Generic;

namespace N5.Authentication.Backend.Application.Features.Queries.PermissionQueries
{
    public class GetPermissionsQuery : IRequest<List<Permissions>>
    {
        public string _Username { get; set; } = String.Empty;

        public GetPermissionsQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
