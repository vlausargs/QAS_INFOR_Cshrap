//PROJECT NAME: Data
//CLASS NAME: IMinQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IMinQty
    {
        decimal? MinQtyFn(
            decimal? Qty1,
            decimal? Qty2);

        decimal? MinQtySp(
            decimal? Qty1,
            decimal? Qty2);
    }
}

