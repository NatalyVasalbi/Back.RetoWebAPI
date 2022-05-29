using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Application.Exceptions;
using N5.Authentication.Backend.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand
{
    public class UpdatePermissionsCommandHandler : IRequestHandler<UpdatePermissionsCommand,int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePermissionsCommandHandler> _logger;
        public UpdatePermissionsCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,  ILogger<UpdatePermissionsCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdatePermissionsCommand request, CancellationToken cancellationToken)
        {
            var permissionToUpdate = await _unitOfWork.PermissionsRepository.GetByIdAsync(request.Id);

            if (permissionToUpdate == null)
            {
                _logger.LogError($"No se encontro el streamer id {request.Id}");
                throw new NotFoundException(nameof(Permissions), request.Id);
            }

            _mapper.Map(request, permissionToUpdate, typeof(UpdatePermissionsCommand), typeof(Permissions));

            _unitOfWork.PermissionsRepository.UpdateEntity(permissionToUpdate);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el registro de Permiso");
            }

            _logger.LogInformation($"La operacion fue exitosa actualizando el Permiso {permissionToUpdate.Id}");

            return permissionToUpdate.Id;
        }
    }    
}
