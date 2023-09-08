//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLInvItemAlls.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLInvItemAlls : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLInvItemAllsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}