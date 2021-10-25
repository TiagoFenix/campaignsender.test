using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Data
{
    public class BaseRepository
    {
        protected readonly IConnectionFactory   connection;
        protected readonly string               tableName;
        protected readonly string               fieldId;

        public BaseRepository(IConnectionFactory connection, string tableName, string fieldId)
        {
            this.connection = connection;
            this.tableName = tableName;
            this.fieldId = fieldId;
        }

        protected virtual string GetTableColumns()
        { 
            return string.Empty;
        }

        protected virtual string GetTableValues()
        {
            return string.Empty;
        }

        protected virtual string GetTableUpdateValues()
        {
            return string.Empty;
        }

        public string GetSelectSqlStr() => $"SELECT * FROM {tableName} ";
        public string GetInsertSqlStr() => $"INSERT INTO {tableName} ({GetTableColumns()}) VALUES ({GetTableValues()}); SELECT CAST(SCOPE_IDENTITY() as int)";
        public string GetUpdateSqlStr() => $"UPDATE {tableName} SET {GetTableUpdateValues()} WHERE {fieldId} = @{fieldId};";
        public string GetDeleteSqlStr() => $"DELETE FROM {tableName} WHERE {fieldId} = @{fieldId};";
    }
}
