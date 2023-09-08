//PROJECT NAME: Data
//CLASS NAME: IApsOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IApsOrderId
    {
        string ApsOrderIdFn(
            string POrder,
            int? PLine,
            int? PRelease);

        int? ApsOrderIdSp();
    }
}

