using System.Data;

namespace Fenix.ESender.Data
{
    public interface IConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
