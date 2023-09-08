//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLJourHdrs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLJourHdrs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLJourHdrsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}