using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectName.Infrastructure.Database
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public long? Id { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [MaxLength(20)]
        public string UpdatedBy { get; set; }

        [MaxLength(20)]
        public string DeletedBy { get; set; }
    }
}