using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public class TupleUtilFactory
    {
        public ITupleUtil Create() => new TupleUtil();
    }
}
