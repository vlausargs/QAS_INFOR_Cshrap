using CSI.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.Data
{
    class TupleBuilder
    {
        readonly ITupleUtil tupleUtil;
        public TupleBuilder(ITupleUtil tupleUtil)
        {
            this.tupleUtil = tupleUtil;
        }
        public object CreateValueTuple(IList<object> values, IEnumerable<Type> returnTupleFieldTypes)
        {
            return this.tupleUtil.CreateValueTuple(values, returnTupleFieldTypes);
        }
    }
}
