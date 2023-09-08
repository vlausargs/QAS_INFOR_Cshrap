//PROJECT NAME: Data.Functions
//CLASS NAME: IConvertSecondsToTime.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IConvertSecondsToTime
    {
        DateTime? ConvertSecondsToTimeFn(
            int? SecondsPastMidnight);
    }
}