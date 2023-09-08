using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public class ConvertToUtilFactory : IConvertToUtilFactory
    {
        public IConvertToUtil Create()
        {
            IDataTypeUtil dataTypeUtil = new DataTypeUtilFactory().Create();
            IDateTimeUtil dateTimeUtil = new DateTimeUtil(dataTypeUtil);

            return new ConvertToUtil(dateTimeUtil);
        }
    }
}
