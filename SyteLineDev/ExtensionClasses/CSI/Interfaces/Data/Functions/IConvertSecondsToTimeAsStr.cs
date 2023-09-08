//PROJECT NAME: Data
//CLASS NAME: IConvertSecondsToTimeAsStr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IConvertSecondsToTimeAsStr
    {
        string ConvertSecondsToTimeAsStrFn(
            int? SecondsPastMidnight);
    }
}

