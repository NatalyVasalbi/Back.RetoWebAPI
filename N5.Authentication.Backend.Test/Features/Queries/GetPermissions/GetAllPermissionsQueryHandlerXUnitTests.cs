using AutoMapper;
using Moq;
using N5.Authentication.Backend.Application.Features.Queries.PermissionQueries;
using N5.Authentication.Backend.Application.Mappings;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Repositories;
using N5.Authentication.Backend.Test.Mock;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace N5.Authentication.Backend.Test.Features.Queries.GetPermissions
{
    public class GetAllPermissionsQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllPermissionsQueryHandlerXUnitTests()
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

            var handler = new GetAllPermissionsQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetAllPermissionsQuery();

            var actual = await handler.Handle(request, CancellationToken.None);

            Assert.IsType(expected, actual);

        }
    
    }
}
