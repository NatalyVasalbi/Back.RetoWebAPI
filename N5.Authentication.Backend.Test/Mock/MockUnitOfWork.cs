using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Persistance;
using N5.Authentication.Backend.Infrastructure.Repositories;
using System;
using System.Linq;

namespace N5.Authentication.Backend.Test.Mock
{

    public static class MockUnitOfWork
    {


        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<PermissionDbContext>()
                .UseInMemoryDatabase(databaseName: $"PermissionDbContext-{dbContextId}")
                .Options;

            var streamerDbContextFake = new PermissionDbContext(options);
            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);


            return mockUnitOfWork;
        }
    }
}
