using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.SQL
{
    public class SQLParameterProvider : IParameterProvider
    {
        public IDataParameter CreateParameter(string parameterName, object value)
        {
            value = value ?? DBNull.Value;
            return new SqlParameter(parameterName, value);
        }
    }
}
