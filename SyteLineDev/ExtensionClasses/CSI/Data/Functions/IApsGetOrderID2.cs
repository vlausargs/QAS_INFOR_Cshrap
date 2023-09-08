//PROJECT NAME: Data
//CLASS NAME: IApsGetOrderID2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IApsGetOrderID2
    {
        string ApsGetOrderID2Fn(
            string DemandType,
            string DemandRef);
    }
}

