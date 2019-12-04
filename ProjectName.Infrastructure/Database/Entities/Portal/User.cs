using System.ComponentModel.DataAnnotations;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Infrastructure.Database
{
    public class User : Entity
    {
        [MaxLength(20)]
        public string Code { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }
    }
}
