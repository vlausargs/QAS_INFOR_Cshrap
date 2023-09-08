//PROJECT NAME: Finance
//CLASS NAME: IValidatePeriodClosed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface IValidatePeriodClosed
    {
        (int? ReturnCode, string Infobar) ValidatePeriodClosedSp(
            int? FiscalYearClosed,
            int? Closed,
            string Infobar);
    }
}

