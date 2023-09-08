//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLInvItemSurcharges.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLInvItemSurcharges : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLInvItemSurchargesSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}