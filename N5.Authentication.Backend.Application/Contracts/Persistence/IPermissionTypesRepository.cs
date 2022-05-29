using N5.Authentication.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Contracts.Persistence
{
    public interface IPermissionTypesRepository : IAsyncRepository<PermissionTypes>
    {
        Task<IEnumerable<PermissionTypes>> GetAllPermissionTypes();
        Task<PermissionTypes> GetPermissionTypeById(int id);
    }
}
