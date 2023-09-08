//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLInvHdrs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLInvHdrs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLInvHdrsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}