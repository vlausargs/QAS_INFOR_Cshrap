//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLVchStaxs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLVchStaxs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLVchStaxsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}