using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand;
using N5.Authentication.Backend.Application.Mappings;
using N5.Authentication.Backend.Infrastructure.Repositories;
using N5.Authentication.Backend.Test.Mock;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace N5.Authentication.Backend.Test.Features.Commands.CreatePermissions
{
    public class CreatePermissionsCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreatePermissionsCommandHandler>> _logger;

        public CreatePermissionsCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            _logger = new Mock<ILogger<CreatePermissionsCommandHandler>>();


            MockPermissionsRepository.AddDataPermisionsRepository(_unitOfWork.Object.PermissionDbContext);
        }

        [Fact]
        public async Task CreatePermissionsCommand_ReturnsOk()
        {
            int expected = 0;
            var permissionInput = new CreatePermissionsCommand
            {                
                EmployeeName = "Nataly",
                EmployeeLastName = "Vasquez",
                PermissionDate = DateTime.Now,
                PermissionTypeId= 1

            };

            var handler = new CreatePermissionsCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(permissionInput, CancellationToken.None);            
            Assert.NotEqual(result, expected);
            
        }

    }
}
