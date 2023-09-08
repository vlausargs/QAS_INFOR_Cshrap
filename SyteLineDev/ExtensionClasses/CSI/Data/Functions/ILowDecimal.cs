//PROJECT NAME: Data
//CLASS NAME: ILowDecimal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface ILowDecimal
    {
        decimal? LowDecimalFn(
            string DataType);
    }
}

