using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoDWebBuilder.DAL
{
    public interface IDatabaseConnector : IDisposable
    {
        IDbCommand CreateCommand();
        void ExecuteNonQuery(IDbCommand command);
        IDataReader ExecuteReader(IDbCommand command);
    }
}
