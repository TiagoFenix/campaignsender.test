using System.Data;

namespace Fenix.ESender.API.Data
{
    public interface IConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
