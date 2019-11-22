using System.ComponentModel.DataAnnotations;

namespace ProjectName.Infrastructure.Database
{
    public class Employee : BaseModel
    {
        [MaxLength(20)]
        public string Code { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string MiddleName { get; set; }

        [MaxLength(60)]
        public string FullName { get; set; }

        public int? TitleId { get; set; }

        [MaxLength(60)]
        public string Title { get; set; }
    }
}