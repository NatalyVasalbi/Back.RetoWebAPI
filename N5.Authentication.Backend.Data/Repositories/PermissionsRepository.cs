using Microsoft.EntityFrameworkCore;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Infrastructure.Repositories
{
    public class PermissionsRepository : RepositoryBase<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(PermissionDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Permissions>> GetAllPermissions()
        {
            return await _context.Permissions.Include(x => x.PermissionType).ToListAsync();
        }

        public async Task<IEnumerable<Permissions>> GetPermissionsByUserName(string userName)
        {
            return await _context.Permissions.Where(x => x.EmployeeName.Trim().ToUpper().Contains(userName.Trim().ToUpper())).Include(x => x.PermissionType).ToListAsync();
        }

    }
}
