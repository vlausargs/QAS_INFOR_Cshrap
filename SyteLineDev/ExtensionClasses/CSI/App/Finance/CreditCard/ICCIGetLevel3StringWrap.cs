//PROJECT NAME: Finance
//CLASS NAME: ICCIGetLevel3StringWrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
    public interface ICCIGetLevel3StringWrap
    {
            (int? ReturnCode,
            string Level3Data,
            string Infobar) 
        CCIGetLevel3StringWrapSp(
            string CardSystem,
            string InvNum,
            decimal? TotalAmt,
            string CustRef,
            string Level3Data,
            string Infobar);
    }
}

