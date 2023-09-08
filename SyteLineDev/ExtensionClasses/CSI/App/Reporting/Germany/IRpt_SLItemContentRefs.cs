//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLItemContentRefs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLItemContentRefs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLItemContentRefsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}