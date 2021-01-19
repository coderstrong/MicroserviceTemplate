namespace ProjectName.ModuleName.Domain.SeedWork
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ProjectName.ModuleName.Domain.Interfaces;

    public abstract class Entity :
        ICreatedAtProperty,
        IModifiedAtProperty,
        ICreatedByProperty,
        IModifiedByProperty,
        IDeletedAtProperty,
        IDeletedByProperty,
        IStateProperty,
        IStatusProperty
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        [MaxLength(50)]
        public string DeletedBy { get; set; }

        public int Status { get; set; }
        public int State { get; set; }

        public Entity()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
