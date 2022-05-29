using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.DeletePermissionsCommand;
using N5.Authentication.Backend.Application.Mappings;
using N5.Authentication.Backend.Infrastructure.Repositories;
using N5.Authentication.Backend.Test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace N5.Authentication.Backend.Test.Features.Commands
{   
    public class DeletePermissionCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeletePermissionsCommandHandler>> _logger;

        public DeletePermissionCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<DeletePermissionsCommandHandler>>();

            MockPermissionsRepository.AddDataPermisionsRepository(_unitOfWork.Object.PermissionDbContext);
        }

        [Fact]
        public async Task DeletePermissionCommand_InputStreamer_ReturnsUnit()
        {
            var expected = Unit.Value;
            var streamerInput = new DeletePermissionsCommand
            {
                Id = 10,
            };

            var handler = new DeletePermissionsCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var actual = await handler.Handle(streamerInput, CancellationToken.None);
            Assert.Equal(actual, expected);
           
        }
    }
}
