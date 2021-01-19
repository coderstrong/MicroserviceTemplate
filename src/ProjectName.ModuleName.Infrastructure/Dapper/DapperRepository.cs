using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace ProjectName.ModuleName.Infrastructure.Dapper
{
    public partial class DapperRepository : IDapperRepository
    {
        private readonly static Dictionary<DatabaseType, Type> DictionaryDatabaseType = new Dictionary<DatabaseType, Type>
        {
            [DatabaseType.SqlServer] = typeof(SqlConnection),
            [DatabaseType.MySQL] = typeof(MySqlConnection),
            [DatabaseType.SQLite] = typeof(SqliteConnection)
        };

        private readonly DapperOptions _options;
        public IDbConnection Connection { get; private set; }
        public string Schema { get; private set; }

        public DapperRepository(IOptions<DapperOptions> optionsAccessor)
        {
            if (optionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }

            _options = optionsAccessor.Value;
            Type type = DictionaryDatabaseType[_options.DatabaseType];
            Connection = Activator.CreateInstance(type) as IDbConnection;
            Connection.ConnectionString = _options.ConnectionString;
            Schema = _options.Schema;
        }
    }
}
