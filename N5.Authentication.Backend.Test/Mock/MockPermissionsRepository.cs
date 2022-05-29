using AutoFixture;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Persistance;
using System.Linq;

namespace N5.Authentication.Backend.Test.Mock
{

    public static class MockPermissionsRepository
    {
        public static void AddDataPermisionsRepository(PermissionDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var permissions = fixture.CreateMany<Permissions>().ToList();

            permissions.Add(fixture.Build<Permissions>()
               .With(tr => tr.Id, 10)
               .Without(tr => tr.PermissionType)
               .Create()
           );

            streamerDbContextFake.Permissions!.AddRange(permissions);
            streamerDbContextFake.SaveChanges();

        }
    }
}
