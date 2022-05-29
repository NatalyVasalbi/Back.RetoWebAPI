using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Domain.Commons;
using N5.Authentication.Backend.Infrastructure.Persistance;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly PermissionDbContext _context;

        private IPermissionsRepository _permissionRepository;
        private IPermissionTypesRepository _permissionTypesRepository;


        public IPermissionsRepository PermissionsRepository => _permissionRepository ??= new PermissionsRepository(_context);

        public IPermissionTypesRepository PermissionTypesRepository => _permissionTypesRepository ??= new PermissionTypesRepository(_context);

        public UnitOfWork(PermissionDbContext context)
        {
            _context = context;
        }

        public PermissionDbContext PermissionDbContext => _context;

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err"+ ex.Message);
            }

        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }


    }
}
