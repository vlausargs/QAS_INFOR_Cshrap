using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public interface IParameterizedCommand
    {
        string Statement { get; }
        IEnumerable<IDataParameter> Parameters { get; }
    }
}
