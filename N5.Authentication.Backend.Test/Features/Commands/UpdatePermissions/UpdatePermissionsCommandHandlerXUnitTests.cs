using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand;
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

namespace N5.Authentication.Backend.Test.Features.Commands.UpdatePermissions
{
   
    public class UpdatePermissionsCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdatePermissionsCommandHandler>> _logger;

        public UpdatePermissionsCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            _logger = new Mock<ILogger<UpdatePermissionsCommandHandler>>();


            MockPermissionsRepository.AddDataPermisionsRepository(_unitOfWork.Object.PermissionDbContext);
        }

        [Fact]
        public async Task UpdatePermissionsCommand_ReturnsOk()
        {
            int expected = 0;
            var permissionInput = new UpdatePermissionsCommand
            {
                Id=10,
                EmployeeName = "Nataly",
                EmployeeLastName = "Vasquez",
                PermissionDate = DateTime.Now,
                PermissionTypeId = 1

            };

            var handler = new UpdatePermissionsCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(permissionInput, CancellationToken.None);
            Assert.NotEqual(result, expected);

        }
               
    }
}
