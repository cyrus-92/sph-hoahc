namespace SPH.Entity.Abstractions.Audits
{
    public interface IFullAuditEntity : ICreationAuditEntity, IModificationAuditEntity, IDeletionAuditEntity
    {
    }
}
