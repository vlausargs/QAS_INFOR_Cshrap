//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLFaCosts.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLFaCosts : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLFaCostsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}