//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLLedgers.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLLedgers : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLLedgersSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}