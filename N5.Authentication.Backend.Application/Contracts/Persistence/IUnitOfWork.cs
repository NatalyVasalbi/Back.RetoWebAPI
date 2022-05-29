using N5.Authentication.Backend.Domain.Commons;
using System;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionsRepository PermissionsRepository { get; }
        IPermissionTypesRepository PermissionTypesRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
