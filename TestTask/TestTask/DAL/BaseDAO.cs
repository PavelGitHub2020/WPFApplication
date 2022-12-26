using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestTask.DAL
{
    public class BaseDAO : IBaseDAO
    {
        SqlConnectionStringBuilder stringBuilder;

        SqlConnection connection;
        public IDbConnection GetConnection()
        {
            stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = @"DESKTOP-1OA4FC7\MYSQLSERVER";
            stringBuilder.InitialCatalog = "Technical_Specification";
            stringBuilder.Encrypt = true;
            stringBuilder.TrustServerCertificate = true;
            stringBuilder.ConnectTimeout = 30;
            stringBuilder.AsynchronousProcessing = true;
            stringBuilder.MultipleActiveResultSets = true;
            stringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(stringBuilder.ToString());

            connection.Open();

            return connection;
        }

        public void ReleaseConnection(IDbConnection connection)
        {
            connection.Close();
        }
    }
}
