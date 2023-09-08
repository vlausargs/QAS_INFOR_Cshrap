//PROJECT NAME: Data
//CLASS NAME: IGetSalesPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IGetSalesPeriod
    {
        string GetSalesPeriodFn(DateTime? TransDate);
    }
}
