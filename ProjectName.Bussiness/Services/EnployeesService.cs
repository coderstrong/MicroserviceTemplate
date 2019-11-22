using ProjectName.Infrastructure.Database;

namespace ProjectName.Bussiness.Services
{
    public class EnployeesService : BaseServiceGeneric<ProfileContext, Employee>, IEnployeesService
    {
        public EnployeesService(IUnitOfWorkGeneric<ProfileContext> unitOfWork)
            : base(unitOfWork)
        {
        }
    }

    public interface IEnployeesService : IBaseServiceGeneric<ProfileContext, Employee>
    {
    }
}