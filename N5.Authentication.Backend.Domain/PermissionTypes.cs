using N5.Authentication.Backend.Domain.Commons;

namespace N5.Authentication.Backend.Domain
{
    public class PermissionTypes: BaseDomainModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
    }
}
