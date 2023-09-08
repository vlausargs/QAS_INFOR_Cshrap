using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ICommandExecutor
    {
        void ExecuteNonQuery(IDbCommand cmd);
        IDataReader ExecuteReader(IDbCommand cmd);
        T ExecuteScalar<T>(IDbCommand cmd);
    }
}
