using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public class DataTypeUtilFactory: IDataTypeUtilFactory
    {
        public IDataTypeUtil Create()
        {
            return new DataTypeUtil();
        }
    }
}
