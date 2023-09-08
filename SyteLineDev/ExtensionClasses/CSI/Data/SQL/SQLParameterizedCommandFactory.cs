using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLParameterizedCommandFactory : ISQLParameterizedCommandFactory
    {
        public IParameterizedCommand Create(string statement, IEnumerable<IDataParameter> parameters = null)
        {
            return new SQLParameterizedCommand(statement, parameters);
        }
    }
}
