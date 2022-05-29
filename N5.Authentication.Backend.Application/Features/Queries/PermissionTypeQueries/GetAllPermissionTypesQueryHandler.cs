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
    public class GetAllPermissionTypesQueryHandler : IRequestHandler<GetAllPermissionTypesQuery, List<PermissionTypes>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPermissionTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PermissionTypes>> Handle(GetAllPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            var permissionsList = await _unitOfWork.PermissionTypesRepository.GetAllPermissionTypes();

            return permissionsList.ToList();
        }
    }
   
}
