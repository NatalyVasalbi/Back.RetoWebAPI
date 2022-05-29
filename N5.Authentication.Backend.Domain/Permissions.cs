using N5.Authentication.Backend.Domain.Commons;
using System;

namespace N5.Authentication.Backend.Domain
{
    public class Permissions: BaseDomainModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int? PermissionTypeId { get; set; }
        public virtual PermissionTypes PermissionType { get; set; }
        public DateTime? PermissionDate { get; set; }
    }
}
