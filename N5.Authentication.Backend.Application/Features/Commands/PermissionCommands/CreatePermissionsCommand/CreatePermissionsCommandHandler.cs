using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand
{
    public class CreatePermissionsCommandHandler : IRequestHandler<CreatePermissionsCommand,int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePermissionsCommandHandler> _logger;
        public CreatePermissionsCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,  ILogger<CreatePermissionsCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreatePermissionsCommand request, CancellationToken cancellationToken)
        {
            var permissionEntity = _mapper.Map<Permissions>(request);

            _unitOfWork.PermissionsRepository.AddEntity(permissionEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el registro de Permiso");
            }

            _logger.LogInformation($"Permiso {permissionEntity.Id} fue creado existosamente");


            return permissionEntity.Id;
        }
    }    
}
