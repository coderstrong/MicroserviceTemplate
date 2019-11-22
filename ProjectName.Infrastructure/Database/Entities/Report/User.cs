using System.ComponentModel.DataAnnotations;

namespace ProjectName.Infrastructure.Database
{
    public class User : BaseModel
    {
        [MaxLength(20)]
        public string Code { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }
    }
}