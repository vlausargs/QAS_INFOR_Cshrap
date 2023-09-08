//PROJECT NAME: Production
//CLASS NAME: IGetMinStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface IGetMinStartDate
    {
        (int? ReturnCode, DateTime? StartDate) GetMinStartDateSp(DateTime? StartDate);
    }
}

