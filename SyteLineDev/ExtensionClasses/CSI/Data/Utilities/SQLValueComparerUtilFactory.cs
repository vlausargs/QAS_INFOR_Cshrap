using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
   public class SQLValueComparerUtilFactory : ISQLValueComparerUtilFactory
    {
        public ISQLValueComparerUtil Create()
        {
            IDataTypeUtil dataTypeUtil = new DataTypeUtil();
            IDateTimeUtil dateTimeUtil = new DateTimeUtil(dataTypeUtil);
            IEvaluateDatatypesUtil evaluateDatatypesUtil = new EvaluateDatatypesUtil(dateTimeUtil, dataTypeUtil);

            return new SQLValueComparerUtil(evaluateDatatypesUtil);
        }
    }
}
