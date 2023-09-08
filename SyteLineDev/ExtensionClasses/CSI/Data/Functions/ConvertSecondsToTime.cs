//PROJECT NAME: Data.Functions
//CLASS NAME: ConvertSecondsToTime.cs

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
    public class ConvertSecondsToTime : IConvertSecondsToTime
    {
        readonly IApplicationDB appDB;

        readonly IConvertToUtil convertToUtil;
        readonly IStringUtil stringUtil;
        readonly IMathUtil mathUtil;

        public ConvertSecondsToTime(IApplicationDB appDB,
            IConvertToUtil convertToUtil,
            IStringUtil stringUtil,
            IMathUtil mathUtil)
        {
            this.appDB = appDB;
            this.convertToUtil = convertToUtil;
            this.stringUtil = stringUtil;
            this.mathUtil = mathUtil;
        }

        public DateTime? ConvertSecondsToTimeFn(
            int? SecondsPastMidnight)
        {
            DateTime? PostTime = null;
            string THours = null;
            string TMinutes = null;
            string TSeconds = null;
            string VarcharTime = null;
            //BEGIN
            THours = Convert.ToString(mathUtil.Round<decimal?>(SecondsPastMidnight / 3600, 0));
            TMinutes = Convert.ToString(mathUtil.Round<decimal?>(((SecondsPastMidnight % 3600) / 60), 0));
            TSeconds = Convert.ToString(mathUtil.Round<decimal?>(((SecondsPastMidnight % 3600) % 60), 0));
            VarcharTime = stringUtil.Concat(THours, ":", TMinutes, ":", TSeconds);
            PostTime = convertToUtil.ToDateTime(convertToUtil.ToDateTime(VarcharTime));
            return PostTime;
            //END
        }
    }
}
