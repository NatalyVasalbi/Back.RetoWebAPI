using N5.Authentication.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Contracts.Persistence
{
    public interface IPermissionsRepository : IAsyncRepository<Permissions>
    {
        Task<IEnumerable<Permissions>> GetPermissionsByUserName(string userName);
        Task<IEnumerable<Permissions>> GetAllPermissions();
    }
}
