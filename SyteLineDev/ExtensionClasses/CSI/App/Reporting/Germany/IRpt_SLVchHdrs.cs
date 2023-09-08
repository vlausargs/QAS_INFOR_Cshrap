//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLVchHdrs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLVchHdrs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLVchHdrsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}