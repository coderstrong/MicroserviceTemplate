using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectName.Infrastructure.Database
{
    public class Report : BaseModel
    {
        public int? EmployeeId { get; set; }
        public int? ContractTypeId { get; set; }

        [MaxLength(255)]
        public string ContractType { get; set; }

        [MaxLength(20)]
        public string ContractTypeCode { get; set; }

        public int? EmployeerId { get; set; }

        [MaxLength(255)]
        public string EmployeerName { get; set; }

        public float? Salary { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? SignDate { get; set; }

        [MaxLength(20)]
        public string ContractNo { get; set; }

        public int? SignId { get; set; }

        [MaxLength(20)]
        public string SignCode { get; set; }

        [MaxLength(255)]
        public string SignName { get; set; }

        [MaxLength(255)]
        public string SignOrg { get; set; }

        [MaxLength(255)]
        public string SignPos { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [MaxLength(512)]
        public string WorkingTime { get; set; }

        [MaxLength(512)]
        public string Note { get; set; }

        public int? Index { get; set; }
    }
}