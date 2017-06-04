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
        SqlConnection _connection = new SqlConnection("user id=User;server=DESKTOP-E33041D\\SQLEXPRESS;Trusted_Connection=yes;database=WoDDatabase;connection timeout=15");

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