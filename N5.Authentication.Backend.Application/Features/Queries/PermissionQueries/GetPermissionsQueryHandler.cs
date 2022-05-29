using AutoMapper;
using MediatR;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Features.Queries.PermissionQueries
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<Permissions>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Permissions>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissionsList = await _unitOfWork.PermissionsRepository.GetPermissionsByUserName(request._Username);

            return permissionsList.ToList();
        }
    }
   
}
