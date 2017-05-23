using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WoDWebBuilder.DAL.Connection
{
    public class SQLServerConnector : IDatabaseConnector
    {
        SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WoDWebBuilder-20170502010807.mdf;Initial Catalog=aspnet-WoDWebBuilder-20170502010807;Integrated Security=True");

        public IDbCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        public void ExecuteNonQuery(IDbCommand command)
        {
            Open();

            using (command)
                command.ExecuteNonQuery();

            Close();
        }

        public IDataReader ExecuteReader(IDbCommand command)
        {
            Open();

            using (command)
                return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        
        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}