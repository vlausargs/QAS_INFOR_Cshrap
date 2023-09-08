//PROJECT NAME: Data
//CLASS NAME: IMinAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IMinAmt
    {
        decimal? MinAmtFn(
            decimal? Amt1,
            decimal? Amt2);
    }
}

