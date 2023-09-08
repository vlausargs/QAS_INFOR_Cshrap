using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public interface ITupleUtil
    {
        object CreateValueTuple(IList<object> values, IEnumerable<Type> fieldTypes);
        bool IsTuple(object tuple);
        IList<object> EnumerateValueTuple(object valueTuple);
    }
}
