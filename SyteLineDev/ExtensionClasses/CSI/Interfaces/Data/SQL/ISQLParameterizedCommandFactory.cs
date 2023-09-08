using System.Collections.Generic;
using System.Data;

namespace CSI.Data.SQL
{
    public interface ISQLParameterizedCommandFactory
    {
        IParameterizedCommand Create(string statement, IEnumerable<IDataParameter> parameters = null);
    }
}