using System.Data;

namespace ProjectName.ModuleName.Infrastructure.Dapper
{
    public partial interface IDapperRepository
    {
        public IDbConnection Connection { get; }
        public string Schema { get; }
    }
}
