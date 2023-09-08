using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL.UDDT
{
    class UDDTImplicitConversionException : Exception
    {
        public UDDTImplicitConversionException(string fromType, string toType) :
            base(string.Format("Specified cast from {0} to {1} is not valid. Value is Null",
            fromType, toType))
        {
        }
    }
}
