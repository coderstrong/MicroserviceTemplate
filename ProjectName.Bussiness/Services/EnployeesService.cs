using Microsoft.Extensions.Logging;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Bussiness.Services
{
    public class EnployeesService:  IEnployeesService
    {
        private readonly IRepositoryGeneric<ProfileContext, Employee> _employee;
        public EnployeesService(IUnitOfWorkGeneric<ProfileContext> unitOfWork, ILogger<EnployeesService> logger, IRepositoryGeneric<ProfileContext, Employee> employee)
        {
            _employee = employee;
        }
    }

    public interface IEnployeesService
    {
    }
}