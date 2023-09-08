using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public class DateTimeUtilFactory : IDateTimeUtilFactory
    {
        public IDateTimeUtil Create()
        {
            IDataTypeUtil dataTypeUtil = new DataTypeUtil();

            return new DateTimeUtil(dataTypeUtil);
        }
    }
}
