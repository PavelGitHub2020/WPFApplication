using System.Data;

namespace TestTask.DAL
{
    public interface IBaseDAO
    {
        IDbConnection GetConnection();
        void ReleaseConnection(IDbConnection connection);
    }
}
