using System.Data;

namespace ProjectName.Infrastructure.Dapper
{
    public partial interface IDapperRepository
    {
        public IDbConnection Connection { get; }
        public string Schema { get; }
    }
}
