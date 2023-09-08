//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLInvStaxs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLInvStaxs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLInvStaxsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}