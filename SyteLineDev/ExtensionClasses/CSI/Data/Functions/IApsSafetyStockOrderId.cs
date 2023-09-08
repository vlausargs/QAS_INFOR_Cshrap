//PROJECT NAME: Data
//CLASS NAME: IApsSafetyStockOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IApsSafetyStockOrderId
    {
        string ApsSafetyStockOrderIdFn(
            string PItem,
            string PWhse);
    }
}

