//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLBankHdrs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLBankHdrs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLBankHdrsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}