using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Application.Exceptions;
using N5.Authentication.Backend.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.DeletePermissionsCommand
{
    public class DeletePermissionsCommandHandler : IRequestHandler<DeletePermissionsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePermissionsCommandHandler> _logger;

        public DeletePermissionsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeletePermissionsCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeletePermissionsCommand request, CancellationToken cancellationToken)
        {
            var PermissionsToDelete = await _unitOfWork.PermissionsRepository.GetByIdAsync(request.Id);
            if (PermissionsToDelete == null)
            {
                _logger.LogError($"{request.Id} Permissions no existe en el sistema");
                throw new NotFoundException(nameof(Permissions), request.Id);
            }

            _unitOfWork.PermissionsRepository.DeleteEntity(PermissionsToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} Permissions fue eliminado con exito");

            return Unit.Value;
        }
    }
}
