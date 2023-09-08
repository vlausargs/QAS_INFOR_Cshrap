//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLPrbanks.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLPrbanks : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLPrbanksSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}