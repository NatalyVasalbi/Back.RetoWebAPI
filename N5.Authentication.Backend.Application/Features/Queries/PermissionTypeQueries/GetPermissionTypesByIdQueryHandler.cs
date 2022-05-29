using AutoMapper;
using MediatR;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Features.Queries.PermissionQueries
{
    public class GetPermissionTypesByIdQueryHandler : IRequestHandler<GetPermissionTypesByIdQuery, PermissionTypes>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPermissionTypesByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PermissionTypes> Handle(GetPermissionTypesByIdQuery request, CancellationToken cancellationToken)
        {
            var permissionsList = await _unitOfWork.PermissionTypesRepository.GetPermissionTypeById(request.permissionTypeId);

            return permissionsList;
        }
    }
   
}
