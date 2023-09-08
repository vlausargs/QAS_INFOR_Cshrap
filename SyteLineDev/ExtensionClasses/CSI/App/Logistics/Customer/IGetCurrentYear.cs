//PROJECT NAME: Logistics
//CLASS NAME: IGetCurrentYear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IGetCurrentYear
    {
        (int? ReturnCode, int? CurYear) GetCurrentYearSP(int? CurYear);
    }
}

