using Microsoft.EntityFrameworkCore;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Data;
using N5.Authentication.Backend.Domain;
using N5.Authentication.Backend.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Infrastructure.Repositories
{
    public class PermissionTypesRepository : RepositoryBase<PermissionTypes>, IPermissionTypesRepository
    {
        public PermissionTypesRepository(PermissionDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PermissionTypes>> GetAllPermissionTypes()
        {
            return await _context.PermissionTypes.ToListAsync();
        }

        public async Task<PermissionTypes> GetPermissionTypeById(int id)
        {
            return await _context.PermissionTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
         
        
    }
}
