//PROJECT NAME: Finance
//CLASS NAME: ICalcBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface ICalcBal
    {
        (int? ReturnCode, decimal? Balance,
        string Infobar) CalcBalSp(string TMethod,
        int? TUse,
        DateTime? SDate,
        DateTime? EDate,
        string PHierarchy,
        string PAcct,
        string PAcctUnit1,
        string PAcctUnit2,
        string PAcctUnit3,
        string PAcctUnit4,
        string PSort,
        string PType,
        int? PIncome,
        string PBalType,
        string PCurrCode,
        int? PSortMethod,
        decimal? Balance,
        string Infobar,
        string pSite = null,
        DateTime? PeriodDateForStart = null,
        DateTime? PeriodDateForEnd = null,
        string CallFrom = null,
        DateTime? Today = null,
        DateTime? FirstPeriodPerStart = null,
        DateTime? LastPeriodPerEnd = null);
    }
}

