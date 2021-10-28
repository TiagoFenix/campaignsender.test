using System.Data;
using System.Data.SqlClient;

namespace Fenix.ESender.Data
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public string ConnectionString => this.connectionString;
    }
}
