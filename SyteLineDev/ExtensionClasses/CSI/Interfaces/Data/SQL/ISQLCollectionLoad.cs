using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ISQLCollectionLoad
    {
        (int? Severity, ICollectionLoadResponse Data) ExecuteDynamicQuery(string expression, string paramDefinition, params object[] paramValues);
    }
}
