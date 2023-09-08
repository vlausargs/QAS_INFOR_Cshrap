//PROJECT NAME: Data
//CLASS NAME: IApsForecastOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IApsForecastOrderId
    {
        string ApsForecastOrderIdFn(
            string PItem,
            string PWhse,
            string PCustNum,
            DateTime? PDate);

        int? ApsForecastOrderIdSp();
    }
}

