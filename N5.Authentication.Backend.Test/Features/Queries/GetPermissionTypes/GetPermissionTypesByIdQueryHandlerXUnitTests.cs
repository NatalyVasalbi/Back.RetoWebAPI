using AutoMapper;
using Moq;
using N5.Authentication.Backend.Application.Features.Queries.PermissionQueries;
using N5.Authentication.Backend.Application.Mappings;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Repositories;
using N5.Authentication.Backend.Test.Mock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace N5.Authentication.Backend.Test.Features.Queries.GetPermissionTypes
{
    public class GetPermissionTypesByIdQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetPermissionTypesByIdQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            MockPermissionTypesRepository.AddDataPermissionTypesRepository(_unitOfWork.Object.PermissionDbContext);
        }

        [Fact]
        public async Task GetPermissionTypes_ReturnsOk()
        {
            var expected = typeof(PermissionTypes);

            var handler = new GetPermissionTypesByIdQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetPermissionTypesByIdQuery(10);

            var actual = await handler.Handle(request, CancellationToken.None);

            Assert.IsType(expected, actual);

        }
    }
    
}
