//PROJECT NAME: Data.Functions
//CLASS NAME: ConvertSecondsToTimeAsStr.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;

namespace CSI.Data.Functions
{
    public class ConvertSecondsToTimeAsStr : IConvertSecondsToTimeAsStr
    {
        readonly IApplicationDB appDB;

        readonly IConvertSecondsToTime iConvertSecondsToTime;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IStringUtil stringUtil;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public ConvertSecondsToTimeAsStr(IApplicationDB appDB,
            IConvertSecondsToTime iConvertSecondsToTime,
            IDateTimeUtil dateTimeUtil,
            IStringUtil stringUtil,
            IMathUtil mathUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.iConvertSecondsToTime = iConvertSecondsToTime;
            this.dateTimeUtil = dateTimeUtil;
            this.stringUtil = stringUtil;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
        }

        public string ConvertSecondsToTimeAsStrFn(
            int? SecondsPastMidnight)
        {
            string PostTime = null;
            DateTime? convertedDateTime = null;
            string convertedDateTimeStr = string.Empty;
            int? secondsPastMidnightAbs = mathUtil.Abs<int?>(SecondsPastMidnight);
            
            if(sQLUtil.SQLLessThan(SecondsPastMidnight, 0) == true)
            {
                convertedDateTime = this.iConvertSecondsToTime.ConvertSecondsToTimeFn(secondsPastMidnightAbs);
            }
            else
            {
                convertedDateTime = this.iConvertSecondsToTime.ConvertSecondsToTimeFn(SecondsPastMidnight);
            }
            this.iConvertSecondsToTime.ConvertSecondsToTimeFn(secondsPastMidnightAbs);
            convertedDateTimeStr = dateTimeUtil.ConvertToString(convertedDateTime, "HH:mm:ss");

            PostTime = sQLUtil.SQLLessThan(SecondsPastMidnight, 0) == true ? stringUtil.Concat("-", convertedDateTimeStr) : convertedDateTimeStr;
            
            return PostTime;
        }
    }
}
