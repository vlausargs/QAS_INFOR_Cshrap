//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLPrtrxps.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLPrtrxps : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLPrtrxpsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}