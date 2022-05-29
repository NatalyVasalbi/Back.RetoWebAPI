using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N5.Authentication.Backend.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(int id);
                   
         void AddEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);
         
    }
}
