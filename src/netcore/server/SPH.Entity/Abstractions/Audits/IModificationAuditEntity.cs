using System;

namespace SPH.Entity.Abstractions.Audits
{
    public interface IModificationAuditEntity
    {
        DateTime? ModifiedTime { get; set; }

        Guid? ModifierId { get; set; }
    }
}
