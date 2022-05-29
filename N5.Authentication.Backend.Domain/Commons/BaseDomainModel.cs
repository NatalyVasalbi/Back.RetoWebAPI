using System;

namespace N5.Authentication.Backend.Domain.Commons
{
    public abstract class BaseDomainModel
    {
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
