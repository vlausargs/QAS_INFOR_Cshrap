//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLCurrencyCodes.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLCurrencyCodes : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLCurrencyCodesSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}