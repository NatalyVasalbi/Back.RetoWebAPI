using AutoMapper;
using MediatR;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Features.Queries.PermissionQueries
{
    public class GetAllPermissionsQueryHandler: IRequestHandler<GetAllPermissionsQuery, List<Permissions>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Permissions>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissionsList = await _unitOfWork.PermissionsRepository.GetAllPermissions();

            return permissionsList.ToList();
        }
    }
}
