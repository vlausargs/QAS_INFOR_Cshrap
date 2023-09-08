using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSI.Data
{
    public interface IDynamicMethodCallUtil
    {
        object Invoke(string spName, List<object> parmList, object parent);

    }
}
