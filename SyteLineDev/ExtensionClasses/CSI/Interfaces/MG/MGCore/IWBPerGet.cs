//PROJECT NAME: MG.MGCore
//CLASS NAME: IWBPerGet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IWBPerGet
    {
        (int? ReturnCode, DateTime? PerStart,
        DateTime? PerEnd,
        int? WorkDays,
        int? TotDays,
        string Infobar) WBPerGetSp(DateTime? AsOfDate,
        DateTime? PerStart,
        DateTime? PerEnd,
        int? WorkDays,
        int? TotDays,
        string Infobar);
    }
}

