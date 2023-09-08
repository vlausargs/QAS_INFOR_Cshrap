//PROJECT NAME: Data
//CLASS NAME: IMaxAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IMaxAmt
    {
        decimal? MaxAmtFn(
            decimal? Amt1,
            decimal? Amt2);
    }
}

