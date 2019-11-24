using Microsoft.Extensions.Logging;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Bussiness.Services
{
    public class EnployeesService : BaseServiceGeneric<ProfileContext, Employee>, IEnployeesService
    {
        public EnployeesService(IUnitOfWorkGeneric<ProfileContext> unitOfWork, ILogger<EnployeesService> logger)
            : base(unitOfWork, logger)
        {
        }
    }

    public interface IEnployeesService : IBaseServiceGeneric<ProfileContext, Employee>
    {
    }
}