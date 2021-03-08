using System;

namespace SPH.Entity.Abstractions.Audits
{
    public interface ICreationAuditEntity
    {
        DateTime CreatedTime { get; set; }

        Guid? CreatorId { get; set; }
    }
}
