using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Data
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
