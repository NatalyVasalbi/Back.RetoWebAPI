using AutoMapper;
using Moq;
using N5.Authentication.Backend.Application.Features.Queries.PermissionQueries;
using N5.Authentication.Backend.Application.Mappings;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Repositories;
using N5.Authentication.Backend.Test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace N5.Authentication.Backend.Test.Features.Queries.GetPermissions
{
    public class GetByPermissionsByUserNameQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetByPermissionsByUserNameQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            MockPermissionsRepository.AddDataPermisionsRepository(_unitOfWork.Object.PermissionDbContext);
        }

        [Fact]
        public async Task GetAllPermissions_ReturnsOk()
        {
            var expected = typeof(List<Permissions>);

            var handler = new GetPermissionsQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetPermissionsQuery("Nataly");

            var actual = await handler.Handle(request, CancellationToken.None);

            Assert.IsType(expected, actual);

        }
    
    }
}
