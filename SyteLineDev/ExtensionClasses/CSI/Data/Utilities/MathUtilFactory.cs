using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public class MathUtilFactory : IMathUtilFactory
    {
        public IMathUtil Create()
        {
            IDataTypeUtil dataTypeUtil = new DataTypeUtil();

            return new MathUtil(dataTypeUtil);
        }
    }
}
