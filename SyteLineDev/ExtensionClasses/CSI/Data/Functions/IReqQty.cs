//PROJECT NAME: Data
//CLASS NAME: IReqQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IReqQty
    {
        decimal? ReqQtyFn(
            decimal? QtyReleased,
            string Units,
            decimal? MatlQty,
            int? Scrap,
            decimal? ScrapFact);
    }
}

