using SPH.Entity.Abstractions.Audits;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPH.Entity.Users
{
    public class User : IFullAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string PasswordHashed { get; set; }

        [Required]
        [StringLength(32)]
        public string PasswordSalt { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }

        #region [AUDIT PROPERTIES]
        public bool Deleted { get; set; }

        public DateTime CreatedTime { get; set; }

        public Guid? CreatorId { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public Guid? ModifierId { get; set; }
        #endregion [AUDIT PROPERTIES]
        
        #region [REFERENCE PROPERTIES]
        [ForeignKey(nameof(CreatorId))]
        public virtual User Creator { get; set; }

        [ForeignKey(nameof(ModifierId))]
        public virtual User Modifier { get; set; }
        #endregion
    }
}
