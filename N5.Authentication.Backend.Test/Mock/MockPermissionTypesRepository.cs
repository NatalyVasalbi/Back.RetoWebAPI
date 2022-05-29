using AutoFixture;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Persistance;
using System.Linq;

namespace N5.Authentication.Backend.Test.Mock
{

    public static class MockPermissionTypesRepository
    {
        public static void AddDataPermissionTypesRepository(PermissionDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var permissionTypes = fixture.CreateMany<PermissionTypes>().ToList();

            permissionTypes.Add(fixture.Build<PermissionTypes>()
               .With(tr => tr.Id, 10)
               .Create()
           );

            streamerDbContextFake.PermissionTypes!.AddRange(permissionTypes);
            streamerDbContextFake.SaveChanges();

        }
    }
}
