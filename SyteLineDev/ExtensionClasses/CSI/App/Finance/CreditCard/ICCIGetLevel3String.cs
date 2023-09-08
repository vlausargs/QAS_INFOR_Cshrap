//PROJECT NAME: Finance
//CLASS NAME: ICCIGetLevel3String.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
    public interface ICCIGetLevel3String
    {
        (int? ReturnCode, string Level3,
        string Infobar) CCIGetLevel3StringSp(string CardSystem,
        string InvNum,
        decimal? TotalAmt,
        string CustRef,
        string Level3,
        string Infobar);
    }
}